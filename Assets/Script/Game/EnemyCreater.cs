using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemyCreater : MonoBehaviour
{
    [SerializeField] GameObject zombieprefab;
    [SerializeField] GameObject flyenemyboomprefab;
    [SerializeField] GameObject flyenemyshootprefab;
    [SerializeField] GameObject managers;

    List<int> enemylist = new List<int>();
    int stagenum = 0;
    int stageenemynum = 0;

    [SerializeField] bool isflyenemycanbecreated = false;
    int killedenemy = 0;
    [SerializeField] int createenemy = 0;

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
            GenerateEnemy(zombieprefab);
            stageenemynum--;
        }

        if (killedenemy > 100)
        {
            isflyenemycanbecreated = true;
        }
        if(createenemy > 10) 
        {
            GenerateEnemy(flyenemyboomprefab);
            GenerateEnemy(flyenemyboomprefab);
            GenerateEnemy(flyenemyshootprefab);
            createenemy = 0;
        }

        //if (stageenemynum == 0 && enemycounter.enemycleared)
        //{
        //    enemylist.Add(enemylist[stagenum] + 50);
        //    stagenum++;
        //    stageenemynum = enemylist[stagenum];
        //}
    }
    void GenerateEnemy(GameObject _prefab)
    {
        int random = Random.Range(0, createpoint.Count);
        GameObject newObj = Instantiate(_prefab, createpoint[random].position, Quaternion.identity);

        if (isflyenemycanbecreated) createenemy++;

        EnemyHP enemyhp = newObj.GetComponent<EnemyHP>();
        enemyhp.OnDestroyed += OnEnemyDestroyed;
    }
    void OnEnemyDestroyed()
    {
        energymanager.energy += 5;
        GenerateEnemy(zombieprefab);
        GenerateEnemy(zombieprefab);
        killedenemy++;
    }
}
