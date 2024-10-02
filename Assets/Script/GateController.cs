using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    GameObject player;
    AudioSource audiosource;
    Animator animator;

    bool isopen = false;
    bool ismoving = false;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && !player.GetComponentInChildren<PickRange>().anyiteminrange)
        {
            if (player.GetComponent<PlayerInput>().use && !ismoving)
            {
                player.GetComponent<PlayerInput>().use = false;
                if (!isopen)
                {
                    isopen = true;
                }
                else
                {
                    isopen = false;
                }
                animator.SetBool("IsOpen", isopen);
                audiosource.Play();
                ismoving = true;
            }
        }
    }

    public void FinishGateMove()
    {
        ismoving = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = null;
        }
    }

}
