using UnityEngine;
using System.Collections;

public class oben_unten_bewegende_Platform : MonoBehaviour, ITR {

	public Variablen variablen;

	private TimeReverse trscript;

	void Start()
	{
		trscript = GetComponent<TimeReverse> ();
	}

	// Update is called once per frame
	void Update () {

		if (Gamedata.Instance.Paused && gameObject.GetComponent<TimeReverse>() != null)
			return;	

		float amtToMove = variablen.currentSpeed * Time.deltaTime; 

		//             bewege dich
		transform.Translate (Vector2.down * amtToMove, Space.World);


	}


	//nur wenn trigger berührt
	void OnTriggerEnter2D(Collider2D other) //nur prüfen, welches Object berührt <-> collision: nicht nur welches, sondern auch wo wie genau
	{
		if(other.tag == "Grenze"){

			variablen.currentSpeed *= -1; 
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

	}

	public void LoadTRObject (TRObject trobject)
	{

		MyStatus newStatus = (MyStatus)trobject;
		transform.position = newStatus.myPosition;


	}
	#endregion

	private class MyStatus: TRObject
	{
		public Vector2 myPosition;
		//evtl. brauche mehr
	}
}
