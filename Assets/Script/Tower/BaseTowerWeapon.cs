using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class BaseTowerWeapon : MonoBehaviour
{
    [SerializeField] GameObject towerbulletprefab;
    [SerializeField] GameObject towertop;


    [SerializeField] Transform gunpoint1;
    [SerializeField] Transform gunpoint2;


    [SerializeField] List<AudioClip> basetowerSE;
    [SerializeField] AudioSource audiosourceFire;



    bool hastarget = false;


    float attackspeed = 5f;
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
        hastarget = GetComponent<BaseTower>().hastarget;
        TowerFire();
        AttackSpeedSet();
    }


    void TowerFire()
    {
        if (attackset && hastarget)
        {
            int random = Random.Range(0, basetowerSE.Count);
            audiosourceFire.clip = basetowerSE[random];
            audiosourceFire.Play();

            Vector3 _targetpos = GetComponent<BaseTower>().targetpos;
            _targetpos.y += 1.0f;//çÇÇ≥ÇÃîºï™

            GameObject _bullet1 = Instantiate(towerbulletprefab, gunpoint1.transform.position, towertop.transform.rotation * Quaternion.Euler(0, 180, 0));
            GameObject _bullet2 = Instantiate(towerbulletprefab, gunpoint2.transform.position, towertop.transform.rotation * Quaternion.Euler(0, 180, 0));
            _bullet1.GetComponent<PlayerBullet>().Direction = (_targetpos - gunpoint1.transform.position).normalized;
            _bullet2.GetComponent<PlayerBullet>().Direction = (_targetpos - gunpoint2.transform.position).normalized;

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
