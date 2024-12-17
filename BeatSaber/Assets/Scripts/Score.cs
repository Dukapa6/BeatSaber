using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    //public static int scoreValue = 0;
    // Text score;
    private TextMeshProUGUI textMesh;
    public static int score;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        score = 0;

    }


    void Update()
    {
        //score.text = "" + scoreValue;
        textMesh.text = score.ToString();
    }
}

