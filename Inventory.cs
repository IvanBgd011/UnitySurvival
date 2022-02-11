using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public Sprite WoodIcon;
    public Sprite StoneIcon;

    public List<GameObject> InventoryList;          //lista ui 
    public List<Image> IconList;                    //lista ikona
    public List<TextMeshProUGUI> AmountList;        //lista ui tekstova za kolicinu

    public List<int> ItemsTypeList;                 //id: 1 = wood, 2 = stone etc.
    public List<int> ItemsAmountList;               //lista kolicina int


    public List<Image> IconListHotbar;              //lista ikona za hotbar
    public List<TextMeshProUGUI> AmountListHotbar;  //lista tekstova za kolicinu za hotbar

    int select = 0;
    int selectsecond = 0;
    bool select2 = false;
    bool selected = false;
    bool selectsecond2 = false;     //ItemsType int, itemsAmount int, IconList Image

    int SwitchType, SwitchAmount;
    public Image SwitchImage;

    private ItemManagment itemManagment;

    bool mined = false;
    int selectHotBar;
    bool HotBarSelected = false;
    bool HotBarUsedSelect = false;
    private void Start()
    {
        UpdateHotBar();
        UpdateInventory();
    }

    private void UpdateHotBar()
    {
        for(int i = 0; i < 7; i++)
        {
            IconListHotbar[i].sprite = IconList[i].sprite;
            if(ItemsAmountList[i] != 0)
            {
                IconListHotbar[i].color = new Color(IconListHotbar[i].color.r, IconListHotbar[i].color.g, IconListHotbar[i].color.b, 100f);
                AmountListHotbar[i].text = ItemsAmountList[i] + "";
            }
            if(ItemsAmountList[i] == 0)
            {
                IconListHotbar[i].color = new Color(IconListHotbar[i].color.r, IconListHotbar[i].color.g, IconListHotbar[i].color.b, 0f);
                AmountListHotbar[i].text = "";
            }

        }
        Invoke("UpdateHotBar", 0.1f);

    }

    private void UpdateInventory()
    {
        for (int i = 0; i <= 27; i++)
        {
            if (ItemsAmountList[i] != 0)
            {
                AmountList[i].text = ItemsAmountList[i] + "";
            }
            if(ItemsAmountList[i] == 0)
            {
                AmountList[i].text = "";
                IconList[i].sprite = null;
                IconList[i].color = new Color(IconList[i].color.r, IconList[i].color.g, IconList[i].color.b, 0f);
            }

        }
        Invoke("UpdateInventory", 0.1f);

    }
    public void Pickup_wood() //wood id = 1
    {
        for(int a = 0; a <= 27; a++)
        {
            if(ItemsTypeList[a] == 1)
            {
                if (ItemsAmountList[a] < 100)
                {
                    ItemsAmountList[a] = ItemsAmountList[a] + 1;
                    AmountList[a].text = ItemsAmountList[a] + "";
                    mined = true;
                    
                }
            }
        }
        for(int i = 0; i <= 27; i++)
        {
            if(mined == false)
            {
                if (ItemsTypeList[i] == 1 || ItemsTypeList[i] == 0)
                {
                    if (ItemsAmountList[i] < 100)
                    {
                        ItemsTypeList[i] = 1;
                        ItemsAmountList[i] = ItemsAmountList[i] + 1;
                        AmountList[i].text = ItemsAmountList[i] + "";
                        IconList[i].sprite = WoodIcon;
                        mined = false;
                        if (i < 7)
                        {
                            IconListHotbar[i].color = new Color(IconListHotbar[i].color.r, IconListHotbar[i].color.g, IconListHotbar[i].color.b, 100f);
                        }
                        IconList[i].color = new Color(IconList[i].color.r, IconList[i].color.g, IconList[i].color.b, 100f);
                        break;
                    }

                }
            }

        }
    }

    public void Pickup_stone() //stone id = 2
    {
        for (int a = 0; a <= 27; a++)
        {
            if (ItemsTypeList[a] == 2)
            {
                if (ItemsAmountList[a] < 100)
                {
                    ItemsAmountList[a] = ItemsAmountList[a] + 1;
                    AmountList[a].text = ItemsAmountList[a] + "";
                    mined = true;                  
                }
            }
        }
        for (int i = 0; i <= 27; i++)
        {
            if (mined == false)
            {
                if (ItemsTypeList[i] == 2 || ItemsTypeList[i] == 0)
                {
                    if (ItemsAmountList[i] < 100)
                    {
                        ItemsTypeList[i] = 2;
                        ItemsAmountList[i] = ItemsAmountList[i] + 1;
                        AmountList[i].text = ItemsAmountList[i] + "";
                        IconList[i].sprite = StoneIcon;
                        mined = false;
                        if (i < 7)
                        {
                            IconListHotbar[i].color = new Color(IconListHotbar[i].color.r, IconListHotbar[i].color.g, IconListHotbar[i].color.b, 100f);
                        }
                        IconList[i].color = new Color(IconList[i].color.r, IconList[i].color.g, IconList[i].color.b, 100f);
                        break;
                    }

                }
            }
        }
    }

    public void SelectInHotBar()
    {
        if(HotBarSelected == false && HotBarUsedSelect == false)
        {
            itemManagment.Usable = ItemsTypeList[selectHotBar];
            HotBarSelected = true;
            HotBarUsedSelect = true;
        }
        if(HotBarSelected == true && HotBarUsedSelect == false)
        {
            HotBarSelected = true;
            HotBarUsedSelect = true;
            itemManagment.Usable = 0;
        }
        HotBarUsedSelect = false;

    }

    public void HotBarSelect1()
    {
        selectHotBar = 0;
    }
    public void HotBarSelect2()
    {
        selectHotBar = 1;
    }
    public void HotBarSelect3()
    {
        selectHotBar = 2;
    }
    public void HotBarSelect4()
    {
        selectHotBar = 3;
    }
    public void HotBarSelect5()
    {
        selectHotBar = 4;
    }
    public void HotBarSelect6()
    {
        selectHotBar = 5;
    }
    public void HotBarSelect7()
    {
        selectHotBar = 6;
    }
    //transfering:
    public void Select()
    {
        if(ItemsTypeList[select] != ItemsTypeList[selectsecond])
        {
            SwitchType = ItemsTypeList[select];
            ItemsTypeList[select] = ItemsTypeList[selectsecond];
            ItemsTypeList[selectsecond] = SwitchType;

            SwitchAmount = ItemsAmountList[select];
            ItemsAmountList[select] = ItemsAmountList[selectsecond];
            ItemsAmountList[selectsecond] = SwitchAmount;

            SwitchImage.sprite = IconList[select].sprite;
            IconList[select].sprite = IconList[selectsecond].sprite;
            IconList[selectsecond].sprite = SwitchImage.sprite;
        }
        if(ItemsTypeList[select] == ItemsTypeList[selectsecond] && select != selectsecond)
        {
            ItemsAmountList[selectsecond] = ItemsAmountList[selectsecond] + ItemsAmountList[select];
            if(ItemsAmountList[selectsecond] > 100)
            {
                ItemsAmountList[select] = ItemsAmountList[selectsecond] - 100;
            }
            if(ItemsAmountList[selectsecond] < 100)
            {
                ItemsTypeList[select] = 0;
                ItemsAmountList[select] = 0;
            }
        }
        select2 = false;
        selected = false;
        if(ItemsAmountList[selectsecond] == 0 || ItemsTypeList[selectsecond] == 0)
        {
            AmountList[selectsecond].text = "";
            IconList[selectsecond].color = new Color(IconList[selectsecond].color.r, IconList[selectsecond].color.g, IconList[selectsecond].color.b, 0f);
        }
        if (ItemsAmountList[select] == 0 || ItemsTypeList[select] == 0)
        {
            AmountList[selectsecond].text = "";
            IconList[select].color = new Color(IconList[select].color.r, IconList[select].color.g, IconList[select].color.b, 0f);
        }

        if (ItemsAmountList[selectsecond] != 0 || ItemsTypeList[selectsecond] != 0)
        {
            IconList[selectsecond].color = new Color(IconList[selectsecond].color.r, IconList[selectsecond].color.g, IconList[selectsecond].color.b, 100f);
        }
        if (ItemsAmountList[select] != 0 || ItemsTypeList[select] != 0)
        {
            IconList[select].color = new Color(IconList[select].color.r, IconList[select].color.g, IconList[select].color.b, 100f);
        }

    }
    public void Nvm()
    {
        select2 = false;
        selected = false;
    }
    public void s1()
    {

        if(select2 == true && selected == false)
        {
            selectsecond2 = true;
            selectsecond = 0;
            Select();
            selected = true;
        }
        if (select2 == false && selected == false)
        {
            select = 0;
            select2 = true;
            selected = true;
        }
        selected = false;
    }

    public void s2()
    {
        if (select2 == true && selected == false)
        {
            selectsecond2 = true;
            selectsecond = 1;
            Select();
            selected = true;
        }
        if (select2 == false && selected == false)
        {
            select = 1;
            select2 = true;
            selected = true;
        }
        selected = false;
    }
    public void s3()
    {
        if (select2 == true && selected == false)
        {
            selectsecond2 = true;
            selectsecond = 2;
            Select();
            selected = true;
        }
        if (select2 == false && selected == false)
        {
            select = 2;
            select2 = true;
            selected = true;
        }
        selected = false;
    }
    public void s4()
    {
        if (select2 == true && selected == false)
        {
            selectsecond2 = true;
            selectsecond = 3;
            Select();
            selected = true;
        }
        if (select2 == false && selected == false)
        {
            select = 3;
            select2 = true;
            selected = true;
        }
        selected = false;
    }
    public void s5()
    {
        if (select2 == true && selected == false)
        {
            selectsecond2 = true;
            selectsecond = 4;
            Select();
            selected = true;
        }
        if (select2 == false && selected == false)
        {
            select = 4;
            select2 = true;
            selected = true;
        }
        selected = false;
    }
    public void s6()
    {
        if (select2 == true && selected == false)
        {
            selectsecond2 = true;
            selectsecond = 5;
            Select();
            selected = true;
        }
        if (select2 == false && selected == false)
        {
            select = 5;
            select2 = true;
            selected = true;
        }
        selected = false;
    }
    public void s7()
    {
        if (select2 == true && selected == false)
        {
            selectsecond2 = true;
            selectsecond = 6;
            Select();
            selected = true;
        }
        if (select2 == false && selected == false)
        {
            select = 6;
            select2 = true;
            selected = true;
        }
        selected = false;
    }
    public void s8()
    {
        if (select2 == true && selected == false)
        {
            selectsecond2 = true;
            selectsecond = 7;
            Select();
            selected = true;
        }
        if (select2 == false && selected == false)
        {
            select = 7;
            select2 = true;
            selected = true;
        }
        selected = false;
    }
    public void s9()
    {
        if (select2 == true && selected == false)
        {
            selectsecond2 = true;
            selectsecond = 8;
            Select();
            selected = true;
        }
        if (select2 == false && selected == false)
        {
            select = 8;
            select2 = true;
            selected = true;
        }
        selected = false;
    }
    public void s10()
    {
        if (select2 == true && selected == false)
        {
            selectsecond2 = true;
            selectsecond = 9;
            Select();
            selected = true;
        }
        if (select2 == false && selected == false)
        {
            select = 9;
            select2 = true;
            selected = true;
        }
        selected = false;
    }
    public void s11()
    {
        if (select2 == true && selected == false)
        {
            selectsecond2 = true;
            selectsecond = 10;
            Select();
            selected = true;
        }
        if (select2 == false && selected == false)
        {
            select = 10;
            select2 = true;
            selected = true;
        }
        selected = false;
    }
    public void s12()
    {
        if (select2 == true && selected == false)
        {
            selectsecond2 = true;
            selectsecond = 11;
            Select();
            selected = true;
        }
        if (select2 == false && selected == false)
        {
            select = 11;
            select2 = true;
            selected = true;
        }
        selected = false;
    }
    public void s13()
    {
        if (select2 == true && selected == false)
        {
            selectsecond2 = true;
            selectsecond = 12;
            Select();
            selected = true;
        }
        if (select2 == false && selected == false)
        {
            select = 12;
            select2 = true;
            selected = true;
        }
        selected = false;
    }
    public void s14()
    {
        if (select2 == true && selected == false)
        {
            selectsecond2 = true;
            selectsecond = 13;
            Select();
            selected = true;
        }
        if (select2 == false && selected == false)
        {
            select = 13;
            select2 = true;
            selected = true;
        }
        selected = false;
    }
    public void s15()
    {
        if (select2 == true && selected == false)
        {
            selectsecond2 = true;
            selectsecond = 14;
            Select();
            selected = true;
        }
        if (select2 == false && selected == false)
        {
            select = 14;
            select2 = true;
            selected = true;
        }
        selected = false;
    }
    public void s16()
    {
        if (select2 == true && selected == false)
        {
            selectsecond2 = true;
            selectsecond = 15;
            Select();
            selected = true;
        }
        if (select2 == false && selected == false)
        {
            select = 15;
            select2 = true;
            selected = true;
        }
        selected = false;
    }
    public void s17()
    {
        if (select2 == true && selected == false)
        {
            selectsecond2 = true;
            selectsecond = 16;
            Select();
            selected = true;
        }
        if (select2 == false && selected == false)
        {
            select = 16;
            select2 = true;
            selected = true;
        }
        selected = false;
    }
    public void s18()
    {
        if (select2 == true && selected == false)
        {
            selectsecond2 = true;
            selectsecond = 17;
            Select();
            selected = true;
        }
        if (select2 == false && selected == false)
        {
            select = 17;
            select2 = true;
            selected = true;
        }
        selected = false;
    }
    public void s19()
    {
        if (select2 == true && selected == false)
        {
            selectsecond2 = true;
            selectsecond = 18;
            Select();
            selected = true;
        }
        if (select2 == false && selected == false)
        {
            select = 18;
            select2 = true;
            selected = true;
        }
        selected = false;
    }
    public void s20()
    {
        if (select2 == true && selected == false)
        {
            selectsecond2 = true;
            selectsecond = 19;
            Select();
            selected = true;
        }
        if (select2 == false && selected == false)
        {
            select = 19;
            select2 = true;
            selected = true;
        }
        selected = false;
    }
    public void s21()
    {
        if (select2 == true && selected == false)
        {
            selectsecond2 = true;
            selectsecond = 20;
            Select();
            selected = true;
        }
        if (select2 == false && selected == false)
        {
            select = 20;
            select2 = true;
            selected = true;
        }
        selected = false;
    }
    public void s22()
    {
        if (select2 == true && selected == false)
        {
            selectsecond2 = true;
            selectsecond = 21;
            Select();
            selected = true;
        }
        if (select2 == false && selected == false)
        {
            select = 21;
            select2 = true;
            selected = true;
        }
        selected = false;
    }
    public void s23()
    {
        if (select2 == true && selected == false)
        {
            selectsecond2 = true;
            selectsecond = 22;
            Select();
            selected = true;
        }
        if (select2 == false && selected == false)
        {
            select = 22;
            select2 = true;
            selected = true;
        }
        selected = false;
    }
    public void s24()
    {
        if (select2 == true && selected == false)
        {
            selectsecond2 = true;
            selectsecond = 23;
            Select();
            selected = true;
        }
        if (select2 == false && selected == false)
        {
            select = 23;
            select2 = true;
            selected = true;
        }
        selected = false;
    }
    public void s25()
    {
        if (select2 == true && selected == false)
        {
            selectsecond2 = true;
            selectsecond = 24;
            Select();
            selected = true;
        }
        if (select2 == false && selected == false)
        {
            select = 24;
            select2 = true;
            selected = true;
        }
        selected = false;
    }
    public void s26()
    {
        if (select2 == true && selected == false)
        {
            selectsecond2 = true;
            selectsecond = 25;
            Select();
            selected = true;
        }
        if (select2 == false && selected == false)
        {
            select = 25;
            select2 = true;
            selected = true;
        }
        selected = false;
    }
    public void s27()
    {
        if (select2 == true && selected == false)
        {
            selectsecond2 = true;
            selectsecond = 26;
            Select();
            selected = true;
        }
        if (select2 == false && selected == false)
        {
            select = 26;
            select2 = true;
            selected = true;
        }
        selected = false;
    }
    public void s28()
    {
        if (select2 == true && selected == false)
        {
            selectsecond2 = true;
            selectsecond = 27;
            Select();
            selected = true;
        }
        if (select2 == false && selected == false)
        {
            select = 27;
            select2 = true;
            selected = true;
        }
        selected = false;
    }


 
}
