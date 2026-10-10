using UnityEngine;

public class DemoShooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float timeWait;

    float timeLate = -10;
   
    void Update()
    {
        if(Time.time - timeLate > timeWait)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            timeLate = Time.time;
        }
    }
}
