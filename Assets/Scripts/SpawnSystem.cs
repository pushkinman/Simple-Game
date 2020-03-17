using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnSystem : MonoBehaviour
{
    //start positions for obj
    public GameObject[] positions;

    //obj prefab
    public GameObject obj;
    //instantiated obj prefab
    private GameObject activeObj;

    public static float startSpeed = 3f;

    public GameObject gameoverText;
    public bool playing;

    public static int mode;

    public int modeCountLimit = 4;
    private int modeCount;

    public Player player;

    public Animator modeAnim;

    // Start is called before the first frame update
    void Start()
    {
        playing = true;
        gameoverText.SetActive(false);

        //randomly select mode
        modeCount = Random.Range(0,2);

        player = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Player>();
        //call mode animation for the first time
        modeAnim.SetTrigger("Mode");
    }

    // Update is called once per frame
    void Update()
    {
        //Changing mode
        if (modeCount >= modeCountLimit)
        {
            mode = (mode + 1) % 3;
            modeCount = 0;
            modeAnim.SetTrigger("Mode");
        }

        //if died
        if (player.lives == 0)
        {
            playing = false;
            gameoverText.SetActive(true);

            //if new highscore then save data
            if(player.score > player.scoreRecord)
            {
                player.scoreRecord = player.score;
                player.SavePlayer();
            }
        }

        //playing the game
        if (activeObj == null && playing && !gameoverText.active)
        {
            activeObj = Instantiate(obj);
            activeObj.transform.position = positions[Random.Range(0, positions.Length)].transform.position;
            modeCount++;
            //call method to respawn the bases
            UpdateBases();
            
        }
    }

    public void UpdateBases()
    {
        GameObject.Find("BasesSpawnManager").GetComponent<BasesRandom>().UpdateBases();
    }
}
