using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    ScoreKeeper score;


    void Awake()
    {
        score = FindFirstObjectByType<ScoreKeeper>();
    }

    void Start()
    {
        scoreText.text = "Score: " + score.GetCurrentScore().ToString();
        score.ResetScore();
    }
}
