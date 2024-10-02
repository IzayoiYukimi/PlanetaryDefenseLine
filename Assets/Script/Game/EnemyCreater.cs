using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemyCreater : MonoBehaviour
{
    [SerializeField] GameObject zombieprefab;
    [SerializeField] GameObject managers;

    List<int> enemylist = new List<int>();
    int stagenum = 0;
    int stageenemynum = 0;

    EnergyManager energymanager;
    EnemyCounter enemycounter;

    [SerializeField] List<Transform> createpoint = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        energymanager = managers.GetComponentInChildren<EnergyManager>();
        enemycounter = GetComponent<EnemyCounter>();
        enemylist.Add(50);
        stageenemynum = enemylist[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (stageenemynum > 0)
        {
            GenerateEnemy();
            stageenemynum--;
        }
        //if (stageenemynum == 0 && enemycounter.enemycleared)
        //{
        //    enemylist.Add(enemylist[stagenum] + 50);
        //    stagenum++;
        //    stageenemynum = enemylist[stagenum];
        //}
    }
    void GenerateEnemy()
    {
        int random = Random.Range(0, createpoint.Count);
        GameObject newObj = Instantiate(zombieprefab, createpoint[random].position, Quaternion.identity);

        EnemyHP enemyhp = newObj.GetComponent<EnemyHP>();
        enemyhp.OnDestroyed += OnEnemyDestroyed;
    }
    void OnEnemyDestroyed()
    {
        energymanager.energy += 5;
        GenerateEnemy();
        GenerateEnemy();
    }
}
