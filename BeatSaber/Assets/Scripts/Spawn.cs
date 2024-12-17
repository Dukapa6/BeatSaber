using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] obstacles;
    public Transform[] spawn_points;
    public float beat;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > beat)
        {
            GameObject obstacle = Instantiate(obstacles[Random.Range(0, 2)], spawn_points[Random.Range(0, 4)]);
            obstacle.transform.localPosition = Vector3.zero;
            obstacle.transform.Rotate(transform.forward, 90 * Random.Range(0,4));
            timer -= beat;
        }

        timer += Time.deltaTime;
    }
}
