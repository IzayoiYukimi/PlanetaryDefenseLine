using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class LaserTower : MonoBehaviour
{
    [SerializeField] GameObject visuallaser;
    [SerializeField] GameObject gunpoint;
    bool isreload = false;

    float reloadtime = 0.0f;
    float attackspeed = 0.2f;

    [SerializeField] float warningradius = 30.0f;
    [SerializeField] List<GameObject> enemyinwarning;
    public bool hastarget;
    public Vector3 targetpos;

    [SerializeField] AudioSource audiosource_fire;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PowerCharge();
        EnemySearch();
        TowerAiming();
        hastarget = (ComputeEnemyDistance() != null);
        if (hastarget) targetpos = ComputeEnemyDistance().transform.position;

        if (hastarget && !isreload)
        {
            Fire();
        }
    }


    void EnemySearch()
    {
        enemyinwarning.Clear();

        Collider[] _enemys = Physics.OverlapSphere(transform.position, warningradius);
        foreach (var _enemy in _enemys)
        {
            if (_enemy.CompareTag("Enemy"))
            {
                enemyinwarning.Add(_enemy.gameObject);
            }
        }
    }

    //警戒範囲中の中に一番近い敵を返す
    GameObject ComputeEnemyDistance()
    {
        float _enemydistances = warningradius;
        GameObject _enemyobj = null;

        foreach (var _enemy in enemyinwarning)
        {
            if (_enemydistances > (_enemy.transform.position - transform.position).magnitude)
            {
                _enemydistances = (_enemy.transform.position - transform.position).magnitude;
                _enemyobj = _enemy;
            }
        }
        return _enemyobj;
    }

    void TowerAiming()
    {
        if (ComputeEnemyDistance() != null)
        {
            Vector3 targetPosition = new Vector3(ComputeEnemyDistance().transform.position.x, transform.position.y, ComputeEnemyDistance().transform.position.z);

            Vector3 direction = targetPosition - transform.position;

            Quaternion targetRotation = Quaternion.FromToRotation(transform.forward, direction);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation * transform.rotation, 2 * Time.deltaTime);

        }
    }



    void PowerCharge()
    {
        if (isreload)
        {
            reloadtime += Time.deltaTime;
            if (reloadtime >= 1f / attackspeed)
            {
                isreload = false;
                visuallaser.SetActive(false);
            }
        }
    }



    void Fire()
    {
        visuallaser.SetActive(true);
        isreload = true;
        reloadtime = 0f;
        audiosource_fire.Play();
        RaycastHit[] hits = Physics.SphereCastAll(gunpoint.transform.position, 2.0f, gunpoint.transform.forward, 30f);


        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                Debug.Log("Hit Enemy: " + hit.collider.name);
                hit.collider.GetComponent<EnemyHP>().TakeDamage(50);
            }
            else if (hit.collider.CompareTag("Wall")) break;
            else
            {
                Debug.Log("Hit: " + hit.collider.name);
            }
        }
    }

}
