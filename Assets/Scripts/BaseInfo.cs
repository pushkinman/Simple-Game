using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInfo : MonoBehaviour
{
    public string shape;
    public string color;
    public string number;

    bool notSpawned;
    
    // Start is called before the first frame update
    void Start()
    {
        notSpawned = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (notSpawned && shape != null && color != null && number != null)
        {

        }
    }
}
