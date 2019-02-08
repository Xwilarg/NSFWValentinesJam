using System.Collections.Generic;
using UnityEngine;

public class DoorLightening : MonoBehaviour
{
    private List<GameObject> closeGos;

    private void Start()
    {
        closeGos = new List<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("AI"))
            closeGos.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("AI"))
            closeGos.Remove(collision.gameObject);
    }
}
