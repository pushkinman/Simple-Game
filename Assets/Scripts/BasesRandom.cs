using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class BasesRandom : MonoBehaviour
{
    //actual bases in the scene
    public GameObject[] bases;

    //prefabs for each of the parameters
    public GameObject[] shapesPrefabs;
    public Material[] colorsPrefabs;

    //gameobjects that are going to spawn for each base
    private List<GameObject> activeShapes;

    //possible values for each base for 3 parameters
    private string[] shapes = new string[4] { "Square", "Circle", "Heart", "Star" };
    private string[] colors = new string[4] { "Green", "Blue", "Red", "Yellow" };
    private string[] numbers = new string[4] { "1", "2", "3", "4" };

    //List to shuffle for generating random order of the bases
    List<string> shapesOrder;
    List<string> colorsOrder;
    List<string> numbersOrder;

    // Start is called before the first frame update
    void Start()
    {
        //initialized lists for each of the parameter
        shapesOrder = new List<string>();
        colorsOrder = new List<string>();
        numbersOrder = new List<string>();

        //initialized list for game objects
        activeShapes = new List<GameObject>();

        //filling parameter list with all possible values;

        for (int i = 0; i < shapes.Length; i++)
            shapesOrder.Add(shapes[i]);

        for (int i = 0; i < colors.Length; i++)
            colorsOrder.Add(colors[i]);

        for (int i = 0; i < numbers.Length; i++)
            numbersOrder.Add(numbers[i]);
    }

    // Update is called once per frame
    public void UpdateBases()
    {
        //deleting previously stored active shapes
        foreach (GameObject obj in activeShapes)
        {
            Destroy(obj);
        }
        activeShapes = new List<GameObject>();

        //create random order of parameters in each list
        Shuffle(shapesOrder);
        Shuffle(colorsOrder);
        Shuffle(numbersOrder);

        //set text value for each base in "BaseInfo"
        for (int i = 0; i < shapesOrder.Count; i++)
        {
            bases[i].GetComponent<BaseInfo>().shape = shapesOrder.ElementAt(i);
            bases[i].GetComponent<BaseInfo>().color = colorsOrder.ElementAt(i);
            bases[i].GetComponent<BaseInfo>().number = numbersOrder.ElementAt(i);
        }

        //call method to spawn prefabs
        StartCoroutine(SpawnBases());
    }

    //list shuffle
    public void Shuffle(List<string> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            string value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public string baseObjShape;
    public string baseObjColor;
    public string baseObjNumber;

    public IEnumerator SpawnBases()
    {
        yield return new WaitForSeconds(0.1f);
        foreach (GameObject baseObj in bases)
        {
            //getting parameters for each base and storing them locally
            baseObjShape = baseObj.GetComponent<BaseInfo>().shape;
            baseObjColor = baseObj.GetComponent<BaseInfo>().color;
            baseObjNumber = baseObj.GetComponent<BaseInfo>().number;

            //Check to spawn the right shape
            if(baseObjShape == "Square")
            {
                GameObject pref = Instantiate(shapesPrefabs[0]);
                pref.transform.localScale = new Vector3(0.61f, 0.61f, 0.015f);
                activeShapes.Add(pref);
                pref.transform.position = baseObj.transform.position;
                pref.transform.parent = baseObj.transform;
            }
            else if (baseObjShape == "Circle")
            {
                GameObject pref = Instantiate(shapesPrefabs[1]);
                pref.transform.localScale = new Vector3(0.61f, 0.015f, 0.61f);
                activeShapes.Add(pref);
                pref.transform.position = baseObj.transform.position;
                pref.transform.parent = baseObj.transform;
            }
            else if (baseObjShape == "Heart")
            {
                GameObject pref = Instantiate(shapesPrefabs[2]);
                pref.transform.localScale = new Vector3(0.61f, 0.015f, 0.61f);
                activeShapes.Add(pref);
                pref.transform.position = baseObj.transform.position;
                pref.transform.parent = baseObj.transform;
            }
            else if (baseObjShape == "Star")
            {
                GameObject pref = Instantiate(shapesPrefabs[3]);
                pref.transform.localScale = new Vector3(0.61f, 0.015f, 0.61f);
                activeShapes.Add(pref);
                pref.transform.position = baseObj.transform.position;
                pref.transform.parent = baseObj.transform;
            }

            //Check to spawn the right color
            if (baseObjColor == "Green")
            {
                baseObj.transform.GetChild(0).GetComponent<MeshRenderer>().material =
                    colorsPrefabs[0];
                Debug.Log("Green");
            }
            else if (baseObjColor == "Blue")
            {
                baseObj.transform.GetChild(0).GetComponent<MeshRenderer>().material =
                    colorsPrefabs[1];
                Debug.Log("Blue");
            }
            else if (baseObjColor == "Red")
            {
                baseObj.transform.GetChild(0).GetComponent<MeshRenderer>().material =
                    colorsPrefabs[2];
                Debug.Log("Red");
            }
            else if (baseObjColor == "Yellow")
            {
                baseObj.transform.GetChild(0).GetComponent<MeshRenderer>().material =
                    colorsPrefabs[3];
                Debug.Log("Yellow");
            }

            //Check to spawn the right number
            if (baseObjNumber == "1")
            {
                baseObj.transform.GetChild(0).GetChild(0).GetComponent<TextMesh>().text = "1";
            }
            else if (baseObjNumber == "2")
            {
                baseObj.transform.GetChild(0).GetChild(0).GetComponent<TextMesh>().text = "2";
            }
            else if (baseObjNumber == "3")
            {
                baseObj.transform.GetChild(0).GetChild(0).GetComponent<TextMesh>().text = "3";
            }
            else if (baseObjNumber == "4")
            {
                baseObj.transform.GetChild(0).GetChild(0).GetComponent<TextMesh>().text = "4";
            }
        }

    }
}
