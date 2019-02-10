using UnityEngine;
using Sound.play;

[RequireComponent(typeof(Rigidbody2D))]
public class AI : MonoBehaviour
{
    [SerializeField]
    private playSound sound;
    private bool playloop;
    private Rigidbody2D rb;
    private const float speed = 300f;
    private const float maxDist = 2f;
    private PlayerController pc;
    private bool goLeft;
    public bool isMoving { set; private get; }

    [SerializeField]
    private LightCollision lightCollision;

    private void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        goLeft = true;
        isMoving = true;
    }

    private void Update()
    {
        foreach (Collider2D collision in lightCollision.getCollidings()) {
            try
            {
                if (collision.CompareTag("Player"))
                {
                    PlayerController pc = collision.GetComponent<PlayerController>();
                    if (!pc.IsHidden())
                        pc.TakeDamage();
                }
            }
            catch (System.Exception)
            { }
        }
        if (!isMoving && !pc.IsHidden())
        {
            playloop = false;
            sound.loopStop();
            rb.velocity = Vector2.zero;
            return;
        } else if (playloop == false)
        {
            playloop = true;
            sound.loopPlay("footstep");
        }
        rb.velocity = new Vector2(((goLeft) ? -1 : 1) * speed * Time.deltaTime, rb.velocity.y);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(((goLeft) ? -1 : 1), 0f), maxDist, 1 << 10);
        if (hit.distance > 0f)
        {
            goLeft = !goLeft;
            transform.localScale *= -1;
        }
    }
}
