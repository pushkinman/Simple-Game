using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    static float speed;
    public Animator anim;

    public float timer = 2;
    private float timerActual;

    public int mode = 0;

    private string[] colors = new string[]{ "Red", "Yellow", "Green", "Blue", "Purple"};
    private string[] numbers = new string[5] { "1", "2", "3", "4", "5" };

    public string objColor;
    public string objNumber;

    public Color[] actualColors;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        timerActual = 2;
        objColor = colors[Random.Range(0, colors.Length)];
        objNumber = numbers[Random.Range(0, colors.Length)];
        if (objColor == "Red")
            gameObject.GetComponent<MeshRenderer>().material.color = actualColors[0];
        if (objColor == "Yellow")
            gameObject.GetComponent<MeshRenderer>().material.color = actualColors[1];
        if (objColor == "Green")
            gameObject.GetComponent<MeshRenderer>().material.color = actualColors[2];
        if (objColor == "Blue")
            gameObject.GetComponent<MeshRenderer>().material.color = actualColors[3];
        if (objColor == "Purple")
            gameObject.GetComponent<MeshRenderer>().material.color = actualColors[4];
    }

    // Update is called once per frame
    void Update()
    {
        timerActual -= Time.deltaTime;

        if(timerActual < 0)
        {
            //mode = (mode + 1) % 2;
            timerActual = timer;
        }

        speed = SpawnSystem.startSpeed;
        gameObject.transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftArrow) && gameObject.transform.position.x > -1.5)
        {
            gameObject.transform.position += new Vector3(-1, 0, 0);
            //anim.SetBool("Left", true);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && gameObject.transform.position.x < 1.5)
        {
            gameObject.transform.position += new Vector3(1, 0, 0);
            //anim.SetBool("Right", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (mode == 0)
        {
            if(other.GetComponent<BaseInfo>().color == objColor)
            {
                SpawnSystem.score++;
                Destroy(gameObject);
            }
            else
            {
                SpawnSystem.lives--;
                Destroy(gameObject);
            }
        }
        else if (mode == 1)
        {
            if (other.GetComponent<BaseInfo>().number == objNumber)
            {
                SpawnSystem.score++;
                Destroy(gameObject);
            }
            else
            {
                SpawnSystem.lives--;
                Destroy(gameObject);
            }
        }

        Destroy(gameObject);
    }
}
