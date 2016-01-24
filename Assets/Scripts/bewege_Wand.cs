using UnityEngine;
using System.Collections;

public class bewege_Wand : MonoBehaviour {

	public Variablen variablen;


	public void hoch(){
		//this.transform.Translate (this.transform.position.x, this.transform.position.y +0.2f, this.transform.position.z);
		 
		gameObject.transform.Translate (Vector3.up * 2f);
	}

	public void runter(){


		if(this.transform.position.y > 3){
			this.transform.Translate (0, -2f,0);
		}

	}


	//public GameObject[] liste;

	//private bool farben = false;

	// Update is called once per frame
	/*void Update () {

		liste = GameObject.FindGameObjectsWithTag ("Farbig");


		foreach (GameObject farbe in liste)
		{
			farben=farbe.GetComponent<die_Farbe_aenderte_Platform> ().rot;

		}


		if(farben){

			//bewege dich nach oben


			float amtToMove = variablen.currentSpeed * Time.deltaTime; 

			//             bewege dich
			transform.Translate (Vector2.up * amtToMove, Space.World);


		}
	}


	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "WandoberesEnde") {


			variablen.currentSpeed = 0;

		}
	}*/

}
