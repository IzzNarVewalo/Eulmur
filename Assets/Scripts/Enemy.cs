using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public bool invincible;
	public float bumpSpeed;


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

	public void OnDeath()
	{
		gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		gameObject.GetComponent<BoxCollider2D> ().isTrigger = true;
		gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
		Gamedata.Instance.Lives -= 1;
		//GameObject.FindGameObjectWithTag ("Owl").GetComponent<PlayerBehaiviour> ().Leben += 1;
	}
}
