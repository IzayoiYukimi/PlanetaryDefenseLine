using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TitleButtons : MonoBehaviour
{

    [SerializeField] Button newgamebutton;
    [SerializeField] Button exitgamebutton;

    TextMeshProUGUI newgametext;
    TextMeshProUGUI exitgametext;

    public bool gamestart = false;

    private void Start()
    {
        newgametext = newgamebutton.GetComponentInChildren<TextMeshProUGUI>();
        exitgametext = exitgamebutton.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void NewGameButtonPointerEnter()
    {
        newgametext.color = Color.yellow;
    }
    public void NewGameButtonPointerEixt()
    {
        newgametext.color = Color.white;
    }
    public void NewGameButtonClicked()
    {
        gamestart = true;
    }




    public void ExitGameButtonPointerEnter()
    {
        exitgametext.color = Color.yellow;
    }
    public void ExitGameButtonPointerEixt()
    {
        exitgametext.color = Color.white;
    }
    public void ExitGameButtonClicked()
    {
        Application.Quit();
    }



}
