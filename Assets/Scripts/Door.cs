using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private Door door;

    [SerializeField]
    bool isLocked;

    public void SetDoor(Door d)
    {
        door = d;
    }

    public Door GetNextDoor(ref int holyWaterCount)
    {
        if (isLocked)
        {
            if (holyWaterCount > 0)
            {
                holyWaterCount--;
                return (door);
            }
            return (null);
        }
        return (door);
    }
}
