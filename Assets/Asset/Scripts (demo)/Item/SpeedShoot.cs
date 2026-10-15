using UnityEngine;

public class SpeedShoot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            DemoShooter demoShooter = collision.GetComponentInChildren<DemoShooter>();
            demoShooter.GetItem();
            Destroy(gameObject);
        }
    }
}
