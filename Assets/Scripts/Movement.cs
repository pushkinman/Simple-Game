using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    //speed of the obj
    static float speed;

    //possible parameters for generating an obj
    private string[] colors = new string[]{ "Red", "Yellow", "Green", "Blue"};
    private string[] numbers = new string[] { "1", "2", "3", "4" };
    private string[] shapes = new string[] { "Square", "Circle", "Heart", "Star" };

    //actual parameters for an obj
    public string objColor;
    public string objNumber;
    public string objShape;

    //prefabs for generating an obj
    public Material[] materials;
    public GameObject[] shapePrefabs;

    public Animator movementAnim;

    //Prefabs for particle effects
    public GameObject successParticle;
    public GameObject failureParticle;

    // Start is called before the first frame update
    void Start()
    {

        movementAnim = GetComponent<Animator>();

        //Choose random parameters
        objColor = colors[Random.Range(0, colors.Length)];
        objNumber = numbers[Random.Range(0, numbers.Length)];
        objShape = shapes[Random.Range(0, shapes.Length)];

        //Check which shape prefab to spawn
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

        //Check what material to select for object
        if (objColor == "Red")
            gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material.color = materials[0].color;
        else if (objColor == "Yellow")
            gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material.color = materials[1].color;
        else if (objColor == "Green")
            gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material.color = materials[2].color;
        else if (objColor == "Blue")
            gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material.color = materials[3].color;

        //Check what TextMesh value to select for object
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
        //get speed
        speed = SpawnSystem.startSpeed;
        //movement for obj (down)
        gameObject.transform.Translate(Vector3.down * speed * Time.deltaTime);

        //Input controll for obj
        if (Input.GetKeyDown(KeyCode.LeftArrow) && gameObject.transform.position.x > -1.5)
        {
            gameObject.transform.position += new Vector3(-1.5f, 0, 0);
            //movementAnim.SetTrigger("MoveLeft");
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && gameObject.transform.position.x < 1.5)
        {
            gameObject.transform.position += new Vector3(1.5f, 0, 0);
            //movementAnim.SetTrigger("MoveRight");
        }
    }

    //functions for animator
    public void MoveRight()
    {
        gameObject.transform.position += new Vector3(1.5f, 0, 0);
    }

    public void MoveLeft()
    {
        gameObject.transform.position += new Vector3(-1.5f, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {

        //Check for the collision of an obj with the right base in each mode
        if (SpawnSystem.mode == 0)
        {
            if(other.GetComponent<BaseInfo>().color == objColor)
            {
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Player>().score++;
                Destroy(gameObject);
                GameObject obj = Instantiate(successParticle);
                obj.transform.position = other.transform.position;
                Destroy(obj, 3f);
            }
            else
            {
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Player>().lives--;
                Destroy(gameObject);
                GameObject obj = Instantiate(failureParticle);
                obj.transform.position = other.transform.position;
                Destroy(obj, 3f);
            }
        }
        else if (SpawnSystem.mode == 1)
        {
            if (other.GetComponent<BaseInfo>().number == objNumber)
            {
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Player>().score++;
                Destroy(gameObject);
                GameObject obj = Instantiate(successParticle);
                obj.transform.position = other.transform.position;
                Destroy(obj, 3f);
            }
            else
            {
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Player>().lives--;
                Destroy(gameObject);
                GameObject obj = Instantiate(failureParticle);
                obj.transform.position = other.transform.position;
                Destroy(obj, 3f);
            }
        }

        else if (SpawnSystem.mode == 2)
        {
            if (other.GetComponent<BaseInfo>().shape == objShape)
            {
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Player>().score++;
                Destroy(gameObject);
                GameObject obj = Instantiate(successParticle);
                obj.transform.position = other.transform.position;
                Destroy(obj, 3f);
            }
            else
            {
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Player>().lives--;
                Destroy(gameObject);
                GameObject obj = Instantiate(failureParticle);
                obj.transform.position = other.transform.position;
                Destroy(obj, 3f);
            }
        }

        //if collided with anything else destoy the object to respawn
        Destroy(gameObject);
    }
}
