using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    [SerializeField] GameObject managers;
    [SerializeField] GameObject updatemenu;
    [SerializeField] Transform raycastpos;

    EnergyManager energymanager;
    PlayerInput playerinput;
    PlayerHP playerhp;
    PickRange pickrange;
    PlayerSet playerset;
    Animator animator;

    [SerializeField] GameObject targetBasetower;

    [SerializeField] GameObject machinetowerprefab;
    [SerializeField] GameObject missiletowerprefab;
    [SerializeField] GameObject lasertowerprefab;


    public BaseTower skill2targettower;


    public int[] item = new int[3] { 0, 0, 0 };


    public float nowshieldchargeCD = 0.0f;
    public float shieldchargeCD = 5.0f;


    public bool overpickup = true;

    public bool isusingskill = false;
    public bool isusingskill1 = false;
    public bool isusingskill2 = false;

    public bool israyget = false;

    // Start is called before the first frame update
    void Start()
    {
        playerinput = GetComponent<PlayerInput>();
        playerhp = GetComponent<PlayerHP>();
        pickrange = GetComponentInChildren<PickRange>();
        playerset = GetComponent<PlayerSet>();
        animator = GetComponent<Animator>();

        energymanager = managers.GetComponentInChildren<EnergyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        CDCounter();
        isusingskill = (isusingskill1 || isusingskill2);

        if (!isusingskill && playerinput.use) PickItem();

        if (playerinput.shiledcharge) ShieldCharge();

        if (playerinput.useitem1) PlayerPress1();
        if (playerinput.useitem2) PlayerPress2();


        PlayerSkill1();
        PlayerSkill2();
    }


    void CDCounter()
    {
        if (nowshieldchargeCD >= shieldchargeCD) nowshieldchargeCD = shieldchargeCD;
        else nowshieldchargeCD += Time.deltaTime;
    }
    //シールドバッテリーが持ってるとき＆シールド未満＆冷却完了時シールドチャージ
    void ShieldCharge()
    {
        if (item[0] > 0 && playerhp.shield < playerhp.MaxShield && nowshieldchargeCD >= shieldchargeCD)
        {
            nowshieldchargeCD = 0.0f;
            playerhp.ChargeShield(20);
            playerinput.shiledcharge = false;
            item[0]--;
        }
    }
    void PlayerPress1()
    {
        isusingskill1 = !isusingskill1;
        playerinput.useitem1 = false;
    }

    void PlayerSkill1()
    {
        playerset.ChangeBuildingMode(isusingskill1);
        if (isusingskill1)
        {
            if (playerinput.use && playerset.trigger.canset)
            {
                if (energymanager.SurplusTest(100))
                {
                    playerset.SetTower();
                    isusingskill1 = false;
                }
            }
        }
    }

    void PlayerPress2()
    {
        if (!isusingskill2)
        {
            if (israyget)
            {
                isusingskill2 = !isusingskill2;
                playerinput.useitem2 = false;
                skill2targettower = targetBasetower == null ? null : targetBasetower.GetComponent<BaseTower>();
            }
        }
        else
        {
            isusingskill2 = !isusingskill2;
            playerinput.useitem2 = false;
            skill2targettower = null;
        }
    }
    void PlayerSkill2()
    {
        updatemenu.SetActive(isusingskill2);
        RaycastHit hit;
        israyget = false;
        targetBasetower = null;
        if (Physics.Raycast(raycastpos.position, transform.forward, out hit, 2.0f))
        {
            if (hit.collider.CompareTag("BaseTower"))
            {
                israyget = true;
                targetBasetower = hit.collider.gameObject;
            }
        }
    }
    //タワーアップデート
    public void UpdateToMachineTower()
    {
        if(energymanager.SurplusTest(200))
        {
            Instantiate(machinetowerprefab, skill2targettower.gameObject.transform.position, skill2targettower.gameObject.transform.rotation);
            isusingskill2 = false;
            Destroy(skill2targettower.gameObject);
            energymanager.TakeEnergy(200);
        }
    }
    public void UpdateToMissileTower()
    {
        if (energymanager.SurplusTest(400))
        {
            Instantiate(missiletowerprefab, skill2targettower.gameObject.transform.position, skill2targettower.gameObject.transform.rotation);
            isusingskill2 = false;
            Destroy(skill2targettower.gameObject);
            energymanager.TakeEnergy(400);
        }
    }
    public void UpdateToLaserTower()
    {
        if (energymanager.SurplusTest(400))
        {
            Instantiate(lasertowerprefab, skill2targettower.gameObject.transform.position, skill2targettower.gameObject.transform.rotation);
            isusingskill2 = false;
            Destroy(skill2targettower.gameObject);
            energymanager.TakeEnergy(400);
        }
    }

    void PickItem()
    {
        if (!pickrange.anyiteminrange) return;
        if (!overpickup) return;
        animator.SetTrigger("Pickup");
        playerinput.use = false;
        overpickup = false;
    }

}
