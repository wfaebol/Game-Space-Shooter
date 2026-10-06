using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header ("Base Variables")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float baseFireRate = 0.4f;
    [SerializeField] float projectileLifeTime = 5f;

    [Header("AI Variables")]
    [SerializeField] float minFireRate = 0.4f;
    [SerializeField] float fireRateVariance = 0f;
    [SerializeField] bool useAI;
    [SerializeField] float waitTimeEnemy = 1f;


    [HideInInspector] public bool isFiring;
    Coroutine fireCoroutine;
    AudioManager audioShooting;


    void Start()
    {
        if(useAI)
        {
            StartCoroutine(WaitTimeEnemyShooting());
        }

        audioShooting = FindFirstObjectByType<AudioManager>();
    }


    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if(isFiring && fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(FireContinuously());
        }
        else if(!isFiring && fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while(true)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectile.transform.rotation = transform.rotation;
            Rigidbody2D projectileRB = projectile.GetComponent<Rigidbody2D>();
            projectileRB.linearVelocity = transform.up * projectileSpeed;
            audioShooting.PlayShootingSFX();

            Destroy(projectile, projectileLifeTime);

            float waitTime = Random.Range(baseFireRate - fireRateVariance, baseFireRate + fireRateVariance);
            waitTime = Mathf.Clamp(waitTime, minFireRate, float.MaxValue);
            yield return new WaitForSeconds(waitTime);
        }
    }

    IEnumerator WaitTimeEnemyShooting()
    {
        yield return new WaitForSeconds(waitTimeEnemy);
        isFiring = true;
    }
}
