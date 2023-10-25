using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
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
    public int buyAmountItem5 = 0;

    public int PriceItem1 = 5;
    public int PriceItem2 = 15;
    public int PriceItem3 = 25;
    public int PriceItem4 = 10;
    public int PriceItem5 = 50;

    public int MinimalRebirthSnailCount = 100;
    public float rebirthMulti = 1;






    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("SnailSpawner").GetComponentInChildren<SnailSpawner>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerMovement>();
        ShopColor1 = ShopImage1.color;
        snailMarketing = 1;
    }

    void Update()
    {
        SnailCountText.SetText(SnailCount.ToString());
    }
    // Update is called once per frame
    public void ShopButtonPressed()
    {
        if (ShopOnOrOf)
        {
            ShopImage1.color = new Color(0, 0, 0, 0);
            ShopOnOrOf = false;
        }
        else if (!ShopOnOrOf)
        {
            ShopImage1.color = ShopColor1;
            ShopOnOrOf = true;
        }
    }

    public void BuyButton1()
    {
        if(SnailCount >= PriceItem1 && BuyAmountItem1 <= 10)
        {
            SnailCount -= PriceItem1;
            spawner.spawnTimer1 /= 1.25f;
            PriceItem1 *= 4;
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
        }
    }

    public void BuyButton3()
    {
        if(SnailCount >= PriceItem3)
        {
            SnailCount-= PriceItem3;
            snailMarketing++;
            PriceItem3 *= 2;
        }
    }

    public void BuyButton4()
    {
        if (SnailCount >= PriceItem4)
        {
            SnailCount -= PriceItem4;
            spawner.MaxEntityLimit = math.round(spawner.MaxEntityLimit * 1.5f);
            PriceItem5 *= 5;
        }
    }
    public void BuyButton5()
    {
        if(SnailCount >= PriceItem5)
        {
            SnailCount -= PriceItem5;
            playerMovement.ExtraSpeed *= 1.5f;
            PriceItem5 *= 2;
        }
    }

    public void Rebirth()
    {
        if(TotalSnailCount > MinimalRebirthSnailCount)
        {
            rebirthMulti =1 + (math.sqrt(TotalSnailCount) / 10);
            RebirthReset();
        }
    }

    public void RebirthReset()
    {

    }

    public void SnailCaught()
    {
        SnailCount+= snailMarketing;
        TotalSnailCount += snailMarketing;
    }
}
