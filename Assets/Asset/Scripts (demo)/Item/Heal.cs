using UnityEngine;

public class Heal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            HpPlayer hpPlayer = collision.GetComponent<HpPlayer>();
            hpPlayer.GetItem();
            Destroy(gameObject);
        }
    }
}