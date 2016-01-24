using UnityEngine;
using System.Collections;

public class die_Farbe_aenderte_Platform : MonoBehaviour {

	private int mitzaehlvariable = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//wenn jemand auf die Platte draufspringt
	void OnCollisionEnter2D(Collision2D other){

		if(mitzaehlvariable == 0){

			Renderer rend = this.gameObject.GetComponent<Renderer> ();

			rend.material.SetColor ("_Color",Color.blue);

			mitzaehlvariable++;

			return;
		}

		if(mitzaehlvariable == 1){

			Renderer rend = this.gameObject.GetComponent<Renderer> ();

			rend.material.SetColor ("_Color",Color.magenta);

			mitzaehlvariable++;

			return;
		}


		if(mitzaehlvariable == 2){

			Renderer rend = this.gameObject.GetComponent<Renderer> ();

			rend.material.SetColor ("_Color",Color.red);

			mitzaehlvariable = 0;
		}



	}
}
