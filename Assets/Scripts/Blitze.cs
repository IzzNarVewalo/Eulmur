using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Blitze : MonoBehaviour {

	float zahl = Random.value;

	// Use this for initialization
	void Start () {
		StartCoroutine (blitzen ());
	}

	IEnumerator blitzen()
	{
	    yield return new WaitForSeconds(5);
	    StartCoroutine(nextLevel());
		while (true)
		{
			//aufs Gegenteil setzen
			GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;


			yield return new WaitForSeconds(zahl * 4);//wartezeit, wenn 0:würde zu schnell blinken
		}

	}

    IEnumerator nextLevel()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(3);
    }

}
