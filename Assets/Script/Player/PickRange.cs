using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PickRange : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();

    public bool anyiteminrange = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        List<GameObject> _itemstoremove = new List<GameObject>();
        foreach (var item in items)
        {
            if (item == null)
            {
                _itemstoremove.Add(item);
            }
        }
        foreach (var item in _itemstoremove)
        {
            items.Remove(item);
        }

       anyiteminrange = items.Any();
        
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            if (!items.Contains(other.gameObject)) items.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            if (items.Contains(other.gameObject)) items.Remove(other.gameObject);
        }
    }

}
