using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCG : MonoBehaviour
{

    public bool isStartButtonInputed = false;

    public bool aiming = false;

    public float t = 0;

    public bool setjet = false;


    float speed = 0.0f;

    Vector3 endpoint;
    Vector3 direction;

    [SerializeField] GameObject spaceship;
    [SerializeField] GameObject spaceshipjet;


    [SerializeField] TitleButtons titlebuttons;
    [SerializeField] Transform leftjet;
    [SerializeField] Transform rightjet;


    Rigidbody rb;
    [SerializeField] Camera maincamera;


    float time_go;

    // Start is called before the first frame update
    void Start()
    {
        rb = spaceship.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        isStartButtonInputed = titlebuttons.gamestart;

        if (isStartButtonInputed && !aiming && (Vector3.Angle(spaceship.transform.forward, direction) < 0.01f))
        {
            spaceship.transform.forward = direction;
            aiming = true;
        }







        if (time_go > 0 && time_go <= 0.5f)
        {
            speed += 100 * Time.deltaTime;
            if (!setjet)
            {
                GameObject _leftjet = Instantiate(spaceshipjet, leftjet.position, leftjet.rotation);
                GameObject _rightjet = Instantiate(spaceshipjet, rightjet.position, rightjet.rotation);
                _leftjet.transform.SetParent(leftjet);
                _rightjet.transform.SetParent(rightjet);
                setjet = true;
            }
        }
        else if (time_go > 0.5f && time_go <= 1f)
        {
            speed += 2000 * Time.deltaTime;
        }
        if (time_go > 3f)
        {
            SceneManager.LoadScene("Stage0");
        }

    }

    private void FixedUpdate()
    {
        if (isStartButtonInputed)
        {
            if (!aiming)
            {
                Quaternion _toRot = Quaternion.LookRotation(direction);
                spaceship.transform.rotation = Quaternion.Slerp(spaceship.transform.rotation, _toRot, 5 * Time.deltaTime);
            }
            else
            {
                rb.velocity = transform.forward * speed;
                time_go += Time.fixedDeltaTime;
            }
        }
        else
        {
            endpoint = maincamera.transform.position + maincamera.transform.forward * 100000f;
            direction = (endpoint - spaceship.transform.position).normalized;
        }
    }
}
