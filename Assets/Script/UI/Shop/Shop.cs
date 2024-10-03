using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] GameObject shopmenu;
    bool shopmenuactive;
    public void IsClicked()
    {
        shopmenuactive = !shopmenuactive;
    }

    private void Update()
    {
        shopmenu.SetActive(shopmenuactive);
    }
}
