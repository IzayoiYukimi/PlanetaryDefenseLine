using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FlyEnemyShootController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject gunpoint;
    [SerializeField] GameObject bulletprefab;

    Rigidbody rb;

    [SerializeField] float speed = 5.0f;

    float attackspeed = 0.33f;
    float reloadtime = 0.0f;

    bool findtarget = false;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (findtarget)
        {
            Fire();
        }
    }



    void Move()
    {
        Vector3 Director = player.transform.position - transform.position;
        Director.y = 0;
        transform.forward = Director.normalized;
        if (Director.magnitude < 15f)
        {
            rb.velocity = Vector3.zero;
        }
        else
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity))
            {
                float distanceToGround = hit.distance;
                if (distanceToGround < 10)
                {
                    rb.velocity = (Vector3.up + transform.forward) * speed;
                }
                else if (distanceToGround > 12)
                {
                    rb.velocity = (Vector3.down + transform.forward) * speed;
                }
                else
                {
                    rb.velocity = transform.forward * speed;
                }

            }
        }
        if (Director.magnitude < 20f)
        {
            findtarget = true;
        }
        else
        {
            findtarget = false;
        }

    }



    void Fire()
    {
        reloadtime += Time.deltaTime;
        if (reloadtime > 1 / attackspeed)
        {
            GameObject _bullet = Instantiate(bulletprefab, gunpoint.transform.position, Quaternion.identity);
            _bullet.GetComponent<FlyEnemyBullet>().targerpos = player.transform.position;
            reloadtime = 0;
        }
    }
}


