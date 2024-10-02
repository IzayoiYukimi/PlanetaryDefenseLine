using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{

    PlayerInputActions controls;
    public Vector3 move = new Vector3(0, 0, 0);
    public bool aiming = false;
    public Vector3 aimingdirection = new Vector3(0, 0, 0);
    public bool attack = false;
    public float dash;
    public bool reload = false;
    public float zoom;
    public bool use;
    public Vector2 mouse = new Vector2(0, 0);
    public bool shiledcharge = false;
    public bool useitem1 = false;
    public bool useitem2 = false;
    public bool useitem3 = false;


    // Start is called before the first frame update

    private void Awake()
    {
        controls = new PlayerInputActions();

        controls.Player.Move.performed += ctx => move = ctx.ReadValue<Vector3>();
        controls.Player.Move.canceled += ctx => move = Vector3.zero;


        controls.Player.Aiming.performed += ctx => aiming = true;
        controls.Player.Aiming.canceled += ctx => aiming = false;

        controls.Player.AimingDirection.performed += ctx => aimingdirection = ctx.ReadValue<Vector3>();
        controls.Player.AimingDirection.canceled += ctx => aimingdirection = transform.forward;

        controls.Player.Attack.performed += ctx => attack = true;
        controls.Player.Attack.canceled += ctx => attack = false;

        controls.Player.Dash.started += ctx => dash = ctx.ReadValue<float>();
        controls.Player.Dash.canceled += ctx => dash = 0;

        controls.Player.Reload.started += ctx => reload = true;
        controls.Player.Reload.canceled += ctx => reload = false;

        controls.Player.Zoom.performed += ctx => zoom = ctx.ReadValue<float>();
        controls.Player.Zoom.canceled += ctx => zoom = 0;

        controls.Player.Use.started += ctx => use = true;
        controls.Player.Use.canceled += ctx => use = false;

        controls.Player.Mouse.performed += ctx => mouse = ctx.ReadValue<Vector2>();

        controls.Player.UseItem1.started += ctx => useitem1 = true;
        controls.Player.UseItem1.canceled += ctx => useitem1 = false;

        controls.Player.UseItem2.started += ctx => useitem2 = true;
        controls.Player.UseItem2.canceled += ctx => useitem2 = false;

        controls.Player.UseItem3.started += ctx => useitem3 = true;
        controls.Player.UseItem3.canceled += ctx => useitem3 = false;

        controls.Player.ShiledCharge.started += ctx => shiledcharge = true;
        controls.Player.ShiledCharge.canceled += ctx => shiledcharge = false;

    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
