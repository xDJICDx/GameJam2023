using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class ShopMechenics : MonoBehaviour
{
    public TextMeshProUGUI SnailCountText;
    public Image ShopImage1;
    public Color ShopColor1;

    public PlayerMovement playerMovement;
    public SnailSpawner spawner;

    public bool ShopOnOrOf = false;
    public int SnailCount = 0;
    public int TotalSnailCount = 0;
    public int snailMarketing = 1;

    public int BuyAmountItem1 = 0;
    public int BuyAmountItem2 = 0;
    public int BuyAmountItem3 = 0;
    public int BuyAmountItem4 = 0;
    public int BuyAmountItem5 = 0;

    public int PriceItem1 = 5;
    public int PriceItem2 = 10;
    public int PriceItem3 = 15;
    public int PriceItem4 = 10;
    public int PriceItem5 = 50;

    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Button button6;

    public TextMeshProUGUI RebirthButtonText;

    public TextMeshProUGUI Button1UpgradeAmount;
    public TextMeshProUGUI Button2UpgradeAmount;
    public TextMeshProUGUI Button3UpgradeAmount;
    public TextMeshProUGUI Button4UpgradeAmount;
    public TextMeshProUGUI Button5UpgradeAmount;

    public TextMeshProUGUI Button1UpgradeCost;
    public TextMeshProUGUI Button2UpgradeCost;
    public TextMeshProUGUI Button3UpgradeCost;
    public TextMeshProUGUI Button4UpgradeCost;
    public TextMeshProUGUI Button5UpgradeCost;

    public int MinimalRebirthSnailCount = 100;
    public float rebirthMulti = 1;






    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("SnailSpawner").GetComponentInChildren<SnailSpawner>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerMovement>();
        ShopColor1 = ShopImage1.color;
        snailMarketing = 1;

        RebirthReset();
    }

    void Update()
    {
        SnailCountText.SetText(SnailCount.ToString());
        Button1UpgradeCost.SetText(PriceItem1.ToString());
        Button2UpgradeCost.SetText(PriceItem2.ToString());
        Button3UpgradeCost.SetText(PriceItem3.ToString());
        Button4UpgradeCost.SetText(PriceItem4.ToString());
        Button5UpgradeCost.SetText(PriceItem5.ToString());

        Button1UpgradeAmount.SetText(BuyAmountItem1.ToString() + "/10");
        Button2UpgradeAmount.SetText(BuyAmountItem2.ToString());
        Button3UpgradeAmount.SetText(BuyAmountItem3.ToString());
        Button4UpgradeAmount.SetText(BuyAmountItem4.ToString());
        Button5UpgradeAmount.SetText(BuyAmountItem5.ToString() + "/3");

        if(MinimalRebirthSnailCount > TotalSnailCount) 
        {
            RebirthButtonText.SetText("Rebirth: Requires " + MinimalRebirthSnailCount.ToString() +" Snails");
        } 
        else if(TotalSnailCount > MinimalRebirthSnailCount)
        {
            RebirthButtonText.SetText("Rebirth: " + 1 + (math.sqrt(TotalSnailCount) / 10) + " X multiplier");
        }

    }
    // Update is called once per frame
    public void ShopButtonPressed()
    {
        if (ShopOnOrOf)
        {
            hideShop();
            ShopOnOrOf = false;
        }
        else if (!ShopOnOrOf)
        {
            showShop();
            ShopOnOrOf = true;
        }
    }

    public void ButtonVanish(Button button)
    {
        button.image.color = new Color(1, 1, 1, 0);
        TextMeshProUGUI ButtonText = button.GetComponentInChildren<TextMeshProUGUI>();
        ButtonText.color = new Color(1,1,1,0);
    }

    public void ButtonApear(Button button)
    {
        button.image.color = new Color(1, 1, 1, 1);
        TextMeshProUGUI ButtonText = button.GetComponentInChildren<TextMeshProUGUI>();
        ButtonText.color = new Color (1,1,1,1);
    }

    public void BuyButton1()
    {
        if(SnailCount >= PriceItem1 && BuyAmountItem1 <= 10)
        {
            SnailCount -= PriceItem1;
            spawner.spawnTimer1 /= 1.25f;
            PriceItem1 *= 3;
            BuyAmountItem1++;
        }
    }

    public void BuyButton2()
    {
        if(SnailCount >= PriceItem2)
        {
            SnailCount -= PriceItem2;
            spawner.SpawnAmount++;
            PriceItem2 *= 3;
            BuyAmountItem2++;
        }
    }

    public void BuyButton3()
    {
        if(SnailCount >= PriceItem3)
        {
            SnailCount-= PriceItem3;
            snailMarketing++;
            PriceItem3 *= 2;
            BuyAmountItem3++;
        }
    }

    public void BuyButton4()
    {
        if (SnailCount >= PriceItem4)
        {
            SnailCount -= PriceItem4;
            spawner.MaxEntityLimit = math.round(spawner.MaxEntityLimit * 1.5f);
            PriceItem5 *= 5;
            BuyAmountItem4++;
        }
    }
    public void BuyButton5()
    {
        if(SnailCount >= PriceItem5 && BuyAmountItem5 <= 3)
        {
            SnailCount -= PriceItem5;
            playerMovement.ExtraSpeed *= 1.5f;
            PriceItem5 *= 2;
            BuyAmountItem5++;
        }
    }

    public void Rebirth()
    {
        if(TotalSnailCount > MinimalRebirthSnailCount)
        {
            rebirthMulti =1 + (math.sqrt(TotalSnailCount) / 10);
            MinimalRebirthSnailCount = TotalSnailCount;
            RebirthReset();
        }
    }

    public void RebirthReset()
    {

        PriceItem1 = 5;
        PriceItem2 = 10;
        PriceItem3 = 15;
        PriceItem4 = 10;
        PriceItem5 = 50;
        BuyAmountItem1 = 0;
        BuyAmountItem2 = 0;
        BuyAmountItem3 = 0;
        BuyAmountItem4 = 0;
        BuyAmountItem5 = 0;
        SnailCount = 0;
        TotalSnailCount = 0;
        snailMarketing = 1;
        spawner.SpawnAmount = 1;
        spawner.MaxEntityLimit = 20;
        playerMovement.ExtraSpeed = 1;

        ShopOnOrOf = false;
        hideShop();
    }

    public void SnailCaught()
    {
        SnailCount+= snailMarketing;
        TotalSnailCount += snailMarketing;
    }

    public void hideShop()
    {
        ButtonVanish(button1);
        ButtonVanish(button2);
        ButtonVanish(button3);
        ButtonVanish(button4);
        ButtonVanish(button5);
        ButtonVanish(button6);
        Button1UpgradeAmount.color = new Color(1, 1, 1, 0);
        Button2UpgradeAmount.color = new Color(1, 1, 1, 0);
        Button3UpgradeAmount.color = new Color(1, 1, 1, 0);
        Button4UpgradeAmount.color = new Color(1, 1, 1, 0);
        Button5UpgradeAmount.color = new Color(1, 1, 1, 0);
        Button1UpgradeCost.color = new Color(1, 1, 1, 0);
        Button2UpgradeCost.color = new Color(1, 1, 1, 0);
        Button3UpgradeCost.color = new Color(1, 1, 1, 0);
        Button4UpgradeCost.color = new Color(1, 1, 1, 0);
        Button5UpgradeCost.color = new Color(1, 1, 1, 0);
        ShopImage1.color = new Color(0, 0, 0, 0);
    }

    public void showShop()
    {
        ButtonApear(button1);
        ButtonApear(button2);
        ButtonApear(button3);
        ButtonApear(button4);
        ButtonApear(button5);
        ButtonApear(button6);
        Button1UpgradeAmount.color = new Color(0, 0, 0, 1);
        Button2UpgradeAmount.color = new Color(0, 0, 0, 1);
        Button3UpgradeAmount.color = new Color(0, 0, 0, 1);
        Button4UpgradeAmount.color = new Color(0, 0, 0, 1);
        Button5UpgradeAmount.color = new Color(0, 0, 0, 1);
        Button1UpgradeCost.color = new Color(0, 0, 0, 1);
        Button2UpgradeCost.color = new Color(0, 0, 0, 1);
        Button3UpgradeCost.color = new Color(0, 0, 0, 1);
        Button4UpgradeCost.color = new Color(0, 0, 0, 1);
        Button5UpgradeCost.color = new Color(0, 0, 0, 1);
        ShopImage1.color = ShopColor1;
    }
}
