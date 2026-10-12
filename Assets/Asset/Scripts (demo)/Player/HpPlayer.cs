using System.Collections;
using UnityEngine;

public class HpPlayer : MonoBehaviour
{
    [SerializeField] int hp = 100;
    [SerializeField] GameObject effectDie;
    [SerializeField] float timeEffect = 1.0f;
    [SerializeField] float timeWaitDie = 5.0f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Enemy") )
        {
            var dame = collision.GetComponent<DameEnemy>();

            if(hp - dame.TakeDame() <= 0)
            {
                hp = 0;
                var effect = Instantiate(effectDie,transform.position, transform.rotation);
                Destroy(effect, 4);
                StartCoroutine(WaitDie(timeWaitDie));
                Destroy(gameObject);
            }

            else
            {
                hp -= dame.TakeDame();
            }
        }
    }

    IEnumerator WaitDie(float time)
    {
        yield return new WaitForSeconds(time);
    }

    public int GetHp()
    {
        return hp;
    }
}
