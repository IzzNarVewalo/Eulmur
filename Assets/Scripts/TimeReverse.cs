using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TimeReverse : MonoBehaviour {

	private Stack<TRObject> objectsOnStack = new Stack<TRObject>();

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
			if(objectsOnStack.Count > 0)
				otherScript.LoadTRObject (objectsOnStack.Pop());
		}
		else

		otherScript.SaveTRObject (); //um frameunabhaengig zu bleiben
	}

	public void PushTRObject(TRObject trobject)
	{
		objectsOnStack.Push(trobject);
	}
}
