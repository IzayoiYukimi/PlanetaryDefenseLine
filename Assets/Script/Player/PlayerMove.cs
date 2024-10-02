using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceForEnum;

public class PlayerMove : MonoBehaviour
{
    PlayerInput playerinput;
    Animator animator;
    GameManager gamemanager;
    [SerializeField] LayerMask GroundLayerMask;

    [SerializeField] bool isOnGround = false;
    public bool isAiming = false;
    public bool isShooting = false;
    public Vector3 aimingdirection;
    public bool Death = false;

    // Start is called before the first frame update
    void Start()
    {
        playerinput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
        gamemanager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }


    // Update is called once per frame
    void Update()
    {
        if (!Death)
        {
            Aiming();
            if (isAiming) AimingMove();
            else Move();
        }
    }

    void Aiming()
    {
        isAiming = playerinput.aiming;
        animator.SetBool("Aiming", isAiming);
    }

    void AimingMove()
    {
        if (gamemanager.device == ControlDevice.Keyboard)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, GroundLayerMask))
            {
                
                aimingdirection = hit.point - transform.position;
               
                //aimingdirection.y = 0;
                aimingdirection = aimingdirection.normalized;
                transform.forward = aimingdirection;
            }
        }
        else if (gamemanager.device == ControlDevice.Controller)
        {
            aimingdirection = playerinput.aimingdirection;
            transform.forward = aimingdirection == Vector3.zero ? transform.forward : aimingdirection;
        }


        animator.SetFloat("X", transform.forward.z * playerinput.move.x - transform.forward.x * playerinput.move.z);
        animator.SetFloat("Y", transform.forward.x * playerinput.move.x + transform.forward.z * playerinput.move.z);
    }
    void Move()
    {
        if (playerinput.move.x != 0 || playerinput.move.z != 0) transform.forward = playerinput.move;

        animator.SetFloat("Speed", playerinput.move.magnitude * (playerinput.dash + 1));
        animator.SetBool("OnGround", isOnGround);
        
    }




    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Ground")) isOnGround = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground")) isOnGround = false;
    }

}
