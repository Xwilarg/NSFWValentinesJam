using UnityEngine;

public class Shake : MonoBehaviour
{
    private float shakeTimer;
    private const float shakeTimerRef = 1f;
    private const float shakeForceRef = 0.8f;
    private float shakeForce;
    private Vector3 basePos;

    private void Start()
    {
        shakeTimer = 0f;
        basePos = transform.position;
    }

    public void ShakeCamera()
    {
        shakeTimer = shakeTimerRef;
        shakeForce = shakeForceRef;
    }

    private void Update()
    {
        if (shakeTimer > 0f)
        {
            transform.localPosition = basePos + Random.insideUnitSphere * shakeForce * shakeTimer;
            shakeForce -= Time.deltaTime * .1f;
            shakeTimer -= Time.deltaTime;
        }
        else
            transform.position = basePos;
    }
}
