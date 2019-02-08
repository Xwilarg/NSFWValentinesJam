using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private Door door;

    public Transform GetDoorTransform()
    {
        return (door.transform);
    }
}
