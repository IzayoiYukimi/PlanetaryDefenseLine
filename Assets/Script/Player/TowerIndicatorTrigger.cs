using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerIndicatorTrigger : MonoBehaviour
{
    public bool canset;
    public List<GameObject> colliders = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        List<GameObject> _colliderstoremove = new List<GameObject>();
        foreach (var obj in colliders)
        {
            if (obj == null)
            {
                _colliderstoremove.Add(obj);
            }
        }
        foreach (var item in _colliderstoremove)
        {
            colliders.Remove(item);
        }

        canset = !colliders.Any();


    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Ground"))
        {
            if (!colliders.Contains(other.gameObject)) colliders.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Ground"))
        {
            if (colliders.Contains(other.gameObject)) colliders.Remove(other.gameObject);
        }
    }
}
