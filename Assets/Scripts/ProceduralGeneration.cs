using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabRoom, prefabCorridor;

    [SerializeField]
    private GameObject prefabDoor, prefabDoorLocked;

    [SerializeField]
    private Door firstDoor;

    private float currX;

    const float yPos = -1.5f;
    const float xPosStart = -7f;
    const float xPosEnd = 24f;

    private void Start()
    {
        currX = 50f;
        int maxRoom = Random.Range(10, 15);
        Door d = firstDoor;
        for (int i = 0; i < maxRoom; i++)
            d = GenerateCorridor(d);
    }

    private Door GenerateCorridor(Door lastDoor)
    {
        GameObject go = Instantiate(prefabCorridor, new Vector2(currX, 0f), Quaternion.identity);
        go.transform.parent = transform;
        Transform other = go.transform.GetChild(2);
        GameObject doorEntrance = Instantiate(prefabDoor, other);
        doorEntrance.transform.localPosition = new Vector2(xPosStart, yPos);
        Door me = doorEntrance.GetComponent<Door>();
        me.SetDoor(lastDoor);
        lastDoor.SetDoor(me);
        GameObject doorExit = Instantiate(prefabDoor, other);
        doorExit.transform.localPosition = new Vector2(xPosEnd, yPos);
        currX += 150f;
        return (doorExit.GetComponent<Door>());
    }
}
