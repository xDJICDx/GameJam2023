using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class ShopMechenics : MonoBehaviour
{
    public Image ShopImage1;
    public Image ShopImage2;

    public Color ShopColor1;
    public Color ShopColor2;

    public bool ShopOnOrOf = false;



    void Start()
    {
        ShopColor1 = ShopImage1.color;
        ShopColor2 = ShopImage2.color;

        ShopImage1.color = new Color(0, 0, 0, 0);
        ShopImage2.color = new Color(0, 0, 0, 0);
    }

    // Update is called once per frame
    public void ShopButtonPressed()
    {
        if (ShopOnOrOf)
        {
            ShopImage1.color = new Color(0, 0, 0, 0);
            ShopImage2.color = new Color(0, 0, 0, 0);
            ShopOnOrOf = false;
        }
        else if (!ShopOnOrOf)
        {
            ShopImage1.color = ShopColor1;
            ShopImage2.color = ShopColor2;
            ShopOnOrOf = true;
        }
    }
}
