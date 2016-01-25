using UnityEngine;
using System.Collections;

public class die_Farbe_aenderte_Platform : MonoBehaviour {

	private int mitzaehlvariable = 0;
	public bool rot = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//wenn jemand auf die Platte draufspringt
	void OnCollisionEnter2D(Collision2D other){

		BoxCollider2D col = this.gameObject.GetComponent<BoxCollider2D>();
		BoxCollider2D mycol = other.gameObject.GetComponent<BoxCollider2D>();


		if (mycol.bounds.center.y - mycol.bounds.extents.y > col.bounds.center.y + 0.5f *
		   col.bounds.extents.y) {

			if (mitzaehlvariable == 0) {

				Renderer rend = this.gameObject.GetComponent<Renderer> ();

				rend.material.SetColor ("_Color", Color.blue);

				rot = false;
				mitzaehlvariable++;

				GameObject.FindGameObjectWithTag ("Wand").GetComponent<bewege_Wand> ().runter ();

				return;
			}

			if (mitzaehlvariable == 1) {

				Renderer rend = this.gameObject.GetComponent<Renderer> ();

				rend.material.SetColor ("_Color", Color.magenta);

				mitzaehlvariable++;
				rot = false;

				return;
			}


			if (mitzaehlvariable == 2) {

				Renderer rend = this.gameObject.GetComponent<Renderer> ();

				rend.material.SetColor ("_Color", Color.red);
				rot = true;
				GameObject.FindGameObjectWithTag ("Wand").GetComponent<bewege_Wand> ().hoch ();
				mitzaehlvariable = 0;
			}


		}
	}
}
