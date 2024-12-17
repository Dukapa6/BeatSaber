using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private float speed = 2f;
    public float Angle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //transform.Rotate (0, 0, Angle); 
       Angle = (Angle + speed) % 360f;
       transform.localRotation = Quaternion.Euler(new Vector3(45f,Angle,Angle ));
    }
}
