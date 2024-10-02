using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillsUI : MonoBehaviour
{
    [SerializeField] GameManager gamemanager;

    [SerializeField] SkillIcon shieldcharge;
    [SerializeField] TextMeshProUGUI shiledbatterycount;
    [SerializeField] SkillIcon skill1;
    [SerializeField] SkillIcon skill2;

    PlayerSkill playerskill;

    // Start is called before the first frame update
    void Start()
    {
        playerskill= gamemanager.player.GetComponent<PlayerSkill>();
    }

    // Update is called once per frame
    void Update()
    {
        shieldcharge.fillamount = playerskill.nowshieldchargeCD / playerskill.shieldchargeCD;

        skill1.ishighlight = !playerskill.isusingskill1 ? false : true;
        skill2.ishighlight = !playerskill.isusingskill2 ? false : true;

        shiledbatterycount.text = playerskill.item[0].ToString();
    }
}
