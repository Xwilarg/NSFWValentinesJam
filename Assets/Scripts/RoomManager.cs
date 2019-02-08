using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomManager : MonoBehaviour
{
    private List<TilemapRenderer> tilemapRenderers;
    private List<SpriteRenderer> spriteRenderers;

    private float timer;

    private void Start()
    {
        tilemapRenderers = new List<TilemapRenderer>();
        spriteRenderers = new List<SpriteRenderer>();
        SaveChildren(transform);
        timer = -1f;
    }

    private void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
            SetColor(timer);
        }
    }

    private void SaveChildren(Transform parent)
    {
        foreach (Transform t in parent)
        {
            if (t.CompareTag("Player"))
                continue;
            Renderer renderer = t.GetComponent<Renderer>();
            if (renderer != null)
            {
                TilemapRenderer tr = renderer as TilemapRenderer;
                if (tr != null)
                    tilemapRenderers.Add(tr);
                else
                    spriteRenderers.Add((SpriteRenderer)renderer);
            }
            if (t.childCount > 0)
                SaveChildren(t);
        }
    }

    private void SetColor(float color)
    {
        foreach (var v in tilemapRenderers)
            v.material.color = new Color(v.material.color.r, v.material.color.g, v.material.color.b, color);
        foreach (var v in spriteRenderers)
            v.color = new Color(v.material.color.r, v.material.color.g, v.material.color.b, color);
    }

    public void DisableAll()
    {
        timer = 1f;
    }

    public void EnableAll()
    {
        timer = -1f;
        SetColor(1f);
    }
}
