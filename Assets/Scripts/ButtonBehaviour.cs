using UnityEngine;
using System.Collections;
using UnityEditor.MemoryProfiler;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour {
    
	public void Start(){


		UpdateStats ();
	}

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

    //prüfe ob so viel Geld da
    //abziehen
    //neuen Sprite laden

	public void Einhorn(){
		if (Gamedata.Instance.Score >= 1500) {

			Gamedata.Instance.Score -= 1500;
            PlayerData.unicornhorn = true;
			UpdateStats ();
        }
	}

    public void EinhornAusziehen()
    {
        PlayerData.unicornhorn = false;
    }

    public void Schnurrbart(){
		if (Gamedata.Instance.Score >= 100) {

			Gamedata.Instance.Score -= 100;
            PlayerData.moustache = true;
			UpdateStats ();
        }
	}

    public void SchnurrbartAusziehen()
    {
        PlayerData.moustache = false;
    }
    
	public void Krone(){
		if (Gamedata.Instance.Score >= 1200) {

			Gamedata.Instance.Score -= 1200;
            PlayerData.crown = true;
			UpdateStats ();

        }
	}

    public void KroneAusziehen()
    {
        PlayerData.crown = false;
    }

    public void Ueberraschung(){
		if (Gamedata.Instance.Score >= 850) {

			Gamedata.Instance.Score -= 850;
			int zahl = (int)Mathf.Round (Random.value * 3.0f);

			switch (zahl) {
			case 0:
                    PlayerData.crown = true;
                    break;
			case 1:
                    PlayerData.moustache = true;
                    break;
			case 2:
                    PlayerData.unicornhorn = true;
                    break;
			default: Gamedata.Instance.Lives += 1;
				break;
			}
			UpdateStats ();
		}
	}

	public void Herzen(){
		if (Gamedata.Instance.Score >= 600) {
			Gamedata.Instance.Score -= 600;
		}
		Gamedata.Instance.Lives += 1;
	}


	private static void UpdateStats ()
	{ 

		Text Geldstandanzeige;
		
		Geldstandanzeige = GameObject.Find ("geldstand").GetComponent<Text> ();
		Geldstandanzeige.text = "Geldstand: " + Gamedata.Instance.Score.ToString ();
			
	}

}
