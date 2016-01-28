using UnityEngine;
using System.Collections;
using System;

public class PlayerData : MonoBehaviour {

    public static string username  = "Guestrdztfuguho4657";
    public static int hp = 5;
    public static int money = 0;
    public static int food = 0;
    public static bool moustache = false;
    public static bool unicornhorn = false;
    public static bool crown = false;
    
    public static void LoadData (string username, int hp, int money, bool moustache, bool unicornhorn, bool crown) {
        PlayerData.username = username;
        PlayerData.hp = hp;
        PlayerData.money = money;
        PlayerData.moustache = moustache;
        PlayerData.unicornhorn = unicornhorn;
        PlayerData.crown = crown;
	}

    internal static void LoadData(string text)
    {
        throw new NotImplementedException();
    }
}
