using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoginMenu : MonoBehaviour {

    public void createAccount()
    {
        Application.OpenURL("http://www.1000sunny.de/");
    }

    public void playOffline()
    {
        SceneManager.LoadScene(1);
    }

    public void playOnline()
    {

    }
}
