using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour, ITR {

	public bool invincible;
	public float bumpSpeed;
	private TimeReverse trscript;

	public Variablen variablen;

	void Start()
	{
	trscript = GetComponent<TimeReverse> ();}

	// Update is called once per frame
	void Update () {



		if (Gamedata.Instance.Paused && gameObject.GetComponent<TimeReverse>() != null)
			return;
		

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
		//Gamedata.Instance.Lives -= 1;
		//GameObject.FindGameObjectWithTag ("Owl").GetComponent<PlayerBehaiviour> ().Leben += 1;
	}



	//fuer TimeReverse
	#region ITR implementation
	public void SaveTRObject ()
	{
		MyStatus status = new MyStatus();
		status.myPosition = transform.position;
		//status.myRotation = transform.rotation;, gibts doch nicht, oder?
		trscript.PushTRObject (status);
		this.GetComponent<Rigidbody2D>().isKinematic = false;

	}

	public void LoadTRObject (TRObject trobject)
	{
		MyStatus newStatus = (MyStatus)trobject;
		transform.position = newStatus.myPosition;
		//transform.rotation = newStatus.myRotation;
		this.GetComponent<Rigidbody2D>().isKinematic = true;
		gameObject.GetComponent<BoxCollider2D> ().enabled = true;
		gameObject.GetComponent<BoxCollider2D> ().isTrigger = false;

	
	}
	#endregion

	private class MyStatus: TRObject
	{
		public Vector2 myPosition;
		//evtl. brauche mehr
	}
}
