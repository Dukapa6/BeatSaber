using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colour_Change : MonoBehaviour
{

    private void Awake()
    {
        
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //changing colour
        GetComponent<Renderer>().sharedMaterial.color = Random.ColorHSV();
    }
}
