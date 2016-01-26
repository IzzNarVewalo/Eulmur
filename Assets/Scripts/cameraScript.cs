using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour
{
    public GameObject Owl, Lemur;
    
    void LateUpdate()
    {
        float blah = (Owl.transform.position.x + Lemur.transform.position.x) / 2;
        Vector3 whereToGo = new Vector3(blah, 2.8f, -10f);
        transform.position = Vector3.Lerp(transform.position, whereToGo, Time.deltaTime);


        if (transform.position.x < -1.5f)
            transform.position = new Vector3(-1.5f, 2.8f, -10);


    }
}