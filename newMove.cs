using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newMove : MonoBehaviour {

	public int[] dirArray;
	GameObject gaobj;
	GAobj getdirection;
	int dirPtr;
	Vector3[] dir;
	float speed=0.5f;
	int dir_taken;
	int[] target = new int[]{ 0, 1, 2, 1, 0, 1, 2, 1, 0, 1, 2 };

	// Use this for initialization
	void Start () {
		gaobj = GameObject.FindGameObjectWithTag("gaObj");
		getdirection = gaobj.GetComponent<GAobj> ();
		dirArray = new int[target.Length];
		dirArray = getdirection.bestgenesholder1 [getdirection.ptr];
		Debug.Log (getdirection.ptr);
		dirPtr=0;
		dir_taken = 0;
		dir = new[]{ new Vector3( 0f,0f,speed ),new Vector3 ( speed,0f,0f ),new Vector3 ( 0f,0f,-1*speed),new Vector3 ( -1*speed,0f,0f )};
		Destroy (this.gameObject, 5);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
			transform.Translate (dir [dir_taken]);
		}


	public void OnCollisionEnter(Collision edge)
	{
		
		if (edge.gameObject.tag == "edge") {
			dirPtr++;
			dir_taken = dirArray [dirPtr];


		}
		else if (edge.gameObject.tag == "side"){
			Destroy (this.gameObject, 0f);
		}

		else if (dirPtr>=10)
			Destroy (this.gameObject, 0f);


	}
		



}

