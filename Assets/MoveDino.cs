using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveDino : MonoBehaviour {

	private Rigidbody2D r2d;
	private Vector2 dir;
	private bool move;

	public Text textPontos;
	private int pontos;

	private AudioSource fntSom;
	public AudioClip somCoin;
	public AudioClip somPulo;


	// Use this for initialization
	void Start () {
		r2d = GetComponent<Rigidbody2D>();	
		fntSom = GetComponent<AudioSource>();	
		dir = new Vector2 (0,20);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene ("02");
		}




		textPontos.text = "Pontos: " + pontos.ToString ();


		if (Input.GetKeyDown(KeyCode.Space) && move == true){
			r2d.AddForce (dir * 20);
			move = false;
			fntSom.PlayOneShot (somPulo);

		}
	}


	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.transform.tag == "Ground"){
			move = true;
		}

		if (coll.transform.tag == "Death"){


			SceneManager.LoadScene ("03");
		}
	}


	void OnTriggerEnter2D (Collider2D coll){
		if (coll.transform.tag == "Ponto") {
			pontos++;
			fntSom.PlayOneShot (somCoin);
		}
	}




	public void Pular (){
		if (move){
			r2d.AddForce (dir * 20);
			move = false;
			fntSom.PlayOneShot (somPulo);

		}

	}


}
