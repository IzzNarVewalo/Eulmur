using UnityEngine;
using System.Collections;

public class fall_enemy : MonoBehaviour {

	public bool invincible;
	public float bumpSpeed;
	public Variablen variablen;

	IEnumerator FallDown() { 

		float verzoegerung = 0.5f;

		yield return new WaitForSeconds (verzoegerung); 

	}

	void Start(){

		//immer wenn IEnumerator aufrufen, weil nicht normale Methode, sondern mit Wartezeit
		StartCoroutine(FallDown ());

	}


	void Update(){


		float amtToMove = variablen.currentSpeed * Time.deltaTime; 

		//             bewege dich
		transform.Translate (Vector2.down * amtToMove, Space.World);


	}


	void OnCollisionEnter2D(Collision2D other){

		if(other.gameObject.tag == "Ground"){
			
			gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			gameObject.GetComponent<BoxCollider2D> ().isTrigger = true;
			//gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
		}

	}



	/*void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "DeathZone") {
			

		}
	}*/
}
