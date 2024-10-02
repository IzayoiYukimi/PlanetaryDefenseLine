using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BaseTower : MonoBehaviour
{
    [SerializeField] GameObject towertop;
    [SerializeField] float warningradius = 20.0f;
    [SerializeField] List<GameObject> enemyinwarning;
    public bool hastarget;
    public Vector3 targetpos;

    // Start is called before the first frame update
    void Start()
    {
        towertop = transform.Find("TowerTop").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        EnemySearch();
        TowerAiming();
        hastarget = (ComputeEnemyDistance() != null);
        if (hastarget) targetpos = ComputeEnemyDistance().transform.position;
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

    //タワートップ（武器）の回転
    void TowerAiming()
    {
        if (ComputeEnemyDistance() != null)
        {
            Vector3 targetPosition = new Vector3(ComputeEnemyDistance().transform.position.x, towertop.transform.position.y, ComputeEnemyDistance().transform.position.z);

            Vector3 direction = targetPosition - towertop.transform.position;

            Quaternion rotation = Quaternion.LookRotation(direction);

            towertop.transform.rotation = rotation;
        }
    }

}
