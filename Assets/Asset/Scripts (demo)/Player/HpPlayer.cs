using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HpPlayer : MonoBehaviour
{
    [SerializeField] int hpMax = 100;
    [SerializeField] GameObject effectDie;
    [SerializeField] float timeEffect = 1.0f;
    [SerializeField] CameraShake cameraShake;
    [SerializeField] int hpHeal = 50;

    int hp;
    LevelManager levelManager;
    

    private void Awake()
    {
        hp = hpMax;
    }

    private void Start()
    {
        levelManager = FindFirstObjectByType<LevelManager>();
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
                Destroy(gameObject);
                levelManager.GameOver();
            }

            else
            {
                hp -= dame.TakeDame();
            }
        }
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
