using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabRoom, prefabCorridor;

    [SerializeField]
    private GameObject prefabDoor, prefabDoorLocked;

    [SerializeField]
    private Door firstDoor, lastDoor;

    [SerializeField]
    private GameObject soulPrefab, teacherPrefab, firstYearPrefab, secondYearPrefab, thirdYearPrefab;

    private float currX;

    const float yPos = -1.5f;
    const float xPosStart = -7f;
    const float xPosEnd = 24f;

    private void Start()
    {
        currX = 50f;
        int maxRoom = Random.Range(5, 7);
        Door d = firstDoor;
        for (int i = 0; i < maxRoom; i++)
            d = GenerateCorridor(d);
        d.SetDoor(lastDoor);
        lastDoor.SetDoor(d);
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
        int randomInt = Random.Range(-1, 5);
        if (randomInt < 0)
            randomInt = 0;
        for (int i = 0; i < randomInt; i++)
        {
            GameObject soulGo = Instantiate(soulPrefab, other);
            soulGo.transform.localPosition = new Vector2(Random.Range(-7f, 24f), yPos);
            soulGo.name = "Soul";
        }
        randomInt = Random.Range(0, 3);
        for (int i = 0; i < randomInt; i++)
        {
            GameObject soulGo = Instantiate(teacherPrefab, other);
            soulGo.transform.localPosition = new Vector2(Random.Range(-7f, 24f), yPos);
        }
        randomInt = Random.Range(-1, 3);
        if (randomInt < 0)
            randomInt = 0;
        for (int i = 0; i < randomInt; i++)
        {
            GameObject doorGo = Instantiate(prefabDoor, other);
            doorGo.transform.localPosition = new Vector2(i * 10f, yPos);
            GenerateRoom(doorGo.GetComponent<Door>(), i);
        }
        currX += 150f;
        return (doorExit.GetComponent<Door>());
    }

    private void GenerateRoom(Door lastDoor, float i)
    {
        GameObject go = Instantiate(prefabRoom, new Vector2(currX + i * 10f, 100f + i * 100f), Quaternion.identity);
        go.transform.parent = transform;
        Transform other = go.transform.GetChild(2);
        GameObject doorEntrance = Instantiate(prefabDoor, go.transform);
        doorEntrance.transform.localPosition = new Vector2(20f, yPos);
        Door me = doorEntrance.GetComponent<Door>();
        me.SetDoor(lastDoor);
        lastDoor.SetDoor(me);
    }
}
