using System.Collections.Generic;
using UnityEngine;
using Sound.play;

public class DoorLightening : MonoBehaviour
{
    private List<GameObject> closeGos = new List<GameObject>();

    [SerializeField]
    private playSound sound;
    DoorLightening otherDoor;

    [SerializeField]
    private SpriteRenderer yellowLight, purpleLight;

    private void Start()
    {
        //sound.loopPlay("footstep");
        int? tmp = null;
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
        GameObject closestYellow = null;
        float distanceYellow = float.MaxValue;
        GameObject closestPurple = null;
        float distancePurple = float.MaxValue;
        foreach (GameObject go in closeGos)
        {
            float currDist = Vector2.Distance(transform.position, go.transform.position);
            if (go.GetComponent<AI>() == null)
            {
                if (closestPurple == null || currDist < distancePurple)
                {
                    closestPurple = go;
                    distancePurple = currDist;
                }
            }
            else
            {
                if (closestYellow == null || currDist < distanceYellow)
                {
                    closestYellow = go;
                    distanceYellow = currDist;
                }
            }
        }
        LightNone();
        if (closestYellow != null)
        {
            distanceYellow = Mathf.Clamp(distanceYellow, 0f, 10f);
            distanceYellow = 1f - distanceYellow / 10f;
            otherDoor.LightYellow(distanceYellow);
        }
        if (closestPurple != null)
        {
            distancePurple = Mathf.Clamp(distancePurple, 0f, 10f);
            distancePurple = 1f - distancePurple / 10f;
            otherDoor.LightPurple(distancePurple);
        }
    }

    public void LightNone()
    {
        yellowLight.gameObject.SetActive(false);
        purpleLight.gameObject.SetActive(false);
    }

    public void LightYellow(float intensity)
    {
        //sound.source.volume = intensity % Vector2.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, gameObject.transform.position);
        yellowLight.gameObject.SetActive(true);
        yellowLight.color = new Color(yellowLight.color.r, yellowLight.color.g, yellowLight.color.b, intensity);
    }

    public void LightPurple(float intensity)
    {
        purpleLight.gameObject.SetActive(true);
        purpleLight.color = new Color(purpleLight.color.r, purpleLight.color.g, purpleLight.color.b, intensity);
    }
}
