using UnityEngine;

public class ItemMovement : MonoBehaviour
{
    [SerializeField] float movespeed = -1f;

    void Update()
    {
        transform.position += new Vector3(0f, movespeed*Time.deltaTime, 0f);
    }
}
