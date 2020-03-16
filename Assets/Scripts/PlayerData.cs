using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int scoreRecord;

    public PlayerData(Player player)
    {
        scoreRecord = player.scoreRecord;
    }
}
