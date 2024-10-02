using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MachineTower : MonoBehaviour
{
    [SerializeField] GameObject towertop;
    [SerializeField] float warningradius = 20.0f;
    [SerializeField] List<GameObject> enemyinwarning;
    public bool hastarget;
    public Vector3 targetpos;

    // Start is called before the first frame update
    void Start()
    {
        towertop = transform.Find("MachineTowerTop").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        EnemySearch();
        TowerAiming();
        hastarget = (EnemyDistanceComopute() != null);
        if (hastarget) targetpos = EnemyDistanceComopute().transform.position;
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
    GameObject EnemyDistanceComopute()
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
        if (EnemyDistanceComopute() != null)
        {

            Vector3 targetPosition = new Vector3(EnemyDistanceComopute().transform.position.x, towertop.transform.position.y, EnemyDistanceComopute().transform.position.z);

            Vector3 direction = targetPosition - towertop.transform.position;

            Quaternion rotation = Quaternion.LookRotation(direction);

            towertop.transform.rotation = rotation;
        }
    }

}
