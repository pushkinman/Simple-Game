using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public int[] scoreDificulty = new int[10] { 0, 5, 10, 15, 20, 25, 30, 35, 40, 45 };

    Player player;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Player>();
    }

    public void Update()
    {
        //increases speed based on score
        if (player.score == 5)
            SpawnSystem.startSpeed = 3.5f;
        if (player.score == 10)
            SpawnSystem.startSpeed = 4f;
        if (player.score == 15)
            SpawnSystem.startSpeed = 4.5f;
        if (player.score == 20)
            SpawnSystem.startSpeed = 5f;
        if (player.score == 25)
            SpawnSystem.startSpeed = 5.5f;

        //Debug.Log(SpawnSystem.startSpeed);
    }
}
