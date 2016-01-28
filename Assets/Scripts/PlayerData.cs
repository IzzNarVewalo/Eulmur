using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {

    public static string username;
    public static int hp = 5;
    public static int money = 0;
    public static int food = 0;

    public static bool moustache = false;
    public static bool unicornhorn = false;
    public static bool crown = false;

    // Update is called once per frame
    void LoadData (string username, int hp, int money, int food, bool moustache, bool unicornhorn, bool crown) {
        PlayerData.username = username;
        PlayerData.hp = hp;
        PlayerData.money = money;
        PlayerData.food = food;
        PlayerData.moustache = moustache;
        PlayerData.unicornhorn = unicornhorn;
        PlayerData.crown = crown;
	}
}
