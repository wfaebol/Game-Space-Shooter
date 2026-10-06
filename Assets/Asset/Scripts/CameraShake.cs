using System.Collections;
using NUnit.Framework.Constraints;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 0f;
    [SerializeField] float shakeMagnitude = 0f;

    Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    public void Play()
    {
        StartCoroutine(ShakeCamera());
    }

    IEnumerator ShakeCamera()
    {
        float timeElased = 0f;

        while(timeElased < shakeDuration)
        {
            transform.position = initialPosition + ((Vector3)Random.insideUnitCircle * shakeMagnitude);
            timeElased += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        transform.position = initialPosition;
    }
}
