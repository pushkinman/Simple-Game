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
    public static float startSpeed = 3f;
    public float speedIncrease = 0.00f;

    public static int score;
    public Text scoreText;

    public static int lives;
    public Text livesText;

    public GameObject gameoverText;
    public bool playing;

    public static float timer = 10;
    public static float timerActual;

    public static int mode = 2;
    public Text modeText;

    public int modeCountLimit = 4;
    private int modeCount;

    // Start is called before the first frame update
    void Start()
    {
        modeText = GameObject.FindGameObjectWithTag("Mode").GetComponent<Text>();
        score = 0;
        lives = 1;
        playing = true;
        modeCount = 0;
        gameoverText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (modeCount >= modeCountLimit)
        //{
        //    mode = (mode + 1) % 3;
        //    modeCount = 0;
        //}

        if (mode == 0)
            modeText.text = "Mode: Color";
        else if (mode == 1)
            modeText.text = "Mode: Numbers";
        else if (mode == 2)
            modeText.text = "Mode: Shapes";

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
            modeCount++;
            UpdateBases();
            
        }

        scoreText.text = score.ToString();
        livesText.text = "Lives: " + lives.ToString();
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void UpdateBases()
    {
        GameObject.Find("BasesSpawnManager").GetComponent<BasesRandom>().UpdateBases();
    }
}
