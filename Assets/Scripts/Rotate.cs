using UnityEngine;

public class Rotate : MonoBehaviour
{
    private const float speed = 5f;

    private void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, Time.deltaTime * speed));
    }
}
