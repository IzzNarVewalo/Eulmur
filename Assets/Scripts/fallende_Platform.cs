using UnityEngine;
using System.Collections;

public class fallende_Platform : MonoBehaviour {

	IEnumerator FallDown() { 

		float verzoegerung = 3f;

		yield return new WaitForSeconds (verzoegerung); 

		gameObject.GetComponent<Rigidbody> ().isKinematic = false;
		gameObject.GetComponent<Rigidbody> ().useGravity = true;




	}

	void OnCollisionEnter(Collision other){

		//immer wenn IEnumerator aufrufen, weil nicht normale Methode, sondern mit Wartezeit
		StartCoroutine(FallDown ());

	}

	void OnTriggerEnter(Collider other){

		if (other.tag == "DeathZone") {
			Destroy(this.gameObject);

		}

	}
}
