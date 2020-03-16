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
        score = 0;
        lives = 1;
        LoadPlayer();
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        scoreRecord = data.scoreRecord;
    }



}
