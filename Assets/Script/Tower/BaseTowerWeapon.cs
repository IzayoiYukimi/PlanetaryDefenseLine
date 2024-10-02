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



    bool hastarger = false;


    float attackspeed = 5;
    float attacktime;
    bool attackset = true;//cock


    // Start is called before the first frame update
    void Start()
    {
        towertop = transform.Find("TowerTop").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        hastarger = GetComponent<BaseTower>().hastarget;
        TowerFire();
        AttackSpeedSet();
    }


    void TowerFire()
    {
        if (attackset && hastarger)
        {
            int random = Random.Range(0, basetowerSE.Count);
            audiosourceFire.clip = basetowerSE[random];
            audiosourceFire.Play();

            Vector3 _targetpos = GetComponent<BaseTower>().targetpos;
            _targetpos.y += 1.0f;//�����̔���

            GameObject _bullet1 = Instantiate(towerbulletprefab, gunpoint1.transform.position, towertop.transform.rotation * Quaternion.Euler(0, 180, 0));
            GameObject _bullet2 = Instantiate(towerbulletprefab, gunpoint2.transform.position, towertop.transform.rotation * Quaternion.Euler(0, 180, 0));
            _bullet1.GetComponent<PlayerBullet>().Direction = (_targetpos - gunpoint1.transform.position).normalized;
            _bullet2.GetComponent<PlayerBullet>().Direction = (_targetpos - gunpoint2.transform.position).normalized;

            attackset = false;
            attacktime = 0.0f;
        }
    }
    void AttackSpeedSet()
    {
        attacktime += Time.deltaTime;

        if (attacktime >= 1.0 / attackspeed)
        {
            attackset = true;
        }
    }
}
