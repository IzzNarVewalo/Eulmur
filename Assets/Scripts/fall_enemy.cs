using UnityEngine;
using System.Collections;

public class fall_enemy : MonoBehaviour, ITR {

	public bool invincible;
	public float bumpSpeed;
	public Variablen variablen;

	private TimeReverse trscript;

	IEnumerator FallDown() { 

		float verzoegerung = 0.5f;

		yield return new WaitForSeconds (verzoegerung); 

	}

	void Start(){
		trscript = GetComponent<TimeReverse> ();
		//immer wenn IEnumerator aufrufen, weil nicht normale Methode, sondern mit Wartezeit
		StartCoroutine(FallDown ());

	}


	void Update(){
		if (Gamedata.Instance.Paused && gameObject.GetComponent<TimeReverse>() != null)
			return;

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

	}
	#endregion

	private class MyStatus: TRObject
	{
		public Vector2 myPosition;
		//evtl. brauche mehr
	}

}
