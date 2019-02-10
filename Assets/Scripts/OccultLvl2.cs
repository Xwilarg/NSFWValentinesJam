using UnityEngine;

public class OccultLvl2 : MonoBehaviour
{
    private Rigidbody2D rb;
    private const float speed = 300f;
    private const float maxDist = 2f;
    private PlayerController pc;
    private bool goLeft;

    [SerializeField]
    private LightCollision lightCollision;

    private void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        goLeft = true;
    }

    private void Update()
    {
        foreach (Collider2D collision in lightCollision.getCollidings())
        {
            if (collision.CompareTag("Player"))
            {
                PlayerController pc = collision.GetComponent<PlayerController>();
                if (!pc.IsHiddenFromOccult())
                    pc.TakeDamage();
            }
        }
        rb.velocity = new Vector2(((goLeft) ? -1 : 1) * speed * Time.deltaTime, rb.velocity.y);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(((goLeft) ? -1 : 1), 0f), maxDist, 1 << 10);
        if (hit.distance > 0.0001f)
        {
            goLeft = !goLeft;
            transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, 1f);
        }
    }
}
