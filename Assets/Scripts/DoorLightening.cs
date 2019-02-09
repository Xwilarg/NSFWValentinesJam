using System.Collections.Generic;
using UnityEngine;

public class DoorLightening : MonoBehaviour
{
    private List<GameObject> closeGos = new List<GameObject>();

    DoorLightening otherDoor;

    [SerializeField]
    private SpriteRenderer yellowLight, purpleLight;

    private void Start()
    {
        int tmp = 1;
        otherDoor = transform.parent.GetComponent<Door>().GetNextDoor(ref tmp).GetComponentInChildren<DoorLightening>();
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

    public void RemoveGo(GameObject go)
    {
        closeGos.Remove(go);
    }

    private void Update()
    {
        if (closeGos.Count == 0)
        {
            otherDoor.LightNone();
            return;
        }
        GameObject closest = null;
        float distance = float.MaxValue;
        foreach (GameObject go in closeGos)
        {
            float currDist = Vector2.Distance(transform.position, go.transform.position);
            if (closest == null || currDist < distance)
            {
                closest = go;
                distance = currDist;
            }
        }
        distance = Mathf.Clamp(distance, 0f, 10f);
        distance = 1f - distance / 10f;
        if (closest.GetComponent<AI>() != null)
            otherDoor.LightYellow(distance);
        else
            otherDoor.LightPurple(distance);
    }

    public void LightNone()
    {
        yellowLight.gameObject.SetActive(false);
        purpleLight.gameObject.SetActive(false);
    }

    public void LightYellow(float intensity)
    {
        yellowLight.gameObject.SetActive(true);
        yellowLight.color = new Color(yellowLight.color.r, yellowLight.color.g, yellowLight.color.b, intensity);
        purpleLight.gameObject.SetActive(false);
    }

    public void LightPurple(float intensity)
    {
        yellowLight.gameObject.SetActive(false);
        purpleLight.gameObject.SetActive(true);
        purpleLight.color = new Color(purpleLight.color.r, purpleLight.color.g, purpleLight.color.b, intensity);
    }
}
