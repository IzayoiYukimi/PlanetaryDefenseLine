using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceForEnum;
using UnityEngine.UI;

namespace SpaceForEnum
{
    public enum ControlDevice
    {
        Keyboard,
        Controller,
    }
}
public class GameManager : MonoBehaviour
{
    public ControlDevice device;
    public GameObject player;
    [SerializeField] Transform startpoint;
    [SerializeField] GameObject gameovermask;


    // Start is called before the first frame update
    void Start()
    {
        device = ControlDevice.Keyboard;
        player.transform.position = startpoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            device = ControlDevice.Keyboard;
        }
        for (int i = 0; i < 20; i++)
        {
            if (Input.GetKeyDown("joystick button " + i))
            {
                device = ControlDevice.Controller;
            }
        }
        string[] joystickAxes = new string[]
       {
            "Horizontal", "Vertical" // 根据你的映射情况调諄E
       };

        foreach (string axis in joystickAxes)
        {
            if (Mathf.Abs(Input.GetAxis(axis)) > 0.1f) // 0.1f 是一个阈值，可以根据需要调諄E
            {
                device = ControlDevice.Controller;
            }
        }

        if (player.GetComponent<PlayerHP>().gameover)
        {
            gameovermask.SetActive(true);
        }
    }
}
