using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int score;
    public int lives;
    public int scoreRecord;

    private void Start()
    {
        //load initial parameters
        score = 0;
        lives = 1;
        LoadPlayer();
    }
    
    //method that saves info
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    //method that loads info
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        scoreRecord = data.scoreRecord;
    }



}
