using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnSystem : MonoBehaviour
{
    public GameObject[] positions;
    public float time = 1;

    public GameObject obj;
    private GameObject activeObj;
    public static float startSpeed = 0.1f;
    public float speedIncrease = 0.00f;

    public static int score;
    public Text scoreText;

    public static int lives;
    public Text livesText;

    public GameObject gameoverText;
    public bool playing;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        lives = 3;
        playing = true;
        gameoverText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (lives == 0)
        {
            playing = false;
            gameoverText.SetActive(true);
        }

        startSpeed += speedIncrease;

        if (activeObj == null && playing && !gameoverText.active)
        {
            activeObj = Instantiate(obj);
            activeObj.transform.position = positions[Random.Range(0, positions.Length)].transform.position;
        }

        scoreText.text = "Score: " + score.ToString();
        livesText.text = "Lives: " + lives.ToString();
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
