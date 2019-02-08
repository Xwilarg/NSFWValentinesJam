using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private Door door;

    public Vector2 GetDoorPosition()
    {
        return (door.transform.position);
    }
}
