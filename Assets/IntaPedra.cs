using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntaPedra : MonoBehaviour {

	private float t1;
	public GameObject pedra;
	private float t2;
	// Use this for initialization
	void Start () {
		t2 = Random.Range (1.5f, 3);
		
	}
	
	// Update is called once per frame
	void Update () {
		t1 += Time.deltaTime;

		if (t1 >= t2){
			Instantiate (pedra, transform.position, transform.rotation);

			t1 = 0;
			t2 = Random.Range (1.5f, 3);
		}

	}
}
