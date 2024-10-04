using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopInformationWindow : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Animator animator;

    string iteminfo="";

    private void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        text.text=iteminfo;
    }

    public void SetIteminfo(string _info)
    {
        iteminfo = _info;
    }

    public void TurnOffThisWindow()
    {
        //animator.Play("Out");
        text.text = "item.iteminfo";
        this.gameObject.SetActive(false);
    }
}
