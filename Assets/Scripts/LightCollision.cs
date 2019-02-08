using System.Collections.Generic;
using UnityEngine;

public class LightCollision : MonoBehaviour
{
    private List<Collider2D> collidings;

    private void Start()
    {
        collidings = new List<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collidings.Add(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collidings.Remove(collision);
    }

    public List<Collider2D> getCollidings()
    {
        return collidings;
    }
}
