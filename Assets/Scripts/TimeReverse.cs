using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TimeReverse : MonoBehaviour {

	//private Stack<TRObject> objectsOnStack = new Stack<TRObject>();
	private CircularBuffer objectsInCircularBuffer = new CircularBuffer(100000);

	private ITR otherScript;
	void Start ()
	{
		otherScript= (ITR)gameObject.GetComponent (typeof(ITR));
	}

	void FixedUpdate ()
	{

		if
			(Input.GetButton ("TimeControl"))
		{
			if(objectsInCircularBuffer.Count > 0)
				otherScript.LoadTRObject (objectsInCircularBuffer.Pop());
		}
		else

		otherScript.SaveTRObject (); //um frameunabhaengig zu bleiben
	}

	public void PushTRObject(TRObject trobject)
	{
		objectsInCircularBuffer.Push(trobject);
	}
}
