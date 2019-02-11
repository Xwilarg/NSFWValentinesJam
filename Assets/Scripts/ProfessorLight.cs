using UnityEngine;
public class ProfessorLight : MonoBehaviour
{
    private PlayerController pc;
    private AI ai;

    private void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        ai = transform.parent.GetComponent<AI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && ai != null)
            ai.isMoving = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && ai != null)
            ai.isMoving = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController pc = collision.GetComponent<PlayerController>();
            if (!pc.IsHidden() && !pc.IsInWardrobe())
                pc.TakeDamage();
        }
    }
}
