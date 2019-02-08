using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AI : MonoBehaviour
{
    private Rigidbody2D rb;
    private const float speed = 100f;
    private const float maxDist = 2f;

    private bool goLeft;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        goLeft = true;
    }

    private void Update()
    {
        rb.velocity = new Vector2(((goLeft) ? -1 : 1) * speed * Time.deltaTime, rb.velocity.y);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(((goLeft) ? -1 : 1), 0f), maxDist, 1 << 10);
        if (hit.distance > 0f)
            goLeft = !goLeft;
    }
}
