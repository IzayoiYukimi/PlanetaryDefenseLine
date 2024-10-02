using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    //Ž©•ª‚ª”j‰ó‚³‚ê‚é‚Æ‚«‚ÌƒfƒŠƒQ[ƒg‚Ì’è‹`
    public delegate void OnDestroyedDelegate();
    public OnDestroyedDelegate OnDestroyed = new OnDestroyedDelegate(() => { });


    Animator animator;
    ZombieController zombiecontroller;

    public int hp;
    public int MaxHp = 100;
    float deathtime = 2.0f;

    bool setdeath = false;

    // Start is called before the first frame update
    void Start()
    {
        hp = MaxHp;
        animator = GetComponent<Animator>();
        zombiecontroller = GetComponent<ZombieController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            if (!setdeath)
            {
                animator.SetTrigger("Death");
                gameObject.tag = "Untagged";
                OnDestroyed.Invoke();
                setdeath = true;
            }
            Die();
        }
    }

    void Die()
    {
        zombiecontroller.Death = true;

        deathtime -= Time.deltaTime;
        if (deathtime < 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void TakeDamage(int _damage)
    {
        hp -= _damage;
    }
}
