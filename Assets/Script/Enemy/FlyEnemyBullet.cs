using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyBullet : MonoBehaviour
{
    public Vector3 targerpos;
    Rigidbody rb;

    float lifetime = 0.0f;
    float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        lifetime += Time.deltaTime;

        if (lifetime < 2.0f)
        {
            transform.forward = (targerpos - transform.position).normalized;
            rb.velocity = transform.forward * speed;
        }
        else
        {
            rb.velocity = transform.forward * speed;
        }

        if (lifetime > 5.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<PlayerHP>().TakeDamage(10);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
