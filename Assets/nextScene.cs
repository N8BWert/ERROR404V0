using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour
{
    public string FollowingScene;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene(FollowingScene);
        }
    }
}
