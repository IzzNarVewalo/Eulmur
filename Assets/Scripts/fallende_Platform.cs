using UnityEngine;
using System.Collections;

public class fallende_Platform : MonoBehaviour {

	IEnumerator FallDown() { 

		float verzoegerung = 2f;

		yield return new WaitForSeconds (verzoegerung); 

		gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
	}

	void OnCollisionEnter2D(Collision2D other){

		//immer wenn IEnumerator aufrufen, weil nicht normale Methode, sondern mit Wartezeit
		StartCoroutine(FallDown ());

	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "DeathZone") {
			Destroy(this.gameObject);

		}
	}
}
