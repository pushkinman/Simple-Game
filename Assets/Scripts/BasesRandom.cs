using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BasesRandom : MonoBehaviour
{
    public GameObject[] bases;

    public GameObject[] shapesPrefabs;
    public Material[] colorsPrefabs;
    public GameObject[] numbersPrefabs;

    private List<GameObject> activeShapes;

    private string[] shapes = new string[4] { "Square", "Circle", "Heart", "Star" };
    private string[] colors = new string[4] { "Green", "Blue", "Red", "Yellow" };
    private string[] numbers = new string[4] { "1", "2", "3", "4" };

    List<string> shapesOrder;
    List<string> colorsOrder;
    List<string> numbersOrder;

    // Start is called before the first frame update
    void Start()
    {
        shapesOrder = new List<string>();
        colorsOrder = new List<string>();
        numbersOrder = new List<string>();

        activeShapes = new List<GameObject>();

        //filling main Lists;

        for (int i = 0; i < shapes.Length; i++)
            shapesOrder.Add(shapes[i]);

        for (int i = 0; i < colors.Length; i++)
            colorsOrder.Add(colors[i]);

        for (int i = 0; i < numbers.Length; i++)
            numbersOrder.Add(numbers[i]);

        //first render;

        Shuffle(shapesOrder);
        Shuffle(colorsOrder);
        Shuffle(numbersOrder);

        for (int i = 0; i < shapesOrder.Count; i++)
        {
            bases[i].GetComponent<BaseInfo>().shape = shapesOrder.ElementAt(i);
            bases[i].GetComponent<BaseInfo>().color = colorsOrder.ElementAt(i);
            bases[i].GetComponent<BaseInfo>().number = numbersOrder.ElementAt(i);
        }

        SpawnBases();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(bases[0].transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material == null);


        if (Input.GetKeyDown(KeyCode.M))
        {
            foreach (GameObject obj in activeShapes)
            {
                Destroy(obj);
            }
            Shuffle(shapesOrder);
            Shuffle(colorsOrder);
            Shuffle(numbersOrder);
            for (int i = 0; i < shapesOrder.Count; i++)
            {
                bases[i].GetComponent<BaseInfo>().shape = shapesOrder.ElementAt(i);
                bases[i].GetComponent<BaseInfo>().color = colorsOrder.ElementAt(i);
                bases[i].GetComponent<BaseInfo>().number = numbersOrder.ElementAt(i);
            }
            //SpawnBases();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {

            SpawnBases();
        }
    }

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

    public void SpawnBases()
    {
      

        foreach (GameObject baseObj in bases)
        {
            string baseObjShape = baseObj.GetComponent<BaseInfo>().shape;
            string baseObjColor = baseObj.GetComponent<BaseInfo>().color;
            string baseObjNumber = baseObj.GetComponent<BaseInfo>().number;

            //check for shape

            if(baseObjShape == "Square")
            {
                GameObject pref = Instantiate(shapesPrefabs[0]);
                pref.transform.localScale = new Vector3(0.61f, 0.61f, 0.015f);
                activeShapes.Add(pref);
                pref.transform.position = baseObj.transform.position;
                pref.transform.parent = baseObj.transform;
            }
            if (baseObjShape == "Circle")
            {
                GameObject pref = Instantiate(shapesPrefabs[1]);
                pref.transform.localScale = new Vector3(0.61f, 0.015f, 0.61f);
                activeShapes.Add(pref);
                pref.transform.position = baseObj.transform.position;
                pref.transform.parent = baseObj.transform;
            }
            if (baseObjShape == "Heart")
            {
                GameObject pref = Instantiate(shapesPrefabs[2]);
                pref.transform.localScale = new Vector3(0.61f, 0.015f, 0.61f);
                activeShapes.Add(pref);
                pref.transform.position = baseObj.transform.position;
                pref.transform.parent = baseObj.transform;
            }
            if (baseObjShape == "Star")
            {
                GameObject pref = Instantiate(shapesPrefabs[3]);
                pref.transform.localScale = new Vector3(0.61f, 0.015f, 0.61f);
                activeShapes.Add(pref);
                pref.transform.position = baseObj.transform.position;
                pref.transform.parent = baseObj.transform;
            }

        }

        foreach (GameObject baseObj in bases)
        {
            string baseObjShape = baseObj.GetComponent<BaseInfo>().shape;
            string baseObjColor = baseObj.GetComponent<BaseInfo>().color;
            string baseObjNumber = baseObj.GetComponent<BaseInfo>().number;

            //check for color

            if (baseObjColor == "Green")
            {
                baseObj.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material =
                    colorsPrefabs[0];
                Debug.Log("were");
            }
            if (baseObjColor == "Blue")
            {
                baseObj.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material =
                    colorsPrefabs[1];
            }
            if (baseObjColor == "Red")
            {
                baseObj.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material =
                    colorsPrefabs[2];
            }
            if (baseObjColor == "Yellow")
            {
                baseObj.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material =
                    colorsPrefabs[3];
            }
        }

        foreach (GameObject baseObj in bases)
        {
            string baseObjShape = baseObj.GetComponent<BaseInfo>().shape;
            string baseObjColor = baseObj.GetComponent<BaseInfo>().color;
            string baseObjNumber = baseObj.GetComponent<BaseInfo>().number;

            //check for color

            if (baseObjColor == "1")
            {
                baseObj.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material =
                    colorsPrefabs[0];
                Debug.Log("were");
            }
           
        }
    }
}
