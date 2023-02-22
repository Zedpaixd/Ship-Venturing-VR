using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshPro scoreTMP;
    [SerializeField] private int score = 0;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("BasketBall"))
        {
            score += 1;
            scoreTMP.text = "Score: " + score;
        }
    }
}
