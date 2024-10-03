using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemBase : MonoBehaviour
{
    public string itemname;
    public int itemprice;
    public string iteminfo;
    public bool itemunlock;
    public bool itempurchased;

    public ItemBase(string _name = "GameClearItem", int _price = 0, string _info = "Info:GameClearItem", bool _unlock = false, bool _itempurchased = false)
    {
        itemname = _name;
        itemprice = _price;
        iteminfo = _info;
        itemunlock = _unlock;
        itempurchased= _itempurchased;
    }
    public virtual void Use() 
    {
        itempurchased = true;
    }
}
