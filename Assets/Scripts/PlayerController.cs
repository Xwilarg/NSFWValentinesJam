using UnityEngine;
using UnityEngine.UI;
using Sound;
using Sound.play;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private playSound sound;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private const float speed = 600f;

    private const int maxMentalHealth = 5;
    private int currMentalHealth;

    [SerializeField]
    private Sprite hiddenSprite, baseSprite;

    [SerializeField]
    private int maxLife = 1;
    float life;
    [SerializeField]
    private Slider sliderClothes, sliderMentalHealth;

    private int holyWaterCount;

    [SerializeField]
    private Text holyWaterText;

    private int currSprite = 0;

    [SerializeField]
    private SpriteRenderer[] clothesLife;

    private AmbiantSoundManager soundManager;

    void updateLife(float life)
    {
        this.life = life;
        SpriteRenderer tmpSr = clothesLife[currSprite];
        tmpSr.color = new Color(tmpSr.color.r, tmpSr.color.g, tmpSr.color.b, life / maxLife);
        if (this.life == 0)
        {
            currSprite++;
            this.life = maxLife;
            if (currSprite == 3)
            {
                soundManager.normalAudio.volume = 0f;
                soundManager.dangerAudio.volume = 1f;
            }
        }
        sliderClothes.value = this.life / maxLife;
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
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<AmbiantSoundManager>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        updateLife(maxLife);
        isHidding = false;
        isInWardrobe = false;
        currentDoor = null;
        currentWardrobe = null;
        holyWaterCount = 0;
        currMentalHealth = maxMentalHealth;
        currSprite = 0;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interract"))
        {
            if (!isHidding && currentDoor != null)
            {
                int? tmp = holyWaterCount;
                Door d = currentDoor.GetComponent<Door>().GetNextDoor(ref tmp);
                holyWaterCount = tmp.Value;
                if (d != null)
                {
                    transform.position = d.transform.position;
                    transform.parent = d.transform.parent.parent;
                    currentDoor = d.gameObject;
                    holyWaterText.text = holyWaterCount.ToString();
                }
            }
            else if (currentWardrobe != null)
            {
                if (isInWardrobe)
                {
                    gameObject.layer = 8;
                    foreach (Transform t in gameObject.transform)
                        t.gameObject.layer = 8;
                    sr.enabled = true;
                    foreach (SpriteRenderer tmpSr in clothesLife)
                        tmpSr.enabled = true;
                    isInWardrobe = false;
                    currentWardrobe.GetComponent<Wardrobe>().Exit();
                }
                else
                {
                    gameObject.layer = 12;
                    foreach (Transform t in gameObject.transform)
                        t.gameObject.layer = 12;
                    rb.velocity = Vector2.zero;
                    isInWardrobe = true;
                    sr.enabled = false;
                    foreach (SpriteRenderer tmpSr in clothesLife)
                        tmpSr.enabled = false;
                    currentWardrobe.GetComponent<Wardrobe>().Enter(ref holyWaterCount);
                    holyWaterText.text = holyWaterCount.ToString();
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
            sound.loopPlay("breathing");
        }
        else if (Input.GetButtonUp("Hide"))
        {
            sound.loopStop();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Soul")
        {
            LooseMentalHealth();
            transform.parent.GetComponent<RoomManager>().RemoveSprite(collision.collider.GetComponent<SpriteRenderer>());
            foreach (DoorLightening d in transform.parent.GetComponentsInChildren<DoorLightening>())
                d.RemoveGo(collision.collider.gameObject);
            Destroy(collision.collider.gameObject);
        }
    }

    private void LooseMentalHealth()
    {
        var ghostSound = new GameObject("SoulSound", typeof(AudioSource));
        var source = ghostSound.GetComponent<AudioSource>();

        source.clip = sound.GetSoundManager().sounds["dmgSoul"];
        source.Play();
        Destroy(ghostSound, source.clip.length);
        currMentalHealth--;
        sliderMentalHealth.value = (float)currMentalHealth / maxMentalHealth;
        // TODO: GameOver
    }
}
