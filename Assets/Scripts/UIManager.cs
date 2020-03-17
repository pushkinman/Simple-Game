using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Text livesText;
    public Text scoreRecordText;
    public Text modeText;

    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //set all visual parameters
        scoreRecordText.text = "Best score " + player.scoreRecord.ToString();
        scoreText.text = player.score.ToString();
        livesText.text = "Lives " + player.lives.ToString();

        if (SpawnSystem.mode == 0)
            modeText.text = "Color!";
        else if (SpawnSystem.mode == 1)
            modeText.text = "Numbers!";
        else if (SpawnSystem.mode == 2)
            modeText.text = "Shapes!";
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
