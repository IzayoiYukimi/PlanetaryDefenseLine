using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTower : MonoBehaviour
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
        
    }
}
