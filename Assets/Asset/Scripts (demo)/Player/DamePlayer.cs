using System.Collections;
using UnityEngine;

public class DamePlayer : MonoBehaviour
{
    [SerializeField] int normalDame = 50;
    [SerializeField] int highDame = 100;
    [SerializeField] float timeItem = 5f;

    int simpleDame;
    Coroutine DameCoroutine;


    private void Awake()
    {
        simpleDame = normalDame;
    }


    public int TakeDame()
    {
        return simpleDame;
    }

    public void GetItem()
    {
        if(DameCoroutine != null)
        {
            StopCoroutine(DameCoroutine);
        }

        DameCoroutine = StartCoroutine(AddDame());
    }

    IEnumerator AddDame()
    {
        simpleDame = highDame;
        yield return new WaitForSeconds(timeItem);
        simpleDame = normalDame;
        DameCoroutine = null;
    }
}
