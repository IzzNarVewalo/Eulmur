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

			Gamedata.Instance.Score -= 1500;
			PlayerBehaiviour.angezogen = gameObject.GetComponent<PlayerBehaiviour>().Kostum.Einhornhorn;
			gameObject.GetComponent<PlayerBehaiviour>().zeige ();
		
		}
	}

	//prüfe ob so viel Geld da

	//abziehen

	//neuen Sprite laden

	public void Schnurer(){
		if (Gamedata.Instance.Score >= 100) {

			Gamedata.Instance.Score -= 100;
			GameObject.GetComponent<PlayerBehaiviour> ().angezogen = gameObject.GetComponent<PlayerBehaiviour>().Kostum.Schnurrbart;
			gameObject.GetComponent<PlayerBehaiviour>().zeige ();
		}
	}


	public void Krone(){
		if (Gamedata.Instance.Score >= 1200) {

			Gamedata.Instance.Score -= 1200;
			GameObject.GetComponent<PlayerBehaiviour> ().angezogen = gameObject.GetComponent<PlayerBehaiviour>().Kostum.Krone;
			gameObject.GetComponent<PlayerBehaiviour>().zeige ();

		}
	}


	public void Ueberraschung(){
		if (Gamedata.Instance.Score >= 850) {

			Gamedata.Instance.Score -= 850;
			int zahl = Mathf.Round (Random.value * 3.0f);

			switch (zahl) {
			case 0:
				GameObject.GetComponent<PlayerBehaiviour> ().angezogen = gameObject.GetComponent<PlayerBehaiviour>().Kostum.Einhornhorn;
				break;
			case 1:
				GameObject.GetComponent<PlayerBehaiviour> ().angezogen = gameObject.GetComponent<PlayerBehaiviour>().Kostum.Schnurrbart;
				break;
			case 2: GameObject.GetComponent<PlayerBehaiviour> ().angezogen = gameObject.GetComponent<PlayerBehaiviour>().Kostum.Krone;
				break;
			default: Gamedata.Instance.Lives += 1;
				break;
			}

			gameObject.GetComponent<PlayerBehaiviour>().zeige ();
		}
	}

	public void Herzen(){
		if (Gamedata.Instance.Score >= 600) {


			Gamedata.Instance.Score -= 600;
		
		}
		Gamedata.Instance.Lives += 1;
	}

}
