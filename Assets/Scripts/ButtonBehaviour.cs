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
		if (Gamedata.Instance.Score >= 1500) {
		}
	}

	//prüfe ob so viel Geld da

	//abziehen

	//neuen Sprite laden

	public void Schnurer(){
		if (Gamedata.Instance.Score >= 100) {
		}
	}


	public void Krone(){
		if (Gamedata.Instance.Score >= 1200) {
		}
	}


	public void Ueberracshung(){
		if (Gamedata.Instance.Score >= 850) {

		}
	}

	public void Herzen(){
		if (Gamedata.Instance.Score >= 600) {
		}
		Gamedata.Instance.Lives += 1;
	}

}
