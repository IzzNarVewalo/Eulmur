using UnityEngine;
using System.Collections;



[System.Serializable] 
public class Variablen{
	public float currentSpeed;
	//public float currentRotationSpeed;
	//public GameObject mittelpunkt;
}



public class links_rechts_bewegende_Platform : MonoBehaviour {

	public Variablen variablen;

	// Update is called once per frame
	void Update () {

		float amtToMove = variablen.currentSpeed * Time.deltaTime; 

		//             bewege dich
		transform.Translate (Vector2.right * amtToMove, Space.World);

	}


	//nur wenn trigger berührt
	void OnTriggerEnter2D(Collider2D other) //nur prüfen, welches Object berührt <-> collision: nicht nur welches, sondern auch wo wie genau
	{
		
		if(other.tag == "Grenze"){

			variablen.currentSpeed *= -1; 

		}
	}
}
