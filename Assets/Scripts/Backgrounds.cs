using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgrounds : MonoBehaviour
{
    public Texture[] wallpapers;
    public GameObject plane;
    
    // Start is called before the first frame update
    void Start()
    {
        plane.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", wallpapers[Random.Range(0, wallpapers.Length)]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
