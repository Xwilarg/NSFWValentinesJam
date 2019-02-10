using UnityEngine;
using Sound.play;

[RequireComponent(typeof(SpriteRenderer))]
public class Door : MonoBehaviour
{
    [SerializeField]
    private Door door;

    [SerializeField]
    private playSound sound;
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
                    sound.play("lockedDoorOpen");
                    holyWaterCount--;
                    sr.sprite = unlockedSprite;
                    isLocked = false;
                }
                return (door);
            }
            return (null);
        }
        return (door);
    }
}
