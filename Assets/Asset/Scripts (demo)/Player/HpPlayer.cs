using UnityEngine;

public class HpPlayer : MonoBehaviour
{
    [SerializeField] int hp = 100;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Enemy") )
        {
            
        }
    }
}
