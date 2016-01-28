﻿using UnityEngine;
using System.Collections;
using UnityEditor.MemoryProfiler;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour {
    
	public void ResetStats()
	{
		Gamedata.Instance.Lives = 5;
	}

    public void backToMenu()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(3);
    }

    public void Shop()
    {
        SceneManager.LoadScene(5);
    }

	public void Einhorn(){
		if (Gamedata.Instance.Score >= 1500) {

			Gamedata.Instance.Score -= 1500;
			PlayerBehaiviour.angezogen =  PlayerBehaiviour.Kostum.Einhornhorn;
			gameObject.GetComponent<PlayerBehaiviour>().zeige ();
		
		}
	}

	//prüfe ob so viel Geld da

	//abziehen

	//neuen Sprite laden

	public void Schnurer(){
		if (Gamedata.Instance.Score >= 100) {

			Gamedata.Instance.Score -= 100;
            PlayerBehaiviour.angezogen = PlayerBehaiviour.Kostum.Schnurrbart;
			gameObject.GetComponent<PlayerBehaiviour>().zeige ();
		}
	}


	public void Krone(){
		if (Gamedata.Instance.Score >= 1200) {

			Gamedata.Instance.Score -= 1200;
            PlayerBehaiviour.angezogen = PlayerBehaiviour.Kostum.Krone;
			gameObject.GetComponent<PlayerBehaiviour>().zeige ();

		}
	}


	public void Ueberraschung(){
		if (Gamedata.Instance.Score >= 850) {

			Gamedata.Instance.Score -= 850;
			int zahl = (int)Mathf.Round (Random.value * 3.0f);

			switch (zahl) {
			case 0:
                    PlayerBehaiviour.angezogen = PlayerBehaiviour.Kostum.Einhornhorn;
				break;
			case 1:
                    PlayerBehaiviour.angezogen = PlayerBehaiviour.Kostum.Schnurrbart;
				break;
			case 2:
                    PlayerBehaiviour.angezogen = PlayerBehaiviour.Kostum.Krone;
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
