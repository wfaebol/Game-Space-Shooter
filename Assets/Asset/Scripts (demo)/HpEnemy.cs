using UnityEngine;

public class HpEnemy : MonoBehaviour
{
    [SerializeField] GameObject effectDie;
    [SerializeField] float timeEffect = 1.0f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
            var effect = Instantiate(effectDie, transform.position, transform.rotation);
            Destroy(effect, timeEffect);
            Destroy(gameObject);
    }
}
