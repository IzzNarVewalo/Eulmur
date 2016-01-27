using UnityEngine;
using System.Collections;

public class ButtonBehaviour : MonoBehaviour {


	public void LoadLevelByName(string levelName)
	{
		Application.LoadLevel(levelName);
	}

	public void ResetStats()
	{
		Gamedata.Instance.Score = 0;
		Gamedata.Instance.Lives = 5;
	}


}
