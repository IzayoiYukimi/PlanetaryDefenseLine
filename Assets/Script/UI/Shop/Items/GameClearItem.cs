using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameClearItem : ItemBase
{
    private void Start()
    {
        itemunlock = true;
    }
    public override void Use()
    {
        base.Use();
        Debug.Log(iteminfo);
    }
}
