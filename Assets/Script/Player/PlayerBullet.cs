using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    [SerializeField] GameObject blazing;
    public Vector3 Direction;

    float lifetime = 5.0f;

    float bulletspeed = 20.0f;

    public int bulletdamage = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = Direction;
        transform.position += Direction * bulletspeed * Time.deltaTime;

        lifetime -= Time.deltaTime;
        if (lifetime < 0) Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHP>().TakeDamage(bulletdamage);
        }
        Instantiate(blazing, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}
