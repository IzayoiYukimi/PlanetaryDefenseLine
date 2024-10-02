using Michsky.UI.Heat;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SerifController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI SerifText;

    [SerializeField] SerifList serifList;

    [SerializeField] ButtonManager playercheckbutton1;
    [SerializeField] ButtonManager playercheckbutton2;

    [SerializeField] QuestItem messionitem;

    [SerializeField] EnemyCounter enemycounter;
    [SerializeField] EnemyCreater enemycreater;

    [SerializeField] GameObject tutorialenemy;
    [SerializeField] GameObject baseenemy;


    [SerializeField] Transform baseTPpoint;
    [SerializeField] GameObject canvasmask;

    PlayerInput playerinput;

    bool playerspeakcheck = false;

    bool[] playermovecheck = new bool[4] { false, false, false, false };
    bool playeraimingcheck = false;
    bool playerfirecheck = false;
    bool playershieldcharged = false;

    int playerchoice = 0;

    bool setmession = false;


    int ID = 0;
    float time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        serifList = GetComponent<SerifList>();
        time = serifList.seriflist[0].time;

        playerinput = GetComponentInParent<GameManager>().player.GetComponent<PlayerInput>();

        playercheckbutton1.gameObject.SetActive(false);
        playercheckbutton2.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        SetSerif();
        SerifEvent();
        if (Input.GetKeyDown(KeyCode.F1))
        {
            ID = 29;
        }
    }

    void SetSerif()
    {
        SerifText.text = $"<color=#ffff00>{serifList.seriflist[ID].sayername}</color>{serifList.seriflist[ID].text}";
    }

    void ChangeSerif()
    {
        ID++;
        time = serifList.seriflist[ID].time;
    }

    public bool GetPlayerspeakcheck()
    {
        return playerspeakcheck;
    }

    public void PlayerSpeaked()
    {
        if (serifList.seriflist[ID].serifeventnumber == 8) playerchoice = 1;
        else playerspeakcheck = true;
    }

    bool PlayerMoveCheck()
    {
        if (playerinput.move.x == 1) playermovecheck[0] = true;
        if (playerinput.move.x == -1) playermovecheck[1] = true;
        if (playerinput.move.z == 1) playermovecheck[2] = true;
        if (playerinput.move.z == -1) playermovecheck[3] = true;

        int _check = 0;

        for (int i = 0; i < playermovecheck.Length; i++)
        {
            if (playermovecheck[i]) _check++;
        }

        if (_check == playermovecheck.Length) return true;
        else return false;
    }

    bool PlayerAimingCheck()
    {
        if (playerinput.aiming)
        {
            playeraimingcheck = true;
        }
        return playeraimingcheck;
    }

    bool PlayerFireCheck()
    {
        if (playerinput.aiming && playerinput.attack)
        {
            playerfirecheck = true;
        }
        return playerfirecheck;
    }

    bool PlayerShieldCharge()
    {
        if (playerinput.shiledcharge)
        {
            playershieldcharged = true;
        }
        return playershieldcharged;
    }

    public void PlayerChoiceOther()
    {
        if (serifList.seriflist[ID].serifeventnumber == 8) playerchoice = 2;

    }
    void SerifEvent()
    {
        if (time < 0.0f)
        {
            switch (serifList.seriflist[ID].serifeventnumber)
            {
                case 0:
                    ChangeSerif();
                    break;
                case 1:
                    {
                        if (playerspeakcheck)
                        {
                            playercheckbutton1.gameObject.SetActive(false);
                            playerspeakcheck = false;
                            ChangeSerif();
                        }
                        else
                        {
                            playercheckbutton1.gameObject.SetActive(true);
                            playercheckbutton1.SetText(serifList.seriflist[ID].buttontext);
                        }
                    }
                    break;
                case 2:
                    {
                        if (!setmession)
                        {
                            messionitem.questText = "WASDキーで移動してみる";
                            messionitem.AnimateQuest();
                            setmession = true;
                        }
                        if (PlayerMoveCheck())
                        {
                            ChangeSerif();
                            messionitem.MinimizeQuest();
                            setmession = false;
                        }
                    }
                    break;
                case 3:
                    {
                        if (!setmession)
                        {
                            messionitem.questText = "右キーで照準する";
                            messionitem.AnimateQuest();
                            setmession = true;
                        }
                        if (PlayerAimingCheck())
                        {
                            ChangeSerif();
                            messionitem.MinimizeQuest();
                            setmession = false;
                        }
                    }
                    break;
                case 4:
                    {
                        if (!setmession)
                        {
                            messionitem.questText = "照準中で左クリックするとショット";
                            messionitem.AnimateQuest();
                            setmession = true;
                        }
                        if (PlayerFireCheck())
                        {
                            ChangeSerif();
                            messionitem.MinimizeQuest();
                            setmession = false;
                        }
                    }
                    break;
                case 5:
                    {
                        if (!setmession)
                        {
                            messionitem.questText = "Fキーでバッテリー拾ってQキーでシールドチャージ";
                            messionitem.AnimateQuest();
                            setmession = true;
                        }
                        if (PlayerShieldCharge())
                        {
                            ChangeSerif();
                            messionitem.MinimizeQuest();
                            setmession = false;
                        }
                    }
                    break;
                case 6:
                    {
                        tutorialenemy.SetActive(true);
                        ChangeSerif();
                    }
                    break;
                case 7:
                    {
                        if (!setmession)
                        {
                            messionitem.questText = "近づく敵を撃退してください（ホイールでズームコントロール）";
                            messionitem.AnimateQuest();
                            setmession = true;
                        }
                        if (enemycounter.enemycleared)
                        {
                            ChangeSerif();
                            messionitem.MinimizeQuest();
                            setmession = false;
                        }
                    }
                    break;
                case 8:
                    {
                        if (playerchoice == 1)
                        {
                            playercheckbutton1.gameObject.SetActive(false);
                            playercheckbutton2.gameObject.SetActive(false);
                            playerchoice = 0;
                            ChangeSerif();
                            ChangeSerif();
                        }
                        else if (playerchoice == 2)
                        {
                            playercheckbutton1.gameObject.SetActive(false);
                            playercheckbutton2.gameObject.SetActive(false);
                            playerchoice = 0;
                            ChangeSerif();
                        }
                        else
                        {
                            playercheckbutton1.gameObject.SetActive(true);
                            playercheckbutton2.gameObject.SetActive(true);
                            playercheckbutton1.SetText("この声に返事する");
                            playercheckbutton2.SetText("この声に返事しない");
                        }
                    }
                    break;//選択肢
                case 9:
                    {
                        if (playerspeakcheck)
                        {
                            canvasmask.SetActive(true);
                            playercheckbutton1.gameObject.SetActive(false);
                            playerspeakcheck = false;
                            baseenemy.SetActive(true);
                            ChangeSerif();
                        }
                        else
                        {
                            playercheckbutton1.gameObject.SetActive(true);
                            playercheckbutton1.SetText(serifList.seriflist[ID].buttontext);
                        }
                    }
                    break;
                case 10:
                    {
                        if (!setmession)
                        {
                            playerinput.transform.position = baseTPpoint.position;
                            messionitem.questText = "基地近くの敵をクリアする（Fキーでゲート開く）";
                            messionitem.AnimateQuest();
                            setmession = true;
                        }
                        if (enemycounter.enemycleared)
                        {
                            ChangeSerif();
                            messionitem.MinimizeQuest();
                            setmession = false;
                        }
                    }
                    break;
                case 11:
                    {
                        if (!setmession)
                        {
                            messionitem.questText = "なるべく生き残る";
                            messionitem.AnimateQuest();
                            setmession = true;
                            enemycreater.enabled = true;
                        }
                        //if (enemycounter.enemycleared)
                        //{
                        //    ChangeSerif();
                        //    messionitem.MinimizeQuest();
                        //    setmession = false;
                        //}
                    }
                    break;
            }
        }
    }





}
