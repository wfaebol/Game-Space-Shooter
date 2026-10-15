using System.Collections;
using UnityEngine;

public class HpPlayer : MonoBehaviour
{
    [SerializeField] int hpMax = 100;
    [SerializeField] GameObject effectDie;
    [SerializeField] float timeEffect = 1.0f;
    [SerializeField] float timeWaitDie = 5.0f;
    [SerializeField] CameraShake cameraShake;
    [SerializeField] int hpHeal = 50;

    int hp;

    private void Awake()
    {
        hp = hpMax;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Enemy") )
        {
            cameraShake.Play();

            var dame = collision.GetComponent<DameEnemy>();

            if(hp - dame.TakeDame() <= 0)
            {
                hp = 0;
                var effect = Instantiate(effectDie,transform.position, transform.rotation);
                Destroy(effect, timeEffect);
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

    public void GetItem()
    {
        hp = Mathf.Min(hp + hpHeal, hpMax);
    }
}
