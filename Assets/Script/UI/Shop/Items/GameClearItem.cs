using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameClearItem : ItemBase
{
    [SerializeField] Shop shop;
    [SerializeField] GameObject rocket;
    private void Start()
    {
        itemunlock = true;
    }

    //Use()çƒíËã`
    public override void Use()
    {
        base.Use();
        Debug.Log(iteminfo);
        rocket.GetComponent<RocketAnimationEvent>().GameClear();
        shop.shopmenuactive = false;
    }
}
