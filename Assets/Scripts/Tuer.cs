using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Tuer : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other){
		SceneManager.LoadScene(7);
	}
}
