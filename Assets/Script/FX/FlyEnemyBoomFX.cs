using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyBoomFX : MonoBehaviour
{
    bool taked=false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!taked)
            {
                other.GetComponent<PlayerHP>().TakeDamage(20);
                taked = true;
            }
        }
    }
}
