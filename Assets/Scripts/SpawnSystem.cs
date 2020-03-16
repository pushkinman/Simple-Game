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

    public GameObject gameoverText;
    public bool playing;

    public static int mode;
    public Text modeText;

    public int modeCountLimit = 4;
    private int modeCount;

    public Player player;
    public UIManager uIManager;

    public Animator modeAnim;

    // Start is called before the first frame update
    void Start()
    {
        modeText = GameObject.FindGameObjectWithTag("Mode").GetComponent<Text>();
        playing = true;
        modeCount = 0;
        gameoverText.SetActive(false);

        player = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Player>();
        uIManager = GameObject.Find("UI").GetComponent<UIManager>();
        modeAnim.SetTrigger("Mode");
    }

    // Update is called once per frame
    void Update()
    {
        if (modeCount >= modeCountLimit)
        {
            mode = (mode + 1) % 3;
            modeCount = 0;
            modeAnim.SetTrigger("Mode");
        }

        if (player.lives == 0)
        {
            playing = false;
            gameoverText.SetActive(true);

            if(player.score > player.scoreRecord)
            {
                player.scoreRecord = player.score;
                player.SavePlayer();
            }
        }

        startSpeed += speedIncrease;

        if (activeObj == null && playing && !gameoverText.active)
        {
            activeObj = Instantiate(obj);
            activeObj.transform.position = positions[Random.Range(0, positions.Length)].transform.position;
            modeCount++;
            UpdateBases();
            
        }
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
