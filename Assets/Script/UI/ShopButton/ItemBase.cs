using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase 
{
    public string Name;
    public int Price;
    public string Info;

    public virtual void Use()
    {
        Debug.Log(" Use Item : " + Name );
    }

}
