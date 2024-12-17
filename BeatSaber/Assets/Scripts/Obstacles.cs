using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //change spawn speed here
        //easy
        // transform.position -= Time.deltaTime * transform.forward * 2;
        //hard
        transform.position -= Time.deltaTime * transform.forward * 4;
        //very hard
        //transform.position -= Time.deltaTime * transform.forward * 6;
    }
}

/*
public float spawnDuration = 1.5f;
public float spawnDecrement = 0.1f;
public float minimumSpawnDuration = 0.5f;

private float spawnTimer = 0;
// Start is called before the first frame update
void Start()
{

}

// Update is called once per frame
void Update()
{
 //change spawn speed here
 //easy
 // transform.position -= Time.deltaTime * transform.forward * 2;
 //hard
 spawnTimer -= Time.deltaTime;
 if(spawnTimer <= 0f)
 {
     transform.position -= Time.deltaTime * transform.forward * 4;
     spawnDuration -= spawnDecrement;
     if (spawnDuration < minimumSpawnDuration)
     {
         spawnDuration = minimumSpawnDuration;
     }
     spawnTimer = spawnDuration;
 }

 //very hard
 //transform.position -= Time.deltaTime * transform.forward * 6;
}
*/
