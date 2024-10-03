using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearItem : ItemBase
{

    //void Init(string _name = null, int _price = 0, string _info = "NoInfo")
    //{
    //    Name = _name;
    //    Price = _price;
    //    Info = _info;
    //}

    void Init(string _name = "GameClearItem", int _price = 0, string _info = "Info:GameClearItem")
    {
        Name = _name;
        Price = _price;
        Info = _info;
    }

    public override void Use()
    {
        base.Use();
        Debug.Log(Name + Price + Info);
    }
}
