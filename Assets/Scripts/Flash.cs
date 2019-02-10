using UnityEngine;
using UnityEngine.UI;

public class Flash : MonoBehaviour
{
    private Image image;
    private float alpha;
    private const float speed = 0.5f;

    private void Start()
    {
        image = GetComponent<Image>();
        alpha = 0f;
    }

    private void Update()
    {
        if (alpha > 0f)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            alpha -= Time.deltaTime * speed;
        }
    }

    public void FlashPanel()
    {
        alpha = 1f;
    }
}
