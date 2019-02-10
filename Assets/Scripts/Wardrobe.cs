using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Wardrobe : MonoBehaviour
{
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
        isEmpty = false;
        sr = GetComponent<SpriteRenderer>();
    }

    public void Enter(ref int holyWaterCount)
    {
        if (containHolyWater)
        {
            holyWaterCount++;
            containHolyWater = false;
        }
        sr.sprite = spriteGhost;
        isEmpty = true;
    }

    public void Exit()
    {
        sr.sprite = spriteEmpty;
    }
}
