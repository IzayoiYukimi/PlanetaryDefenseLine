using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class MissileController : MonoBehaviour
{
    [SerializeField] GameObject boomprefab;
    public GameObject target;
    Rigidbody rb;

    float speed = 0.0f;
    float cruisespeed = 10.0f;
    float attackspeed = 20.0f;

    float lifetime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        lifetime += Time.deltaTime;
        rb.velocity = transform.up * speed;
        if (lifetime < 1.0f)
        {
            speed = cruisespeed;
        }
        else
        {
            speed = attackspeed;
            if (target != null)
            {
                Vector3 direction = target.transform.position - transform.position;
                Quaternion targetRotation = Quaternion.FromToRotation(transform.up, direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation * transform.rotation, 5 * Time.deltaTime);
            }
        }

        if (lifetime > 5.0f)
        {
            Instantiate(boomprefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(boomprefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
