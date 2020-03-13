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

    public static int mode = 0;
    public Text modeText;

    public HashSet<GameObject> actualObjects;

    public HashSet<GameObject> colors;
    public HashSet<GameObject> numbers;
    public HashSet<GameObject> shapes;

    // Start is called before the first frame update
    void Start()
    {
        modeText = GameObject.FindGameObjectWithTag("Mode").GetComponent<Text>();
        score = 0;
        lives = 3;
        playing = true;
        gameoverText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timerActual -= Time.deltaTime;

        if (timerActual < 0)
        {
            mode = (mode + 1) % 2;
            timerActual = timer;
        }

        if (mode == 0)
            modeText.text = "Mode: Color";
        if (mode == 1)
            modeText.text = "Mode: Numbers";

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
            UpdateBases();
        }

        scoreText.text = "Score: " + score.ToString();
        livesText.text = "Lives: " + lives.ToString();
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void UpdateBases()
    {

    }
}
