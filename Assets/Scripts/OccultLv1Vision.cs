using UnityEngine;
public class OccultLv1Vision : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OccultLv1 occult = gameObject.GetComponentInParent<OccultLv1>();
            if (occult != null)
            {
                occult.FoundPlayer();
            }
        }
    }
}
