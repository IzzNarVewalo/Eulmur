using UnityEngine;
using System.Collections;

public class Blitze : MonoBehaviour {

	float zahl = Random.value;

	// Use this for initialization
	void Start () {
		StartCoroutine (blitzen ());
	}

	IEnumerator blitzen(){

		while (true)
		{
			//aufs Gegenteil setzen
			GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;


			yield return new WaitForSeconds(zahl * 2);//wartezeit, wenn 0:würde zu schnell blinken
		}

	}

}
