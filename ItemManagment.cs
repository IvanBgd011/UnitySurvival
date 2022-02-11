using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ItemManagment : MonoBehaviour
{
    public int wood = 0;
    public int stone = 0;

    public CheckCollision Check_collision;
    public Inventory inventory;

    public bool WaitForWood = false;
    public bool WaitForStone = false;

    public float Pickaxe_damage = 5f;
    public float Axe_damage = 0f;
    public float sword_damage = 0f;

    public int Pickaxe_harvest = 1;
    public int Axe_harvest = 1;

    public float Axe_speed = 0.1f;
    public float Pickaxe_speed = 0.1f;

    public int Usable = 0; //1 = wood, 2 = stone...

    void Start()
    {
    Pickaxe_damage = 5f;
    Axe_damage = 0f;
    sword_damage = 0f;

    Pickaxe_harvest = 1;
    Axe_harvest = 1;

    Axe_speed = 0.1f;
    Pickaxe_speed = 0.1f;
        
    }

    public void Mine()
    {
        if (Check_collision.treebool == true)
        {
            if (WaitForWood == false)
            {
                inventory.Pickup_wood();

                WaitForWood = true;
                wood = wood + 1;
                Invoke("MineWoodAfterTime", Axe_speed);
            }

        }
        if (Check_collision.rockbool == true)
        {
            if (WaitForStone == false)
            {
                inventory.Pickup_stone();
                WaitForStone = true;
                stone = stone + 1;
                Invoke("MineStoneAfterTime", Pickaxe_speed);
            }
        }

    }
    public void MineWoodAfterTime()
    {
        WaitForWood = false;

    }
    public void MineStoneAfterTime()
    {
        WaitForStone = false;

    }

    public void Use()
    {
        if(Usable == 1)
        {
            //
        }
        if(Usable == 2)
        {
            //place stone
        }
    }

}
