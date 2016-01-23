using UnityEngine;
using System.Collections;

public class PauseManager : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetButtonDown("TimeControl"))
			Gamedata.Instance.Paused = true;
		
		if(Input.GetButtonUp("TimeControl"))
			Gamedata.Instance.Paused = false;

	}
}
