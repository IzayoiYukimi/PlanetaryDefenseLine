using Michsky.UI.Heat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopButtons : MonoBehaviour
{

    public ItemBase item;
    BoxButtonManager thisbutton;
    EnergyManager energyManager;

    [SerializeField] GameObject managers;
    [SerializeField] Image normalframe;
    [SerializeField] GameObject confirmwindow;

    // Start is called before the first frame update
    void Start()
    {
        thisbutton = GetComponent<BoxButtonManager>();
        energyManager = managers.GetComponentInChildren<EnergyManager>();
    }

    private void Update()
    {
        if(!item.itemunlock) thisbutton.SetInteractable(false);
        else
        {
            thisbutton.SetInteractable(!item.itempurchased);
        }
    }


    public void Confirm()
    {
        confirmwindow.SetActive(true);
        confirmwindow.GetComponent<ShopConfirmWindow>().SetTheShopButton(this);
    }

    public void BuyinTheItem()
    {
        if(energyManager.SurplusTest(item.itemprice))
        {
            normalframe.color = Color.yellow;
            item.Use();
            thisbutton.UpdateUI();
            energyManager.TakeEnergy(item.itemprice);
            confirmwindow.SetActive(false);
        }
       
    }
}