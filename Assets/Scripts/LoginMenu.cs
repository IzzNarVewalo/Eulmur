﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class LoginMenu : MonoBehaviour {

    public void createAccount()
    {
        SceneManager.LoadScene(1);
        //Application.OpenURL("http://www.1000sunny.de/games/eulmur/create");
    }

    public void playOffline()
    {
        SceneManager.LoadScene(2);
    }

    public void playOnline()
    {
        StartCoroutine(checkDetails());
    }

    IEnumerator checkDetails()
    {
        var form = new WWWForm();
        form.AddField("benutzername",GameObject.FindGameObjectWithTag("Username").GetComponent<InputField>().text);
        form.AddField("passwort", md5Sum(GameObject.FindGameObjectWithTag("Password").GetComponent<InputField>().text+"$K?1/S_@2%e#el!3>s#5BRo$a1+"));
        var connection = new WWW("http://www.1000sunny.de/games/eulmur/login.php", form);
        yield return connection;
        if (connection.error != null)
            Debug.Log("ouldn't connect to the server: " + connection.error);
        else if (connection.text.Equals("\n1"))
        {
            var getMoney = new WWW("http://www.1000sunny.de/games/eulmur/getmoney.php", form);
            yield return getMoney;
            var getLives = new WWW("http://www.1000sunny.de/games/eulmur/getlives.php", form);
            yield return getLives;
            var getClothes = new WWW("http://www.1000sunny.de/games/eulmur/getclothes.php", form);
            yield return getClothes;

            if (getMoney.error != null && getClothes.error != null && getLives.error != null)
                Debug.Log("Couldn't connect to the server: " + connection.error);
            else { 
                PlayerData.LoadData(GameObject.FindGameObjectWithTag("Username").GetComponent<InputField>().text,getMoney.text,getLives.text,getClothes.text);
                SceneManager.LoadScene(2);
            }
        }
        else
            Debug.Log("falsches pw" + connection.text);
    }

    public void saveData()
    {
        StartCoroutine(setMoney());
    }

    IEnumerator setMoney()
    {
        var form = new WWWForm();
        form.AddField("benutzername", PlayerData.username);
        form.AddField("guthaben",Gamedata.Instance.Score);
        var connection = new WWW("http://www.1000sunny.de/games/eulmur/setguthaben.php", form);
        yield return connection;
        if (connection.error != null)
            Debug.Log("ouldn't connect to the server: " + connection.error);
        else
            Debug.Log("succesful");
    }

    public void backToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void newAccount()
    {
        if (GameObject.FindGameObjectWithTag("Username").GetComponent<InputField>().text.Equals("") || GameObject.FindGameObjectWithTag("Password").GetComponent<InputField>().text.Equals(""))
            Debug.Log("passwort oder benutzername darf nicht leer sein");
        else if (GameObject.FindGameObjectWithTag("Password").GetComponent<InputField>().text.Equals(GameObject.FindGameObjectWithTag("RepeatPassword").GetComponent<InputField>().text))
            StartCoroutine(insertToDB());
        else
            Debug.Log("PW 2 mal unterschiedlich");
    }

    IEnumerator insertToDB()
    {
        var form = new WWWForm();
        form.AddField("benutzername", GameObject.FindGameObjectWithTag("Username").GetComponent<InputField>().text);
        form.AddField("passwort", md5Sum(GameObject.FindGameObjectWithTag("Password").GetComponent<InputField>().text + "$K?1/S_@2%e#el!3>s#5BRo$a1+"));
        var connection = new WWW("http://www.1000sunny.de/games/eulmur/create.php", form);
        yield return connection;
        if (connection.error != null)
            Debug.Log(connection.error);
        else
            Debug.Log("Account erstellt");
    }

    public string md5Sum(string strToEncrypt)
    {
        var ue = new System.Text.UTF8Encoding();
        var bytes = ue.GetBytes(strToEncrypt);

        //encrypt bytes
        var md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        var hashBytes = md5.ComputeHash(bytes);

        //Convert the encrypted bytes back to a string (base 16)
        var hashString = hashBytes.Aggregate("", (current, t) => current + System.Convert.ToString(t, 16).PadLeft(2, '0'));

        return hashString.PadLeft(32, '0');
    }
}
