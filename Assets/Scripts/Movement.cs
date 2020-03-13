using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    static float speed;
    public Animator anim;

    private string[] colors = new string[]{ "Red", "Yellow", "Green", "Blue", "Purple"};
    private string[] numbers = new string[5] { "1", "2", "3", "4", "5" };
    //private string[] numbers = new string[5] { "1", "2", "3", "4", "5" };

    public string objColor;
    public string objNumber;

    public Material[] materials;
    
    // Start is called before the first frame update
    void Start()
    {
        
        anim = GetComponent<Animator>();
        objColor = colors[Random.Range(0, colors.Length)];
        objNumber = numbers[Random.Range(0, colors.Length)];
        if (objColor == "Red")
            gameObject.GetComponent<MeshRenderer>().material.color = materials[0].color;
        if (objColor == "Yellow")
            gameObject.GetComponent<MeshRenderer>().material.color = materials[1].color;
        if (objColor == "Green")
            gameObject.GetComponent<MeshRenderer>().material.color = materials[2].color;
        if (objColor == "Blue")
            gameObject.GetComponent<MeshRenderer>().material.color = materials[3].color;
        if (objColor == "Purple")
            gameObject.GetComponent<MeshRenderer>().material.color = materials[4].color;

        if (objNumber == "1")
        {
            gameObject.transform.GetChild(0).GetComponent<TextMesh>().text = "1";
            gameObject.transform.GetChild(0).GetChild(0).GetComponent<TextMesh>().text = "1";
        }
        if (objNumber == "2")
        {
            gameObject.transform.GetChild(0).GetComponent<TextMesh>().text = "2";
            gameObject.transform.GetChild(0).GetChild(0).GetComponent<TextMesh>().text = "2";
        }
        if (objNumber == "3")
        {
            gameObject.transform.GetChild(0).GetComponent<TextMesh>().text = "3";
            gameObject.transform.GetChild(0).GetChild(0).GetComponent<TextMesh>().text = "3";
        }
            
        if (objNumber == "4")
        {
            gameObject.transform.GetChild(0).GetComponent<TextMesh>().text = "4";
            gameObject.transform.GetChild(0).GetChild(0).GetComponent<TextMesh>().text = "4";
        }
            
        if (objNumber == "5")
        {
            gameObject.transform.GetChild(0).GetComponent<TextMesh>().text = "5";
            gameObject.transform.GetChild(0).GetChild(0).GetComponent<TextMesh>().text = "5";
        }
           
    }

    // Update is called once per frame
    void Update()
    {
        

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

        Destroy(gameObject);
    }
}
