using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyBoomController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject boomprefab;

    Rigidbody rb;

    [SerializeField] float speed = 5.0f;

    bool findtarget = false;
    float boomtime = 2.0f;

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
    }



    void Move()
    {
        Vector3 Director = player.transform.position - transform.position;

        if (Director.magnitude < 15f)
        {
            findtarget = true;
            transform.forward = Director.normalized;
            rb.velocity = transform.forward * 1.5f * speed;
        }
        else
        {
            Director.y = 0;
            transform.forward = Director.normalized;
            rb.velocity = transform.forward * speed;

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

        if (findtarget)
        {
            boomtime -= Time.deltaTime;
            if (boomtime <= 0)
            {
                Instantiate(boomprefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Instantiate(boomprefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
