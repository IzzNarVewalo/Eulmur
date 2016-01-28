using UnityEngine;
using System.Collections;
using System;

public class PlayerData : MonoBehaviour
{

    public static string username = "Guestrdztfuguho4657";
    public static int hp = 5;
    public static int money = 0;
    public static int food = 0;
    public static bool moustache = false;
    public static bool unicornhorn = false;
    public static bool crown = false;

    public static void LoadData(string username, string money, string lives, string clothes)
    {
        PlayerData.username = username;
        PlayerData.hp = Convert.ToInt32(lives);
        PlayerData.money = Convert.ToInt32(money);
        var clothe = clothes.ToCharArray();
        PlayerData.crown = (clothe[0] == 't');
        PlayerData.unicornhorn = (clothe[1] == 't');
        PlayerData.moustache = (clothe[2] == 't');
    }
}