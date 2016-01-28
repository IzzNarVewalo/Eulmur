using UnityEngine;
using System.Collections;

public class WandbewegeKnopf : MonoBehaviour {


	public Variablen variablen;

	public void bewegeHoch(){
		
		gameObject.transform.Translate (Vector3.up * 6f);
	}



}
