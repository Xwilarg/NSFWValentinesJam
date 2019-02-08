using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Wardrobe : MonoBehaviour
{
    private bool isEmpty;

    private SpriteRenderer sr;

    [SerializeField]
    private Sprite spriteEmpty, spriteGhost;

    private void Start()
    {
        isEmpty = false;
        sr = GetComponent<SpriteRenderer>();
    }

    public void Enter()
    {
        sr.sprite = spriteGhost;
        isEmpty = true;
    }

    public void Exit()
    {
        sr.sprite = spriteEmpty;
    }
}
