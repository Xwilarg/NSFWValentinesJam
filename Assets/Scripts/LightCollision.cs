using System.Collections.Generic;
using UnityEngine;

public class LightCollision : MonoBehaviour
{
    private List<Collider2D> collidings = new List<Collider2D>();

    private AI ai;

    private void Start()
    {
        ai = transform.parent.GetComponent<AI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && ai != null)
            ai.isMoving = false;
        collidings.Add(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && ai != null)
            ai.isMoving = true;
        collidings.Remove(collision);
    }

    public List<Collider2D> getCollidings()
    {
        return collidings;
    }
}
