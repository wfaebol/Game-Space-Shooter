using System.Collections;
using UnityEngine;

public class DemoShooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float timeWaitLow = 0.1f;
    [SerializeField] float timeWaitNormal = 1.0f;
    [SerializeField] float timeItem = 5.0f;


    Coroutine shootCoroutine;
    float timeLate = -10;
    float timeWait;


    void Awake()
    {
        timeWait = timeWaitNormal;
    }

    void Update()
    {
        if(Time.time - timeLate > timeWait)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            timeLate = Time.time;
        }
    }

    public void GetItem()
    {
        if(shootCoroutine != null)
        {
            StopCoroutine(shootCoroutine);
        }

        shootCoroutine = StartCoroutine(ItemShootSpeed());
    }


    IEnumerator ItemShootSpeed()
    {
        timeWait = timeWaitLow;
        yield return new WaitForSeconds(timeItem);
        timeWait = timeWaitNormal;
        shootCoroutine = null;
    }
}
