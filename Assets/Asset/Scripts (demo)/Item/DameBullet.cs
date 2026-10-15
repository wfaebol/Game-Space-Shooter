using UnityEngine;

public class DameBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            DamePlayer damePlayer = collision.GetComponent<DamePlayer>();
            damePlayer.GetItem();
            Destroy(gameObject);
        }
    }
}
