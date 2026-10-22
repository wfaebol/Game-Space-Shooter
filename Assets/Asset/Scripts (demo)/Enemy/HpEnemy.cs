using UnityEngine;

public class HpEnemy : MonoBehaviour
{
    [SerializeField] GameObject effectDie;
    [SerializeField] float timeEffect = 1.0f;
    [SerializeField] int hp = 100;
    [SerializeField] int score = 100;

    ParticleSystem particle;

    ScoreKeeper addScore;

    DamePlayer takeDame;
    AudioManager audioManager;


    private void Start()
    {
        takeDame = FindFirstObjectByType<DamePlayer>();
        addScore = FindFirstObjectByType<ScoreKeeper>();
        particle = GetComponent<ParticleSystem>();
        audioManager = FindFirstObjectByType<AudioManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(hp - takeDame.TakeDame() > 0)
        {
            particle.Play();
            audioManager.PlayTakeDameSFX();
            hp -= takeDame.TakeDame();
        }

        else
        {
            addScore.SetCurrentScore(score);
            var effect = Instantiate(effectDie, transform.position, transform.rotation);
            Destroy(effect, timeEffect);
            Destroy(gameObject);
        }
    }
}