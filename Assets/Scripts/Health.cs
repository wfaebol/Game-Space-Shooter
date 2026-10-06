using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int addScore = 100;
    [SerializeField] int hp = 100;
    [SerializeField] ParticleSystem hitParticle;


    [SerializeField] bool applyShake;
    CameraShake cameraShake;
    AudioManager takeDameAudio;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;


    void Start()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        takeDameAudio = FindFirstObjectByType<AudioManager>();
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
        levelManager = FindFirstObjectByType<LevelManager>();
    }


    void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if(damageDealer != null)
        {
            PlayHitParticle();
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();

            if(applyShake)
            {
                cameraShake.Play();
            }

            takeDameAudio.PlayTakeDameSFX();
        }
    }


    void TakeDamage(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if(isPlayer)
        {
            levelManager.GameOver();        }
        else
        {
            scoreKeeper.SetCurrentScore(addScore);
        }
        Destroy(gameObject);
    }

    void PlayHitParticle()
    {
        ParticleSystem particle = Instantiate(hitParticle, transform.position, Quaternion.identity);
        Destroy(particle, particle.main.duration + particle.main.startLifetime.constantMax);
    }

    public int GetHP()
    {
        return hp;
    }
}