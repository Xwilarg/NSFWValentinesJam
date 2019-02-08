using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class OccultLv1 : MonoBehaviour
{
    private Rigidbody2D rb;
    private const float speed = 100f;
    private const float runSpeed = 300f;
    private const float maxDist = 2f;

    private bool goLeft;
    private bool isOnDoor = false;
    private PlayerController pc = null;
    [SerializeField]
    private LightCollision lightCollision;
    [SerializeField]
    private GameObject toSpawn;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        goLeft = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (pc != null && collision.CompareTag("Door"))
        {
            isOnDoor = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (pc != null && collision.CompareTag("Door"))
        {
            isOnDoor = true;
        }
    }

    private void Update()
    {
        if (pc == null)
        {
            rb.velocity = new Vector2(((goLeft) ? -1 : 1) * speed * Time.deltaTime, rb.velocity.y);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(((goLeft) ? -1 : 1), 0f), maxDist, 1 << 10);
            if (hit.distance > 0f)
            {
                goLeft = !goLeft;
                transform.localScale *= -1;
            }
            foreach (Collider2D collision in lightCollision.getCollidings())
            {
                if (collision.CompareTag("Player"))
                {
                    pc = collision.GetComponent<PlayerController>();
                    bool willGoLeft = this.transform.position.x < pc.transform.position.x;
                    if (willGoLeft != goLeft)
                    {
                        goLeft = !goLeft;
                        transform.localScale *= -1;
                    }
                    rb.velocity = new Vector2((willGoLeft ? -1 : 1) * runSpeed * Time.deltaTime, rb.velocity.y);
                }
            }
        } else {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(((goLeft) ? -1 : 1), 0f), maxDist, 1 << 10);
            if (isOnDoor || hit.distance > 0f)
            {
                Instantiate(toSpawn, gameObject.transform.position, gameObject.transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}