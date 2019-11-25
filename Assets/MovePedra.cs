using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePedra : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (Destruir ());
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (transform.right * -0.15f);
	}

	IEnumerator Destruir (){
		yield return new WaitForSeconds (5);
		Destroy (this.gameObject);
	}
}
