using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;


    public void UpdateScore(int newScore)
    {

        scoreText.text = "Score: " + newScore.ToString();

    }
}
