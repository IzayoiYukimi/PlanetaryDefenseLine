using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMask : MonoBehaviour
{
    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ExitDark()
    {
        if (animator == null)
        {
            Debug.LogError("Animator component not found!");
            return;
        }
        animator.Play("ExitDark");
    }

    public void ToDisable()
    {
        this.gameObject.SetActive(false);
    }

}
