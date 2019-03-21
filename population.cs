using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class population : MonoBehaviour{

	GameObject gaobj;
	public GAobj sendB;
	public DNA[] populationSet;
	public List<DNA> matingPool;
	public List<int[]> bestgenesholder;
	int[] target = new int[]{ 0, 1, 2, 1, 0, 1, 2, 1, 0, 1, 2 };
	public float mutaionRate=0.01f;
	public bool finished;
	public int genNO;
	public int[] bestFitGene;

	public population(int popSize)
	{
		gaobj = GameObject.FindGameObjectWithTag("gaObj");
		sendB = gaobj.GetComponent<GAobj> ();
		bestFitGene = new int[target.Length];
		finished = false;
		genNO = 0;
		populationSet = new DNA[popSize];
		matingPool = new List<DNA> ();
		bestgenesholder = new List<int[]> ();
		for (int i = 0; i < populationSet.Length; i++) {
			populationSet [i] = new DNA (target.Length);
		}

		//
		Debug.Log("created the initial population ");
	
		while (!finished) {
			Debug.Log ("generation no: " + genNO);

			if (genNO > 100)
				break;
			

			//calculate fitness of all individuals
			FitnessCAlcu();

			//check for fitess gene
			bestFitGene=new int[target.Length];
			float BestFitFitness;
			bestFitGene = populationSet [0].gene;
			BestFitFitness = populationSet [0].fitness;
				for (int i = 0; i < populationSet.Length; i++) {
				if (BestFitFitness < populationSet [i].fitness) {
					BestFitFitness = populationSet [i].fitness;
					bestFitGene = populationSet [i].gene;
				}
				}
			Debug.Log ("fitess id:" + BestFitFitness);


//create best fit gene list
			bestgenesholder.Add(bestFitGene);

//this will do the convergence
			for (int i = 0; i < populationSet.Length; i++) {
				if (populationSet [i].fitness == 1) {
					finished = true;
					bestFitGene = populationSet [i].gene;
					Debug.Log ("printing the best");
					for (int j = 0; j < populationSet[i].gene.Length; j++)
						Debug.Log(populationSet[i].gene[j]);
					//sendB.startINstantating ();
					sendB.bestgenesholder1=bestgenesholder;
					sendB.finished = true;
					break;
				
				}
			}

				


			//creATE mating pool
			matingPool.Clear ();
			for (int i = 0; i < populationSet.Length; i++) {
				int a = (int)(populationSet [i].fitness * 100);
				for (int j = 0; j < a; j++)
					matingPool.Add (populationSet [i]);
			}

	//		Debug.Log ("mating pool size:"+matingPool.Count);

			//maitng
			for (int i = 0; i < populationSet.Length; i++) {
		
				int a1 = Random.Range (0, matingPool.Count);
				int b = Random.Range (0, matingPool.Count);
				DNA partnerA = matingPool [a1];
				DNA partnerB = matingPool [b];
				DNA child = partnerA.crossOver (partnerB);
				child.Mutate ();
				populationSet [i] = child;
			}


			genNO++;
		}
	}

	public void FitnessCAlcu()
	{
		for (int i = 0; i < populationSet.Length; i++) {
			populationSet [i].fitnessCal ();
//			Debug.Log ("fitness score:"+populationSet [i].fitness);
		}
	}



}
