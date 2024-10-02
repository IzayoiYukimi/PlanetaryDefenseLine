using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttackCollider : MonoBehaviour
{
    [SerializeField] ZombieController zombiecontroller;
    public bool hit = false;
    // Start is called before the first frame update
    void Awake()
    {
        zombiecontroller = GetComponentInParent<ZombieController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (hit)
            {
                other.GetComponent<PlayerHP>().TakeDamage(zombiecontroller.AttackDamage);
                hit = false;
            }
        }
    }
}
