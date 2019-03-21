using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GAobj : MonoBehaviour {

	Text genNOindicator;

	public GameObject car;
	GameObject car1;
	[HideInInspector] public int ptr;
	newMove carscrpit;
	int[] target = new int[]{ 0, 1, 2, 1, 0, 1, 2, 1, 0, 1, 2 };
	public population startObj;
	int popSIze;
	public bool finished=false;
	[HideInInspector]public List<int[]> bestgenesholder1;


	// Use this for initialization
	void Start () {
		genNOindicator = GetComponentInChildren<Text> ();
		ptr = -1;
		finished = false;
		popSIze = 100;
		Debug.Log ("starting");
		startObj = new population (popSIze);
		bestgenesholder1=new List<int[]> ();
		bestgenesholder1 = startObj.bestgenesholder;
		startInatantiating ();


	}
	
	// Update is called once per frame
	void Update () {
		genNOindicator.text = "Generation no: " + ptr;
		
	}

	public void startInatantiating()
	{
		Debug.Log (bestgenesholder1.Count);
		StartCoroutine (delay());


		
	}

	IEnumerator delay()
	{
		for(int i=0;i<bestgenesholder1.Count;i++)
		{
			ptr+=1;
			Instantiate (car);
			yield return new WaitForSeconds (6f);
		}

	}


		
}
