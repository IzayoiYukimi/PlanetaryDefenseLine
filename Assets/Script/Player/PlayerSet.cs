using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class PlayerSet : MonoBehaviour
{
    [SerializeField] Transform raypos;
    [SerializeField] GameObject basetowerprefab;
    [SerializeField] GameObject towerindicator;

    PlayerInput playerinput;
    [SerializeField] LayerMask gorundlayer;

    public TowerIndicatorTrigger trigger;


    bool isbuildingmode = false;

    // Start is called before the first frame update
    void Start()
    {
        playerinput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        towerindicator.SetActive(isbuildingmode);
        




        if (towerindicator != null)
        {
            RaycastHit _hit;
            if (Physics.Raycast(raypos.position, Vector3.down, out _hit, 5.0f, gorundlayer))
            {
                towerindicator.transform.position = _hit.point;
                towerindicator.transform.rotation = Quaternion.LookRotation(transform.forward, _hit.normal);
            }
        }

    }


    public void ChangeBuildingMode(bool _mode)
    {
        if(!_mode) trigger.colliders.Clear();
        isbuildingmode = _mode;
    }

    public void SetTower()
    {
        Instantiate(basetowerprefab, towerindicator.transform.position, towerindicator.transform.rotation);
    }
}
