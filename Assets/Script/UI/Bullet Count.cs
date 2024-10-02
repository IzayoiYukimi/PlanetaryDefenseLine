using Michsky.UI.Heat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletCount : MonoBehaviour
{
    [SerializeField] PlayerWeapon playerweapon;
    ProgressBar bulletcountbar;


    // Start is called before the first frame update
    void Start()
    {
        bulletcountbar = GetComponent<ProgressBar>();
    }

    // Update is called once per frame
    void Update()
    {
        bulletcountbar.maxValue = playerweapon.maxbulletnum;
        bulletcountbar.SetValue(playerweapon.bulletnum);
    }
}
