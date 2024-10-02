
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorEvent : MonoBehaviour
{

    [SerializeField] AudioSource audiosourceFootstep;

    PlayerSkill playerskill;
    PickRange pickrange;

    // Start is called before the first frame update
    void Start()
    {
        playerskill=GetComponent<PlayerSkill>();
        pickrange = GetComponentInChildren<PickRange>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void FootStep()
    {
        audiosourceFootstep.Play();
    }

    public void EndPickup()
    {
        playerskill.item[pickrange.items[0].GetComponent<ItemProperty>().itemID]++;
        Destroy(pickrange.items[0]);
        playerskill.overpickup = true;
    }
}
