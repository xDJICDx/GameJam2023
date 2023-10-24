using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    public bool ShopOnOrOf = false;

    public int SnailCount = 0;



    void Start()
    {
        ShopColor1 = ShopImage1.color;

        ShopImage1.color = new Color(0, 0, 0, 0);
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

    public void SnailCaught()
    {
        SnailCount++;
    }
}
