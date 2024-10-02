using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    Animator animator;
    PlayerMove playermove;

    public int shield;
    public int MaxShield = 100;



    public int health;
    public int MaxHealth = 100;
    float deathtime = 3.0f;

    bool setdeath = false;
    public bool gameover = false;

    [SerializeField] AudioSource audiosourceShieldhit;
    [SerializeField] AudioSource audiosourceShieldBreak;
    [SerializeField] AudioSource audiosourceShieldGet;
    [SerializeField] AudioSource audiosourceBodyhit;
    [SerializeField] List<AudioClip> shieldhitclips;
    [SerializeField] List<AudioClip> bodyhitclips;

   

    // Start is called before the first frame update
    void Start()
    {
        shield = 80;
        health = MaxHealth;
        animator = GetComponent<Animator>();
        playermove = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            if (!setdeath)
            {
                animator.SetBool("Dead", true);
                setdeath = true;
                gameObject.tag = "Untagged";
            }
            Die();
        }



       

    }

    void Die()
    {
        playermove.Death = true;

        deathtime -= Time.deltaTime;
        if (deathtime < 0)
        {
            gameover = true;
        }
    }
    public void TakeDamage(int _damage)
    {
        if (shield > 0)
        {
            shield -= _damage;
            int random = Random.Range(0, shieldhitclips.Count);
            audiosourceShieldhit.clip = shieldhitclips[random];
            audiosourceShieldhit.Play();
            if (shield <= 0)
            {
                shield = 0;
                audiosourceShieldBreak.Play();
            }
        }
        else
        {
            health -= _damage;
            int random = Random.Range(0, bodyhitclips.Count);
            audiosourceBodyhit.clip = bodyhitclips[random];
            audiosourceBodyhit.Play();
        }
    }

    public void Healhealth(int _heal, float time)
    {

    }


    public void ChargeShield(int _charge)
    {
        shield += _charge;
        if (shield > MaxShield)
        {
            shield = MaxShield;
        }
        audiosourceShieldGet.Play();
    }
}
