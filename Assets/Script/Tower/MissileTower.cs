using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MissileTower : MonoBehaviour
{
    [SerializeField] GameObject towertop;

    [SerializeField] float warningradius = 40.0f;
    [SerializeField] List<GameObject> enemyinwarning;
    public bool hastarget;

    public GameObject[] target;
    // Start is called before the first frame update
    void Start()
    {
        towertop = transform.Find("TowerTop").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        EnemySearch();

        hastarget = ComputeEnemyDistance().Length > 0 ? true: false;
        if (hastarget)
        {
            target = ComputeEnemyDistance();
            TowerAiming();
        }

    }
    void EnemySearch()
    {
        enemyinwarning.Clear();

        Collider[] _enemys = Physics.OverlapSphere(transform.position, warningradius);
        foreach (var _enemy in _enemys)
        {
            if (_enemy.CompareTag("FlyEnemy"))
            {
                enemyinwarning.Add(_enemy.gameObject);
            }
        }
        if (enemyinwarning.Count == 0)
        {
            foreach (var _enemy in _enemys)
            {
                if (_enemy.CompareTag("Enemy"))
                {
                    enemyinwarning.Add(_enemy.gameObject);
                }
            }
        }
    }

    //警戒範囲中の中に一番近い敵を返す
    GameObject[] ComputeEnemyDistance()
    {
        List<KeyValuePair<GameObject, float>> enemyDistances = new List<KeyValuePair<GameObject, float>>();

        foreach (var _enemy in enemyinwarning)
        {
            float distance = (_enemy.transform.position - transform.position).magnitude;
            enemyDistances.Add(new KeyValuePair<GameObject, float>(_enemy, distance));
        }

        enemyDistances = enemyDistances.OrderBy(pair => pair.Value).ToList();

        GameObject[] topFourEnemies = enemyDistances.Take(4).Select(pair => pair.Key).ToArray();

        return topFourEnemies;
    }
    //タワートップ（武器）の回転
    void TowerAiming()
    {
        if (hastarget)
        {
            Vector3 targetPosition = new Vector3(ComputeEnemyDistance()[0].transform.position.x, towertop.transform.position.y, ComputeEnemyDistance()[0].transform.position.z);
            Vector3 direction = targetPosition - towertop.transform.position;
            Quaternion targetRotation = Quaternion.FromToRotation(towertop.transform.forward, direction);
            towertop.transform.rotation = Quaternion.Slerp(towertop.transform.rotation, targetRotation * towertop.transform.rotation, 2 * Time.deltaTime);

        }
    }
}
