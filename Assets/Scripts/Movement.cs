using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    static float speed;
    public Animator anim;

    private string[] colors = new string[]{ "Red", "Yellow", "Green", "Blue"};
    private string[] numbers = new string[] { "1", "2", "3", "4" };
    private string[] shapes = new string[] { "Square", "Circle", "Heart", "Star" };

    public string objColor;
    public string objNumber;
    public string objShape;

    public Material[] materials;
    public GameObject[] shapePrefabs;
    
    // Start is called before the first frame update
    void Start()
    {
        
        //anim = GetComponent<Animator>();
        objColor = colors[Random.Range(0, colors.Length)];
        objNumber = numbers[Random.Range(0, numbers.Length)];
        objShape = shapes[Random.Range(0, shapes.Length)];

        if (objShape == "Square")
        {
            GameObject obj = Instantiate(shapePrefabs[0]);
            obj.transform.position = gameObject.transform.position;
            Destroy(obj.transform.GetChild(0).gameObject);
            obj.transform.parent = gameObject.transform;
        }
        else if (objShape == "Circle")
        {
            GameObject obj = Instantiate(shapePrefabs[1]);
            obj.transform.position = gameObject.transform.position;
            Destroy(obj.transform.GetChild(0).gameObject);
            obj.transform.parent = gameObject.transform;
        }
        else if (objShape == "Heart")
        {
            GameObject obj = Instantiate(shapePrefabs[2]);
            obj.transform.position = gameObject.transform.position;
            Destroy(obj.transform.GetChild(0).gameObject);
            obj.transform.parent = gameObject.transform;
        }
        else if (objShape == "Star")
        {
            GameObject obj = Instantiate(shapePrefabs[3]);
            obj.transform.position = gameObject.transform.position;
            Destroy(obj.transform.GetChild(0).gameObject);
            obj.transform.parent = gameObject.transform;
        }

        if (objColor == "Red")
            gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material.color = materials[0].color;
        else if (objColor == "Yellow")
            gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material.color = materials[1].color;
        else if (objColor == "Green")
            gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material.color = materials[2].color;
        else if (objColor == "Blue")
            gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material.color = materials[3].color;

        if (objNumber == "1")
            gameObject.transform.GetChild(0).GetComponent<TextMesh>().text = "1";
        else if (objNumber == "2")
            gameObject.transform.GetChild(0).GetComponent<TextMesh>().text = "2";
        else if (objNumber == "3")
            gameObject.transform.GetChild(0).GetComponent<TextMesh>().text = "3";
        else if (objNumber == "4")
            gameObject.transform.GetChild(0).GetComponent<TextMesh>().text = "4";

        
    }

    // Update is called once per frame
    void Update()
    {
        

        speed = SpawnSystem.startSpeed;
        gameObject.transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftArrow) && gameObject.transform.position.x > -1.5)
        {
            gameObject.transform.position += new Vector3(-1.5f, 0, 0);
            //anim.SetBool("Left", true);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && gameObject.transform.position.x < 1.5)
        {
            gameObject.transform.position += new Vector3(1.5f, 0, 0);
            //anim.SetBool("Right", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (SpawnSystem.mode == 0)
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
        else if (SpawnSystem.mode == 1)
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

        else if (SpawnSystem.mode == 2)
        {
            if (other.GetComponent<BaseInfo>().shape == objShape)
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
