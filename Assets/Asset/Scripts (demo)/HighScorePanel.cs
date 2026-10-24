using TMPro;
using UnityEngine;

public class HighScorePanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] GameObject panelHighScore;

    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }

    private void Start()
    {
        UpdateHighScoreText();
        panelHighScore.SetActive(false);
    }

    public void OpenPanel()
    {
        UpdateHighScoreText();
        panelHighScore.SetActive(true);
    }

    public void ClosePanel()
    {
        panelHighScore.SetActive(false);
    }

    void UpdateHighScoreText()
    {
        int highScore = scoreKeeper.GetHighScore();
        highScoreText.text = "High score: " + highScore.ToString();
    }
}
