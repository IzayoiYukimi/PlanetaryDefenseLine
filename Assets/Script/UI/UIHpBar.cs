using Michsky.UI.Heat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHpBar : MonoBehaviour
{
    [SerializeField] ProgressBar shieldbar;
    [SerializeField] ProgressBar healthbar;
    [SerializeField] PlayerHP playerhp;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        shieldbar.maxValue = playerhp.MaxShield;
        shieldbar.SetValue(playerhp.shield);

        healthbar.maxValue = playerhp.MaxHealth;
        healthbar.SetValue(playerhp.health);
    }
}
