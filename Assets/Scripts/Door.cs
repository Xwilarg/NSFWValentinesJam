using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Door : MonoBehaviour
{
    [SerializeField]
    private Door door;

    [SerializeField]
    private bool isLocked;

    [SerializeField]
    private Sprite unlockedSprite;

    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void SetDoor(Door d)
    {
        door = d;
    }

    public Door GetNextDoor(ref int? holyWaterCount)
    {
        if (isLocked)
        {
            if (holyWaterCount == null || holyWaterCount > 0)
            {
                if (holyWaterCount != null)
                {
                    holyWaterCount--;
                    sr.sprite = unlockedSprite;
                }
                return (door);
            }
            return (null);
        }
        return (door);
    }
}
