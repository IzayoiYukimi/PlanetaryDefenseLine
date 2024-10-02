using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    PlayerInput playerinput;
    PlayerMove playermove;
    Animator animator;
    [SerializeField] GameObject bulletprefab;
    [SerializeField] GameObject shellprefab;
    [SerializeField] GameObject muzzleflareprefab;
    [SerializeField] Transform guntransform;
    [SerializeField] Transform gunpoint;
    [SerializeField] Transform firearms;

    [SerializeField] List<AudioClip> Rifle;
    [SerializeField] AudioSource audiosourceFire;
    [SerializeField] AudioSource audiosourceReload;


    float attackspeed = 5;
    float attacktime;

    bool reload = false;
    bool reloadfished = false;
    public int bulletnum = 0;
    public int maxbulletnum = 30;
    bool attackset = true;//cock


    // Start is called before the first frame update
    void Start()
    {
        playerinput = GetComponent<PlayerInput>();
        playermove = GetComponent<PlayerMove>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playermove.isAiming)
        {
            if (bulletnum > 0)
            {
                if (playerinput.attack && !reload && attackset)
                {
                    animator.SetTrigger("Shoot");
                    attackset = false;
                    attacktime = 0.0f;
                }

            }
        }
        AttackSpeedSet();


        if (playerinput.reload)
        {
            if (reloadfished && bulletnum < maxbulletnum) reload = true;
        }
        if (reload)
        {
            animator.SetBool("Reloading", true);
            audiosourceReload.Play();
            reload = false;
            reloadfished = false;
        }
        if (!audiosourceReload.isPlaying && !reloadfished)
        {
            reloadfished = true;
            animator.SetBool("Reloading", false);
            bulletnum = maxbulletnum;
        }
    }
    void AttackSpeedSet()
    {
        attacktime += Time.deltaTime;
        if (!playerinput.attack)
        {
            attackset = true;
        }
        else
        {
            if (attacktime >= 1.0 / attackspeed)
            {
                attackset = true;
            }
        }
    }

    public void Fire()
    {
        bulletnum--;
        int random = Random.Range(0, Rifle.Count);
        audiosourceFire.clip = Rifle[random];
        audiosourceFire.Play();
        GameObject _bullet = Instantiate(bulletprefab, gunpoint.transform.position, guntransform.rotation * Quaternion.Euler(0, 180, 0));
        _bullet.GetComponent<PlayerBullet>().Direction = transform.forward;

        Instantiate(muzzleflareprefab, gunpoint.transform.position, guntransform.rotation * Quaternion.Euler(0, 90, 0));

        Instantiate(shellprefab, firearms.transform.position, firearms.transform.rotation);
    }

}
