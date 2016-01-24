using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour {
    public GameObject Owl, Lemur;

	// Update is called once per frame
	void Update () {
        if (Mathf.Abs(Owl.transform.position.x - Lemur.transform.position.x) < 4f)
        {
            gameObject.transform.position = new Vector3((Owl.transform.position.x - Lemur.transform.position.x) / -4f,
                gameObject.transform.position.y, transform.position.z);
        }
        else if ((Mathf.Abs(Owl.transform.position.x - Lemur.transform.position.x)) > 4.0f &&
   (Mathf.Abs(Owl.transform.position.x - Lemur.transform.position.x)) < 8.0f)
        {
            gameObject.transform.position = new Vector3(
                (Owl.transform.position.x + Lemur.transform.position.x) / 2 
                - (3 + 0.5f * (Mathf.Abs(Owl.transform.position.x - Lemur.transform.position.x) - 4.0f)),
                gameObject.transform.position.y, transform.position.z);
        }
        else
        {
            gameObject.transform.position = new Vector3((Owl.transform.position.x + Lemur.transform.position.x) / 2 - 5.0f,
                 gameObject.transform.position.y, transform.position.z);
        }
    }
}
