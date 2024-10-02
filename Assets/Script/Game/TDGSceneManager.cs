using Michsky.UI.Heat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDGSceneManager : MonoBehaviour
{
    [SerializeField]QuestItem missionUI;

    // Start is called before the first frame update
    void Start()
    {
        missionUI.AnimateQuest();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
