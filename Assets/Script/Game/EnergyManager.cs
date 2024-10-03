using Michsky.UI.Heat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyManager : MonoBehaviour
{
    public int energy;

    [SerializeField] ButtonManager energybutton;
    [SerializeField] GameObject scarcitytext;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        energybutton.buttonText = "Energy:" + energy.ToString();
        energybutton.UpdateUI();
        if (Input.GetKeyDown(KeyCode.F12))
        {
            energy = 999999;
        }
    }

    public void TakeEnergy(int _energy)
    {
        if (_energy > energy) return;
        energy -= _energy;
    }

    //w“ü‘O‚ÌŽcŠzŠm”F
    public bool SurplusTest(int _energy)
    {
        if (_energy > energy)
        {
            scarcitytext.SetActive(true);
            return false;
        }
        else
        {
            energy -= _energy;
            return true;
        }
    }
}
