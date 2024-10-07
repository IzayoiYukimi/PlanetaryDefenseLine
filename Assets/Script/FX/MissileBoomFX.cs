using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBoomFX : MonoBehaviour
{
    bool taked = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (!taked)
            {
                other.GetComponent<EnemyHP>().TakeDamage(50);
                taked = true;
            }
        }

        if(other.CompareTag("FlyEnemy"))
        {
            if (!taked)
            {
                other.GetComponent<EnemyHP>().TakeDamage(50);
                taked = true;
            }
        }
    }
}
