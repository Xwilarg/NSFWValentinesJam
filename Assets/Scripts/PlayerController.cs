﻿using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private const float speed = 600f;

    [SerializeField]
    private Sprite hiddenSprite, baseSprite;

    [SerializeField]
    private int maxLife = 1;
    float life;
    [SerializeField]
    private Slider slider;

    private int holyWaterCount;

    [SerializeField]
    private Text holyWaterText;

    void updateLife(float life)
    {
        this.life = life;
        slider.value = life / maxLife;
    }

    private bool isHidding, isInWardrobe;

    private GameObject currentDoor, currentWardrobe;

    public void TakeDamage()
    {
        float tmp = life - 0.05f;
        tmp = (tmp >= 0.0f) ? tmp : 0.0f;
        updateLife(tmp);
    }

    public bool IsHidden()
    {
        return (isHidding || isInWardrobe);
    }

    public bool IsHiddenFromOccult()
    {
        return (isInWardrobe);
    }

    public bool IsHiddenOnlyNormal()
    {
        return (isHidding);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        updateLife(maxLife);
        isHidding = false;
        isInWardrobe = false;
        currentDoor = null;
        currentWardrobe = null;
        holyWaterCount = 0;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interract"))
        {
            if (!isHidding && currentDoor != null)
            {
                Door d = currentDoor.GetComponent<Door>().GetNextDoor(ref holyWaterCount);
                if (d != null)
                {
                    transform.position = d.transform.position;
                    transform.parent = d.transform.parent.parent;
                    currentDoor = d.gameObject;
                    holyWaterText.text = "Holy Water: " + holyWaterCount;
                }
            }
            else if (currentWardrobe != null)
            {
                if (isInWardrobe)
                {
                    sr.enabled = true;
                    isInWardrobe = false;
                    currentWardrobe.GetComponent<Wardrobe>().Exit();
                }
                else
                {
                    rb.velocity = Vector2.zero;
                    isInWardrobe = true;
                    sr.enabled = false;
                    currentWardrobe.GetComponent<Wardrobe>().Enter(ref holyWaterCount);
                    holyWaterText.text = "Holy Water: " + holyWaterCount;
                }
            }
        }
        if (isInWardrobe)
            return;
        if (!isHidding)
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * Time.deltaTime * speed, rb.velocity.y);
            if (rb.velocity.x < -.0001f)
                transform.localScale = new Vector3(1f, 1f, 1f);
            if (rb.velocity.x > .0001f)
                transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (Input.GetButtonDown("Hide"))
        {
            sr.sprite = hiddenSprite;
            rb.velocity = Vector2.zero;
            isHidding = true;
            transform.parent.GetComponent<RoomManager>().DisableAll();
        }
        else if (Input.GetButtonUp("Hide"))
        {
            sr.sprite = baseSprite;
            isHidding = false;
            transform.parent.GetComponent<RoomManager>().EnableAll();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))
            currentDoor = collision.gameObject;
        else if (collision.CompareTag("Wardrobe"))
            currentWardrobe = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))
        {
            if (currentDoor != null && currentDoor.name == collision.name)
                currentDoor = null;
        }
        else if (collision.CompareTag("Wardrobe"))
            currentWardrobe = null;
    }
}
