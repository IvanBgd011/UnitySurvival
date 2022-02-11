using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyingManagment : MonoBehaviour
{
    public Inventory inventory;

    private int WoodChecker = 0;
    private bool CheckSpace = false;
    //Wooden Pickaxe
    private int WoodenPickaxeWood = 10;

    public Sprite WoodenPickaxe;

    public void BuyWoodenPickaxe() //wood == 1
    {
        WoodChecker = WoodenPickaxeWood;
        for (int b = 0; b <= 27; b++)
        {
            if(inventory.GetComponent<Inventory>().ItemsTypeList[b] == 0)
            {
                CheckSpace = true;
            }
        }
        if(CheckSpace == true)
        {
/*wood*/for (int i = 0; i <= 27; i++)
            {
                if (WoodChecker > 0)
                {
                    if (inventory.GetComponent<Inventory>().ItemsTypeList[i] == 1)
                    {
                        if (inventory.GetComponent<Inventory>().ItemsAmountList[i] > WoodChecker)
                        {
                            inventory.GetComponent<Inventory>().ItemsAmountList[i] = inventory.GetComponent<Inventory>().ItemsAmountList[i] - WoodenPickaxeWood;
                            inventory.GetComponent<Inventory>().AmountList[i].text = inventory.GetComponent<Inventory>().ItemsAmountList[i] + "";
                            break;
                        }
                    }
                    if (inventory.GetComponent<Inventory>().ItemsAmountList[i] <= WoodChecker)
                    {
                        WoodChecker = WoodChecker - inventory.GetComponent<Inventory>().ItemsAmountList[i];
                        inventory.GetComponent<Inventory>().ItemsAmountList[i] = 0;
                        inventory.GetComponent<Inventory>().ItemsTypeList[i] = 0;
                        inventory.GetComponent<Inventory>().IconList[i].sprite = null;
                        inventory.GetComponent<Inventory>().IconListHotbar[i].color = new Color(inventory.GetComponent<Inventory>().IconListHotbar[i].color.r, inventory.GetComponent<Inventory>().IconListHotbar[i].color.g, inventory.GetComponent<Inventory>().IconListHotbar[i].color.b, 0f);
                        inventory.GetComponent<Inventory>().AmountList[i].text = "";

                    }
                    if (WoodChecker <= 0)
                    {
                        break;
                    }
                }
            } //Remove Wood
            for (int j = 0; j <= 27; j++)
            {
                if(inventory.GetComponent<Inventory>().ItemsTypeList[j] == 0)
                {
                    Debug.Log("loop:" + j);
                    inventory.GetComponent<Inventory>().ItemsTypeList[j] = 512;
                    inventory.GetComponent<Inventory>().ItemsAmountList[j] = 1;
                    inventory.GetComponent<Inventory>().IconList[j].sprite = WoodenPickaxe;
                    inventory.GetComponent<Inventory>().IconListHotbar[j].color = new Color(inventory.GetComponent<Inventory>().IconListHotbar[j].color.r, inventory.GetComponent<Inventory>().IconListHotbar[j].color.g, inventory.GetComponent<Inventory>().IconListHotbar[j].color.b, 100f);
                    break;
                }
            } //Add pickaxe
        }
        

    }
}
