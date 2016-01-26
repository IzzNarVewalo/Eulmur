using UnityEngine;
using System.Collections;

public class fallende_Platform : MonoBehaviour, ITR {

	private TimeReverse trscript;


	void Start()
	{
		trscript = GetComponent<TimeReverse> ();

	}

	IEnumerator FallDown() { 

		float verzoegerung = 3f;

		yield return new WaitForSeconds (verzoegerung); 

		gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
	}

	void OnCollisionEnter2D(Collision2D other){

		//immer wenn IEnumerator aufrufen, weil nicht normale Methode, sondern mit Wartezeit

		if (other.gameObject.tag == "Lemur" | other.gameObject.tag == "Owl" ) {
			StartCoroutine (FallDown ());
		}

	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "DeathZone") {
			Destroy(this.gameObject);

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
		//gameObject.GetComponent<Rigidbody2D>().isKinematic = false;

	}

	public void LoadTRObject (TRObject trobject)
	{
		MyStatus newStatus = (MyStatus)trobject;
		transform.position = newStatus.myPosition;
		//transform.rotation = newStatus.myRotation;
		gameObject.GetComponent<Rigidbody2D>().isKinematic = true;

		StartCoroutine(FallDown());

	}
	#endregion

	private class MyStatus: TRObject
	{
		public Vector2 myPosition;

		//evtl. brauche mehr
	}
}
