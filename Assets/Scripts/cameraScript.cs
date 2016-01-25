using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour
{
    public GameObject Owl, Lemur;

    // Update is called once per frame
    void Update()
    {
        float blah = (Owl.transform.position.x + Lemur.transform.position.x) / 2 - transform.position.x - 2f;
        Vector3 whereToGo = new Vector3(blah, 0, 0);
        transform.Translate(whereToGo, Space.World);
    }
    
    void LateUpdate()
    {


        if (transform.position.x <= -1.5f)
            transform.position = new Vector3(-1.5f, transform.position.y, transform.position.z);


    }
}