using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_Collision : MonoBehaviour
{
    public bool has_hit = false;
    public LayerMask Obstacles_Layer;
    private Vector3 Previous_Location;
    public AudioSource hitSound;

    // Start is called before the first frame update
    void Start()
    {
        hitSound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit,2, Obstacles_Layer))
        {
            //hit detection
            if (Vector3.Angle(transform.position - Previous_Location, hit.transform.up) > 90)
            {
                hitSound.Play();
                CubeCut.Cut(hit.transform.transform, transform.position);
               // Destroy(hit.transform.gameObject);
                if (!has_hit)
                {
                    has_hit = true;
                    Score.score += 1;
                    
                }
             
            }
        }
        Previous_Location = transform.position;
        has_hit = false;
    }
}

