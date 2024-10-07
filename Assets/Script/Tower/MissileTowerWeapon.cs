using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class MissileTowerWeapon : MonoBehaviour
{
    [SerializeField] GameObject missileprefab;
    [SerializeField] GameObject towertop;
    [SerializeField] GameObject towerguns;

    [SerializeField] Transform[] gunpoint = new Transform[4];
    [SerializeField] AudioSource audiosourceFire;


    bool hastarget = false;


    float attackspeed = 0.2f;
    float reloadtime;
    bool attackset = true;//cock


    // Start is called before the first frame update
    void Start()
    {
        towertop = transform.Find("TowerTop").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        hastarget = GetComponent<MissileTower>().hastarget;
        TowerFire();
        AttackSpeedSet();
    }


    void TowerFire()
    {
        if (attackset && hastarget)
        {
            audiosourceFire.Play();

            for (int i = 0; i < GetComponent<MissileTower>().target.Length; i++)
            {
                GameObject _missile = Instantiate(missileprefab, gunpoint[i].position, gunpoint[i].rotation);
                _missile.GetComponent<MissileController>().target = GetComponent<MissileTower>().target[i];
            }

            attackset = false;
            reloadtime = 0.0f;
        }
    }
    void AttackSpeedSet()
    {
        reloadtime += Time.deltaTime;

        if (reloadtime >= 1.0f / attackspeed)
        {
            attackset = true;
        }
    }
}
