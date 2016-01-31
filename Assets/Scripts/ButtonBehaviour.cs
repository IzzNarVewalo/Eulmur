using UnityEngine;
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
            PlayerData.crown = false;
            PlayerData.moustache = false;
            PlayerData.unicornhorn = true;
        }
	}

	//prüfe ob so viel Geld da
	//abziehen
	//neuen Sprite laden

	public void Schnurer(){
		if (Gamedata.Instance.Score >= 100) {

			Gamedata.Instance.Score -= 100;
            PlayerData.crown = false;
            PlayerData.moustache = true;
            PlayerData.unicornhorn = false;
            Debug.Log("nach dem umziehen");
        }
	}


	public void Krone(){
		if (Gamedata.Instance.Score >= 1200) {

			Gamedata.Instance.Score -= 1200;
            PlayerData.crown = true;
            PlayerData.moustache = false;
            PlayerData.unicornhorn = false;

        }
	}


	public void Ueberraschung(){
		if (Gamedata.Instance.Score >= 850) {

			Gamedata.Instance.Score -= 850;
			int zahl = (int)Mathf.Round (Random.value * 3.0f);

			switch (zahl) {
			case 0:
                    PlayerData.crown = true;
                    PlayerData.moustache = false;
                    PlayerData.unicornhorn = false;
                    break;
			case 1:
                    PlayerData.crown = false;
                    PlayerData.moustache = true;
                    PlayerData.unicornhorn = false;
                    break;
			case 2:
                    PlayerData.crown = false;
                    PlayerData.moustache = false;
                    PlayerData.unicornhorn = true;
                    break;
			default: Gamedata.Instance.Lives += 1;
				break;
			}
		}
	}

	public void Herzen(){
		if (Gamedata.Instance.Score >= 600) {
			Gamedata.Instance.Score -= 600;
		}
		Gamedata.Instance.Lives += 1;
	}

}
