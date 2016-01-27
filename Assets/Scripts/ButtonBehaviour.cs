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


	public void Einhorn(){

	}

	//prüfe ob so viel Geld da

	//abziehen

	//neuen Sprite laden

	public void Schnurer(){

	}


	public void Krone(){

	}


	public void Ueberracshung(){

	}

	public void Herzen(){
	}

}
