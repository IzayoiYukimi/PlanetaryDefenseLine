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

    [SerializeField] string enemytag = "Enemy";

    bool setdeath = false;

    // Start is called before the first frame update
    void OnEnable()
    {
        hp = MaxHp;
        gameObject.tag = enemytag;
        setdeath = false;
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
                if (zombiecontroller != null) animator.SetTrigger("Death");
                gameObject.tag = "Untagged";
                OnDestroyed.Invoke();
                setdeath = true;
            }
            Die();
        }
    }

    void Die()
    {
        if (zombiecontroller != null)
        {
            zombiecontroller.Death = true;
            deathtime -= Time.deltaTime;
            if (deathtime < 0)
            {
                gameObject.SetActive(false);
                transform.position = Vector3.zero;
            }
        }
        else
        {
            gameObject.SetActive(false);
            transform.position = Vector3.zero;
        }
    }
    public void TakeDamage(int _damage)
    {
        hp -= _damage;
    }
}
