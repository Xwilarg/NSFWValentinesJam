using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private Door door;

    [SerializeField]
    bool isLocked;

    public Door GetNextDoor()
    {
        if (isLocked)
            return (null);
        return (door);
    }
}
