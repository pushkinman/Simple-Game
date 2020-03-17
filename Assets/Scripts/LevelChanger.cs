using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator anim;
    private int levelToLoad;

    // Update is called once per frame
    void Update()
    {
        //Check if working
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FadeToLevel(0);
        }
    }

    //function called on a button
    public void FadeToLevel (int levelIndex)
    {
        levelToLoad = levelIndex;
        anim.SetTrigger("FadeOut");
    }

    //when animation comletes an event is called in a timeline
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
