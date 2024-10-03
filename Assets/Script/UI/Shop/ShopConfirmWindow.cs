using Michsky.UI.Heat;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class ShopConfirmWindow : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tmp;
    [SerializeField] ShopButtons theshopbutton;

    private void Start()
    {
        tmp.text = "このアイテムを　" + theshopbutton.item.itemprice.ToString() + "　の価格で購入してよろしいですか？";
    }

    public void SetTheShopButton(ShopButtons _theshopbutton)
    {
        theshopbutton = _theshopbutton;
    }

    public void YesButton()
    {
        theshopbutton.BuyinTheItem();
    }

    public void NoButton()
    {
        theshopbutton = null;
        this.gameObject.SetActive(false);
    }
}
