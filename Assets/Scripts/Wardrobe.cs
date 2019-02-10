using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Wardrobe : MonoBehaviour
{
    [SerializeField]
    private bool isEmpty;

    private SpriteRenderer sr;

    [SerializeField]
    private Sprite spriteEmpty, spriteGhost;

    [SerializeField]
    private bool containHolyWater;

    public void AddHolyWater()
    {
        containHolyWater = true;
    }

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public bool Enter(ref int holyWaterCount)
    {
        if (containHolyWater)
        {
            holyWaterCount++;
            containHolyWater = false;
        }
        sr.sprite = spriteGhost;
        bool wasEmpty = isEmpty;
        isEmpty = true;
        return (wasEmpty);
    }

    public void Exit()
    {
        sr.sprite = spriteEmpty;
    }
}
