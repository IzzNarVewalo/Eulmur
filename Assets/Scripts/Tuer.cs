using UnityEngine;
using System.Collections;

public class Tuer : MonoBehaviour {


	void OnCollisionEnter2D(Collision2D other){


		Application.LoadLevel ("Endszene");

	}
}
