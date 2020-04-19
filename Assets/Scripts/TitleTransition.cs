using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleTransition : MonoBehaviour
{
    public string followingScene;

    public void NextScene()
    {
        Debug.Log("Click");
        SceneManager.LoadScene(followingScene);
    }
}
