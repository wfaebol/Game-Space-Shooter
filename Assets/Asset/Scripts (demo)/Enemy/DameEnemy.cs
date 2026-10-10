using UnityEngine;

public class DameEnemy : MonoBehaviour
{
    [SerializeField] int dameEnemy = 10;

    public int TakeDame()
    {
        return dameEnemy;
    }
}
