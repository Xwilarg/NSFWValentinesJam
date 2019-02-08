using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Soul : MonoBehaviour
{
    private const float speed = 200f;
    private float angle;

    private Rigidbody2D rb;

    private void Start()
    {
        angle = Random.Range(0f, 2 * Mathf.PI);
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * Time.deltaTime * speed;
        if (rb.velocity.x < -.0001f)
            transform.localScale = new Vector3(1f, 1f, 1f);
        if (rb.velocity.x > .0001f)
            transform.localScale = new Vector3(-1f, 1f, 1f);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        angle = Random.Range(0f, 2 * Mathf.PI);
    }
}