using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneChange : MonoBehaviour
{
   public void ChangeScene()
    {
        SceneManager.LoadScene("Title");
    }
}
