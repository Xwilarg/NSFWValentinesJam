using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
    private Sprite baseSprite, hiddenSprite;

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

    [SerializeField]
    private SpriteRenderer[] firstsClothes, secondsClothes;
    [SerializeField]
    private SpriteRenderer firstArm, secondArm;

    private AmbiantSoundManager soundManager;

    void updateLife(float life)
    {
        this.life = life;
        SpriteRenderer tmpSr = clothesLife[currSprite];
        tmpSr.color = new Color(tmpSr.color.r, tmpSr.color.g, tmpSr.color.b, life / maxLife);
        if (currSprite == 0)
        {
            foreach (SpriteRenderer tsr in firstsClothes)
                tsr.color = new Color(tsr.color.r, tsr.color.g, tsr.color.b, life / maxLife);
        }
        if (this.life == 0)
        {
            sound.source.volume = 1;
            sound.play(new string[] { "cum1", "cum2", "cum3", "cum4", "cum5"});
            currSprite++;
            this.life = maxLife;
            if (currSprite == 3)
            {
                soundManager.normalAudio.volume = 0f;
                soundManager.dangerAudio.volume = 0.6f;
            }
            else if (currSprite == 5)
                GameOver(GameOverManager.EndType.DeathLight);
        }
        sliderClothes.value = this.life / maxLife;
    }

    private bool isHidding, isInWardrobe;

    private GameObject currentDoor, currentWardrobe;

    public void TakeDamage()
    {
        float newLife = life - (4f * Time.deltaTime);
        if (newLife < 0.0f)
        {
            newLife = 0.0f;
        }
        updateLife(newLife);
    }

    public bool IsHidden()
    {
        return (isHidding);
    }

    public bool IsInWardrobe()
    {
        return (isInWardrobe);
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
            else if (currentWardrobe != null && !isHidding)
            {
                if (isInWardrobe)
                {
                    gameObject.layer = 8;
                    foreach (Transform t in gameObject.transform)
                        t.gameObject.layer = 8;
                    sr.enabled = true;
                    foreach (SpriteRenderer tmpSr in clothesLife)
                        tmpSr.enabled = true;
                    foreach (SpriteRenderer s in firstsClothes)
                        s.enabled = true;
                    firstArm.enabled = true;
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
                    foreach (SpriteRenderer s in firstsClothes)
                        s.enabled = false;
                    firstArm.enabled = false;
                    bool wasEmpty = currentWardrobe.GetComponent<Wardrobe>().Enter(ref holyWaterCount);
                    if (!wasEmpty)
                        life += Random.Range(1f, 2f);
                    if (life > maxLife)
                        life = maxLife;
                    sliderClothes.value = life / maxLife;
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
            foreach (SpriteRenderer s in firstsClothes)
                s.enabled = false;
            foreach (SpriteRenderer s in secondsClothes)
                s.enabled = true;
            firstArm.enabled = false;
            secondArm.enabled = true;
            sr.sprite = hiddenSprite;
            rb.velocity = Vector2.zero;
            isHidding = true;
            transform.parent.GetComponent<RoomManager>().DisableAll();
            sound.source.volume = 1;
            sound.loopPlay("breathing");
        }
        else if (Input.GetButtonUp("Hide"))
        {
            foreach (SpriteRenderer s in firstsClothes)
                s.enabled = true;
            foreach (SpriteRenderer s in secondsClothes)
                s.enabled = false;
            firstArm.enabled = true;
            secondArm.enabled = false;
            sr.sprite = baseSprite;
            sound.loopStop();
            sound.source.volume = 0;
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
        if (currMentalHealth == 0)
            GameOver(GameOverManager.EndType.DeathSouls);
        sliderMentalHealth.value = (float)currMentalHealth / maxMentalHealth;
    }

    private void GameOver(GameOverManager.EndType type)
    {
        GameObject go = new GameObject("GameOverManager", typeof(GameOverManager));
        go.GetComponent<GameOverManager>().type = type;
        SceneManager.LoadScene("Ending");
    }
}
