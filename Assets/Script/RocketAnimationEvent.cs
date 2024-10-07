using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketAnimationEvent : MonoBehaviour
{
    Animator animator;


    [SerializeField] Camera maincamera;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void GameClear()
    {
        maincamera.GetComponent<MainCamera>().isClear = true;
        animator.SetBool("GameClear",true);
        animator.SetBool("IsRocketComplet",true);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("Title");
    }
}
