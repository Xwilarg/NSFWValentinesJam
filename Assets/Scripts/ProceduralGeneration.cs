﻿using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabRoom, prefabCorridor;

    [SerializeField]
    private GameObject prefabDoor, prefabDoorLocked;

    [SerializeField]
    private GameObject prefabLocker;

    [SerializeField]
    private Door firstDoor, lastDoor;

    [SerializeField]
    private GameObject soulPrefab, teacherPrefab, firstYearPrefab, secondYearPrefab, thirdYearPrefab;

    [SerializeField]
    private GameObject[] otherPrefabs;

    private float currX;

    const float yPos = -1.5f;
    const float xPosStart = -8f;
    const float xPosEnd = 25f;

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

    public enum objectType
    {
        Door,
        Locker,
        Other
    }

    public class Item
    {
        public Item(float xValue, objectType type)
        {
            this.xValue = xValue;
            this.type = type;
        }

        public float xValue;
        public objectType type;
    }

    private Door GenerateCorridor(Door lastDoor)
    {
        // -7 --> 27
        Item[] items = new Item[]
        {
            new Item(-3f, objectType.Other),
            new Item(2f, objectType.Other),
            new Item(7f, objectType.Other),
            new Item(12f, objectType.Other),
            new Item(17f, objectType.Other),
            new Item(22f, objectType.Other)
        };
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
            int value;
            do
            {
                value = Random.Range(0, items.Length);
            } while (items[value].type != objectType.Other);
            items[value].type = objectType.Door;
        }
        randomInt = Random.Range(-1, 4);
        if (randomInt < 0)
            randomInt = 0;
        for (int i = 0; i < randomInt; i++)
        {
            int value;
            do
            {
                value = Random.Range(0, items.Length);
            } while (items[value].type != objectType.Other);
            items[value].type = objectType.Locker;
        }
        for (int i = 0; i < items.Length; i++)
        {
            switch (items[i].type)
            {
                case objectType.Door:
                    GameObject doorGo = Instantiate(prefabDoor, other);
                    doorGo.transform.localPosition = new Vector2(items[i].xValue, yPos);
                    GenerateRoom(doorGo.GetComponent<Door>(), i);
                    break;

                case objectType.Locker:
                    GameObject lockerGo = Instantiate(prefabLocker, other);
                    lockerGo.transform.localPosition = new Vector2(items[i].xValue, yPos);
                    break;

                case objectType.Other:
                    if (Random.Range(0, 2) == 0)
                    {
                        GameObject otherModel = otherPrefabs[Random.Range(0, otherPrefabs.Length)];
                        GameObject otherGo = Instantiate(otherModel, other);
                        otherGo.transform.localPosition = new Vector2(items[i].xValue, otherModel.transform.position.y);
                    }
                    break;
            }
        }
        currX += 150f;
        return (doorExit.GetComponent<Door>());
    }

    private void GenerateRoom(Door lastDoor, float i)
    {

        Item[] items = new Item[]
        {
            new Item(16f, objectType.Other),
            new Item(24f, objectType.Other)
        };
        GameObject go = Instantiate(prefabRoom, new Vector2(currX + i * 10f, 100f + i * 100f), Quaternion.identity);
        go.transform.parent = transform;
        Transform other = go.transform.GetChild(2);
        GameObject doorEntrance = Instantiate(prefabDoor, go.transform);
        doorEntrance.transform.localPosition = new Vector2(20f, yPos);
        Door me = doorEntrance.GetComponent<Door>();
        me.SetDoor(lastDoor);
        lastDoor.SetDoor(me);
        int randomInt = Random.Range(-2, 2);
        if (randomInt < 0)
            randomInt = 0;
        if (randomInt == 1)
            items[Random.Range(0, items.Length)].type = objectType.Locker;
        for (int y = 0; y < items.Length; y++)
        {
            switch (items[y].type)
            {
                case objectType.Locker:
                    GameObject lockerGo = Instantiate(prefabLocker, other);
                    lockerGo.transform.localPosition = new Vector2(items[y].xValue, yPos);
                    break;

                case objectType.Other:
                    if (Random.Range(0, 2) == 0)
                    {
                        GameObject otherModel = otherPrefabs[Random.Range(0, otherPrefabs.Length)];
                        GameObject otherGo = Instantiate(otherModel, other);
                        otherGo.transform.localPosition = new Vector2(items[y].xValue, otherModel.transform.position.y);
                    }
                    break;
            }
        }
    }
}
