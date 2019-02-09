using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private Door door;

    public Door GetNextDoor()
    {
        return (door);
    }
}
