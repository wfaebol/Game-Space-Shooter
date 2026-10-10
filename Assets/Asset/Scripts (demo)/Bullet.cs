using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float flySpeed = 2.0f;
    [SerializeField] float timeDestroy = 2.0f;

    // Update is called once per frame
    void Update()
    {
        flyBullet();
        Destroy(gameObject, timeDestroy);
    }

    public void flyBullet()
    {
        var newPosition = transform.position;
        newPosition.y += flySpeed * Time.deltaTime;
        transform.position = newPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision) => Destroy(gameObject);
}
