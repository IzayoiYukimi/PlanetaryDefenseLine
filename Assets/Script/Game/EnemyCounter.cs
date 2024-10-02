using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{

    public List<GameObject> enemies = new List<GameObject>();
    [SerializeField] AudioSource audiosource;
    [SerializeField] List<AudioClip> zombiesSElist = new List<AudioClip>();

    public bool enemycleared;

    float SETime = 5.0f;
    float interval = 0.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemiesArray = GameObject.FindGameObjectsWithTag("Enemy");
        enemies = new List<GameObject>(enemiesArray);

        enemycleared = !enemies.Any();

        if (!enemycleared)
        {
            if (!audiosource.isPlaying)
            {
                interval += Time.deltaTime;
                if (interval > SETime)
                {
                    int random = Random.Range(0, zombiesSElist.Count);
                    audiosource.clip = zombiesSElist[random];
                    audiosource.Play();
                    interval = 0.0f;
                }
            }

        }
    }
}
