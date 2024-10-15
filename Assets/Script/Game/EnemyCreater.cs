using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemyCreater : MonoBehaviour
{
    [SerializeField] GameObject managers;

    [SerializeField] List<GameObject> zombielist;
    [SerializeField] List<GameObject> canusezombielist;

    [SerializeField] List<GameObject> flyboomlist;
    [SerializeField] List<GameObject> canuseflyboomlist;

    [SerializeField] List<GameObject> flyshootlist;
    [SerializeField] List<GameObject> canuseflyshootlist;

    [SerializeField] GameObject zombieobjectpool;
    [SerializeField] GameObject flyboomobjectpool;
    [SerializeField] GameObject flyshootobjectpool;


    bool isinauguralenemycreated = false;

    [SerializeField] bool isflyenemycanbecreated = false;
    int killedenemy = 0;
    [SerializeField] int createenemy = 0;

    EnergyManager energymanager;

    [SerializeField] List<Transform> createpoint = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        energymanager = managers.GetComponentInChildren<EnergyManager>();

        SetEnemyList(zombielist, zombieobjectpool, "Enemy");
        SetEnemyList(flyboomlist, flyboomobjectpool, "FlyEnemy");
        SetEnemyList(flyshootlist, flyshootobjectpool, "FlyEnemy");
    }

    void SetEnemyList(List<GameObject> _list, GameObject _objectpool, string enemytag)
    {
        Transform[] _enemys = _objectpool.GetComponentsInChildren<Transform>(true);
        foreach (var _enemy in _enemys)
        {
            if (_enemy.CompareTag(enemytag))
            {
                _list.Add(_enemy.gameObject);
            }
        }
    }

    void UpdateCanuseEnemyList(List<GameObject> _canuselist, List<GameObject> _list)
    {
        _canuselist.Clear();
        foreach (var _enemy in _list)
        {
            if (!_enemy.activeSelf)
            {
                _canuselist.Add(_enemy.gameObject);
            }
        }
    }



    // Update is called once per frame
    void Update()
    {
        UpdateCanuseEnemyList(canusezombielist, zombielist);
        UpdateCanuseEnemyList(canuseflyboomlist, flyboomlist);
        UpdateCanuseEnemyList(canuseflyshootlist, flyshootlist);

        if (!isinauguralenemycreated && canusezombielist.Count > 50)
        {
            for (int i = 0; i < 50; ++i)
            {
                GenerateEnemy(canusezombielist, zombielist);
            }
            isinauguralenemycreated = true;
        }


        if (killedenemy > 100)
        {
            isflyenemycanbecreated = true;
        }
        if (createenemy > 10)
        {
            GenerateEnemy(canuseflyboomlist, flyboomlist);
            GenerateEnemy(canuseflyshootlist, flyshootlist);
            GenerateEnemy(canuseflyshootlist, flyshootlist);
            createenemy = 0;
            Debug.Log("CreateFlyEnemy");
        }







    }
    void GenerateEnemy(List<GameObject> _canuselist, List<GameObject> _list)
    {
        if (_canuselist.Count > 0)
        {
            int random = Random.Range(0, createpoint.Count);
            _canuselist[0].transform.position = createpoint[random].position;
            _canuselist[0].SetActive(true);

            if (_canuselist[0].GetComponent<ZombieController>() != null)
            {
                EnemyHP _enemyhp = _canuselist[0].GetComponent<EnemyHP>();
                _enemyhp.OnDestroyed += OnEnemyDestroyed;
            }
            if (isflyenemycanbecreated) createenemy++;
            UpdateCanuseEnemyList(_canuselist, _list);
            Debug.Log("created an enemy");
        }
        else Debug.Log("No more enemy");
    }


    void OnEnemyDestroyed()
    {
        energymanager.energy += 5;
        if (canusezombielist.Count > 0)
        {
            GenerateEnemy(canusezombielist, zombielist);
            GenerateEnemy(canusezombielist, zombielist);
        }
        else GenerateEnemy(canusezombielist, zombielist);

        killedenemy++;
    }
}
