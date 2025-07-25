using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreUpdate : MonoBehaviour
{

    public static int score = 0;
    public TextMeshProUGUI scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
    }
}
