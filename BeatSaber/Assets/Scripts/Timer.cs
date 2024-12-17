using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



 public class Timer : MonoBehaviour
{
   // public static int scoreValue = 0;
    // Text score;
    private TextMeshProUGUI textMesh;
    public static int timer;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        timer = 25145;

    }


    void Update()
    {
        if(timer <= 0)
        {
            Debug.Log("Times Up");
            Time.timeScale = 0;
        }
        //score.text = "" + scoreValue;
        textMesh.text = timer.ToString();
        if(timer > 0)
        {
            timer--;
        }
    }
}

