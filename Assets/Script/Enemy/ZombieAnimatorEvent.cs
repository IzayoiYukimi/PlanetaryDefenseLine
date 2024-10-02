using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimatorEvent : MonoBehaviour
{
    [SerializeField] Transform pelvis;
    ZombieAttackCollider attacktrigger;


    public bool attacking = false;


    // Start is called before the first frame update
    void Start()
    {
        attacktrigger = GetComponentInChildren<ZombieAttackCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartAnimation()
    {
        attacking = true;
    }

    public void StartAttack()
    {
        attacktrigger.hit = true;
    }
    public void FinishAttack()
    {
        attacktrigger.hit = false;
    }
    public void FinishAnimation()
    {
        attacking = false;
        transform.position = pelvis.position;
        pelvis.localPosition = new Vector3(0, 0, 0);
    }
}