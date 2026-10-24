using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    const string HighScoreKey = "HighScore";

    int currentScore = 0;
    public int highScore { get; private set; }

    static ScoreKeeper instance;


    void Awake()
    {
        highScore = PlayerPrefs.GetInt(HighScoreKey, 0);

        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(HighScoreKey, 0);
    }

    public void SetCurrentScore(int score)
    {
        currentScore += score;
        currentScore = Mathf.Clamp(currentScore, 0, int.MaxValue);


        if(currentScore > highScore)
        {
            highScore = currentScore;

            PlayerPrefs.SetInt(HighScoreKey, highScore);
            PlayerPrefs.Save();
        }
    }

    public void ResetScore()
    {
        currentScore = 0;
    }
}
