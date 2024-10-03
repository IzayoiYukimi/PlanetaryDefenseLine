using Michsky.UI.Heat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopButtons : MonoBehaviour
{

    // item settings
    [SerializeField] List<ItemList> ItemData;

    ButtonManager thisbutton;

    [SerializeField] Image normalframe;

    // Start is called before the first frame update
    void Start()
    {
        thisbutton = GetComponent<ButtonManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BuyinTheIten()
    {
        normalframe.color = Color.blue;
        thisbutton.isInteractable = false;
    }
    public void Onclick() { 


    }
}

[System.Serializable]
public class ItemList
{
    public enum Item
    {
        // changed by scene
        AAA,
        BBB,
        CCC
        // add tags here
    }

    //public BGM bgm;
    //public AudioClip audioClip;
    //[Range(0, 1)]
    //public float volume = 1;
}