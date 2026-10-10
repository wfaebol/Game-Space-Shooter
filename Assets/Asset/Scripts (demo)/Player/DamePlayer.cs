using UnityEngine;

public class DamePlayer : MonoBehaviour
{
    [SerializeField] int lowDame = 35;
    [SerializeField] int normalDame = 50;
    [SerializeField] int highDame = 100;

    int simpleDame;


    private void Start()
    {
        simpleDame = lowDame;
    }


    public int TakeDame()
    {
        return simpleDame;
    }
}
