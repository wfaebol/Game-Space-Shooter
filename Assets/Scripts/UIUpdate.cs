using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdate : MonoBehaviour
{
    [Header("HP Slider")]
    [SerializeField] Slider hpSlider;
    [SerializeField] Health hp;


    [Header("Score Text")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper score;

    void Start()
    {
        hpSlider.maxValue = hp.GetHP();
        score = FindFirstObjectByType<ScoreKeeper>();
    }

    void Update()
    {
        hpSlider.value = hp.GetHP();
        scoreText.text = score.GetCurrentScore().ToString("000000000");
    }
}
