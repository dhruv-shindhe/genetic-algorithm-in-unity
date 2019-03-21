using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA  {

	int[] target = new int[]{ 0, 1, 2, 1, 0, 1, 2, 1, 0, 1, 2 };
	public int[] gene;
	public float fitness;
	public float mutationRate;

	private System.Random random;

	public DNA(int no)
	{
		random = new System.Random();

		gene = new int[no];
		for (int i = 0; i < no; i++) {
			gene [i] = Random.Range (0, 4);
		}
		
	}
	public void fitnessCal()
	{
		float score = 0;
		for (int i = 0; i < target.Length; i++) {
			if (gene [i] == target [i])
				score++;
		}
//		Debug.Log ("score in dna :" + score);
		fitness = score / target.Length;
		
	}

	public DNA crossOver(DNA partner)
	{
		DNA child=new DNA(target.Length);
		int midpt = Random.Range (0, target.Length);
		for (int i = 0; i < target.Length; i++) 
		{
			if (i <= midpt)
				child.gene [i] = this.gene [i];
			else
				child.gene [i] = partner.gene [i];
		}
		return child;
		
	}
	public void Mutate()
	{
		for (int i = 0; i < gene.Length; i++)
		{
			if (random.NextDouble() < mutationRate)
			{
				int a = gene[i];
				if (i == target.Length - 1) {
					gene [i] = gene [0];
					gene [0] = a;
				} 
				else {
					gene [i] = gene [i + 1];
					gene [i+1] = a;
				}
				
			}
		}
	}
}
