using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManagment : MonoBehaviour
{
    public  ItemManagment ItemManagment;

    public Text pickaxe_before;
    public Text pickaxe_after;
    public Text pickaxe_price;




    //Tools
    int Stone_pickaxe_Amount = 0;
    public void Stone_pickaxe_buy()
    {
        if(Stone_pickaxe_Amount == 0 && ItemManagment.wood >= 10 && ItemManagment.stone >= 20)
        {
            //changing the ui before upgrade
            pickaxe_before.text = "Damage: " + ItemManagment.Pickaxe_damage + "\nHarvest: " + ItemManagment.Pickaxe_harvest + "\nSpeed: " + ItemManagment.Pickaxe_speed + "s";
            //changing the ui before upgrade
            //pricing
            ItemManagment.wood = ItemManagment.wood - 10;
            ItemManagment.stone = ItemManagment.stone - 20;
            //pricing

            //doing
            ItemManagment.Pickaxe_damage = 8f;
            ItemManagment.Pickaxe_harvest = 1;
            ItemManagment.Pickaxe_speed = 1.8f;
            //doing

            //changing the ui
            pickaxe_after.text = "Damage: " + ItemManagment.Pickaxe_damage + "\nHarvest: " + ItemManagment.Pickaxe_harvest + "\nSpeed: " + ItemManagment.Pickaxe_speed + "s";
            //changing the ui

        }
    }
    //Tools
}
