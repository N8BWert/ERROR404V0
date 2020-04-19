using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextCrawel : MonoBehaviour
{
    public List<string> Sentances = new List<string>()
    {
        "Hey... You... You There... We've got a problem here.  Yeah, the whole system's kind-of messed up.  We need your help. (Left-Click to Continue)",
        "You've got to go in as this robot-thing-a-ma-jig and fix the system.  You get it, you got to keep us all alive. (Left-Click to Continue)",
        "These dudes... (These little buggers)... Well they've been causing problems in the system. (Left-Click to Continue)",
        "Don't worry if you left-click you can stun those little guys. (Left-Click to Continue)",
        "If you can stun them... Then you can right click on them to pick them up and move them to the furnace",
        "Well, anyways... They're attacking the mainframe and need to be stopped. (Left-Click to Continue)",
        "They start in these things, but if you can get close enough for a long enough amount of time you might be able to make them useful. (Left-Click to Continue)",
        "These will help you prevent the little buggers from completely destroying our mainframe, but the virus love's these things so you might want to guard them. (Left-Click to Continue)",
        "Good luck, the whole PC needs your help (Left-Click to Continue)"
    };
    public float delay = 0.1f;
    private string currentText = "";
    private bool Continue = false;
    public List<GameObject> photos = new List<GameObject>();
    public bool canMoveOn = false;
    public string nextScene;

    void Start()
    {
        StartCoroutine(ShowText());
    }

    // Update is called once per frame
    void Update()
    {
        ContinueOn();
    }
    IEnumerator ShowText()
    {
        for (int j = 0; j < 9; j++)
        {
            for (int i = 0; i < Sentances[j].Length; i++)
            {
                currentText = Sentances[j].Substring(0, i);
                photos[j].SetActive(true);
                this.GetComponent<Text>().text = currentText;
                yield return new WaitForSeconds(delay);
            }
            while (!Continue)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    Continue = true;
                }
                yield return null;
            }
            Continue = false;
            currentText = "";
            photos[j].SetActive(false);
        }
        canMoveOn = true;
    }
    void ContinueOn()
    {
        if(canMoveOn || Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
