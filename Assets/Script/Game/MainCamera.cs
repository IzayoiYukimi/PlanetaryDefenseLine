using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceForEnum;

public class MainCamera : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform GameClearCameraPoint;
    public bool isClear = false;
    GameManager gamemanager;
    float zoom;
    public Vector3 postoplayer;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isClear)
        {
            transform.position = GameClearCameraPoint.position;
            transform.rotation = GameClearCameraPoint.rotation;
        }
        else
        {
            if (gamemanager.device == ControlDevice.Keyboard) zoom += player.GetComponent<PlayerInput>().zoom * Time.deltaTime;
            else if (gamemanager.device == ControlDevice.Controller) zoom += player.GetComponent<PlayerInput>().zoom * Time.deltaTime * 5;
            if (zoom < 0) zoom = 0;
            else if (zoom > 20) zoom = 20;
        }
    }
    private void LateUpdate()
    {
        if (!isClear)
        {
            transform.position = player.transform.position + postoplayer + new Vector3(0, 2 * zoom, -zoom);
            transform.LookAt(player.transform.position);
        }
    }
}
