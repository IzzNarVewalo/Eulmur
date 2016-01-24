using UnityEngine;
using System.Collections;

public class oben_unten_bewegende_Platform : MonoBehaviour {

	public Variablen variablen;



	// Update is called once per frame
	void Update () {



		float amtToMove = variablen.currentSpeed * Time.deltaTime; 

		//             bewege dich
		transform.Translate (Vector2.down * amtToMove, Space.World);


	}


	//nur wenn trigger berührt
	void OnTriggerEnter2D(Collider2D other) //nur prüfen, welches Object berührt <-> collision: nicht nur welches, sondern auch wo wie genau
	{
		Debug.Log ("asdf");
		if(other.tag == "Grenze"){

			variablen.currentSpeed *= -1; 
		}
	}
}
