using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class ZombieController : MonoBehaviour
{

    Animator animator;
    NavMeshAgent navagent;
    ZombieAnimatorEvent zombieAnimatorEvent;
    Vector3 playerPos;

    Vector3 playerpostion;
    bool getplayerPos = false;
    int idlemode;
    public float warningradius = 20.0f;
    float attackradius = 0.5f;

    public bool Death = false;

    public int AttackDamage = 5;

    // Start is called before the first frame update
    void Start()
    {
        idlemode = Random.Range(1, 4);
        animator = GetComponent<Animator>();
        animator.SetInteger("IdleMode", idlemode);

        navagent = GetComponent<NavMeshAgent>();
        zombieAnimatorEvent = GetComponent<ZombieAnimatorEvent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Death)
        {
            navagent.enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
        }
        else
        {
            Collider[] attackColliders = Physics.OverlapSphere(transform.position, attackradius, LayerMask.GetMask("Player"));
            foreach (Collider collider in attackColliders)
            {
                if (collider.CompareTag("Player"))
                {
                    playerPos = collider.transform.position;
                    Attack();
                    navagent.enabled = false;
                }
            }
            if (!zombieAnimatorEvent.attacking)
            {
                navagent.enabled = true;
                GotoPlayer();
            }

        }

    }
    void GotoPlayer()
    {
        getplayerPos = false;
        Collider[] warningColliders = Physics.OverlapSphere(transform.position, warningradius, LayerMask.GetMask("Player"));
        foreach (Collider collider in warningColliders)
        {
            if (collider.CompareTag("Player"))
            {
                playerpostion = collider.transform.position;
                getplayerPos = true;
            }
        }
        if (getplayerPos)
        {
            navagent.isStopped = false;
            navagent.SetDestination(playerpostion + new Vector3(0, 1.5f, 0));
            animator.SetBool("Walk", true);
        }
        else
        {
            navagent.isStopped = true;
            animator.SetBool("Walk", false);
        }
    }

    void Attack()
    {
        if (!zombieAnimatorEvent.attacking)
        {
            transform.forward = (playerPos - transform.position).normalized;
            animator.SetInteger("AttackType", Random.Range(1, 4));
            animator.SetTrigger("Attack");
        }
    }
}
