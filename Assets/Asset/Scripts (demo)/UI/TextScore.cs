using TMPro;
using UnityEngine;

public class TextScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    ScoreKeeper scoreKeeper;

    void Start()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }

    void Update()
    {
        scoreText.text = scoreKeeper.GetCurrentScore().ToString();
    }
}
