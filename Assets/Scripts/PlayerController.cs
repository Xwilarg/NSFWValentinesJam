using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private const float speed = 600f;

    [SerializeField]
    private Sprite hiddenSprite, baseSprite;

    private bool isHidding;

    private GameObject currentDoor;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        isHidding = false;
    }

    private void Update()
    {
        if (!isHidding)
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * Time.deltaTime * speed, rb.velocity.y);
        if (Input.GetButtonDown("Hide"))
        {
            sr.sprite = hiddenSprite;
            rb.velocity = Vector2.zero;
            isHidding = true;
        }
        else if (Input.GetButtonUp("Hide"))
        {
            sr.sprite = baseSprite;
            isHidding = false;
        }
        if (Input.GetButtonDown("Interract") && currentDoor != null)
            transform.position = currentDoor.GetComponent<Door>().GetDoorPosition();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))
            currentDoor = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))
            currentDoor = null;
    }
}
