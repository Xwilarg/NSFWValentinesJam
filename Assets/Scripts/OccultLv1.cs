using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class OccultLv1 : MonoBehaviour
{
    private Rigidbody2D rb;
    private const float speed = 300f;
    private const float runSpeed = 600f;
    private const float maxDist = 2f;

    private bool goLeft;
    private bool isOnDoor = false;
    private PlayerController pc = null;
    [SerializeField]
    private LightCollision lightCollision;
    [SerializeField]
    private GameObject toSpawn;
    private bool playerFound;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        goLeft = true;
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerFound = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerFound != false && collision.name == "FinalDoor")
        {
            isOnDoor = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (playerFound != false && collision.name == "FinalDoor")
        {
            isOnDoor = true;
        }
    }

    private void Update()
    {
        if (!playerFound)
        {
            rb.velocity = new Vector2(((goLeft) ? -1 : 1) * speed * Time.deltaTime, rb.velocity.y);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(((goLeft) ? -1 : 1), 0f), maxDist, 1 << 10);
            if (hit.distance > 0f)
            {
                goLeft = !goLeft;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1f);
            }
            foreach (Collider2D collision in lightCollision.getCollidings())
            {
                if (collision.CompareTag("Player") && !pc.IsHiddenFromOccult())
                {
                    playerFound = true;
                    bool willGoLeft = this.transform.position.x < pc.transform.position.x;
                    if (willGoLeft != goLeft)
                    {
                        goLeft = !goLeft;
                        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1f);
                    }
                    rb.velocity = new Vector2((willGoLeft ? -1 : 1) * runSpeed * Time.deltaTime, rb.velocity.y);
                }
            }
        } else {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(((goLeft) ? -1 : 1), 0f), maxDist, 1 << 10);
            if (isOnDoor || hit.distance > 0.0001f)
            {
                GameObject go = Instantiate(toSpawn, gameObject.transform.position, gameObject.transform.rotation);
                SpriteRenderer mainSR = go.GetComponent<SpriteRenderer>();
                RoomManager manager = pc.transform.parent.GetComponent<RoomManager>();
                if (mainSR != null)
                    manager.AddSprite(mainSR);
                if (go.transform.childCount > 0)
                {
                    foreach (Transform t in go.transform)
                    {
                        SpriteRenderer sr = t.GetComponent<SpriteRenderer>();
                        if (sr != null)
                            manager.AddSprite(sr);
                    }
                }
                manager.RemoveSprite(GetComponent<SpriteRenderer>());
                manager.RemoveSprite(transform.GetChild(0).GetComponent<SpriteRenderer>());
                Destroy(gameObject);
            }
        }
    }
}