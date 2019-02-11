using UnityEngine;
public class ProfessorLight : MonoBehaviour
{
    private PlayerController pc;
    private AI ai;

    private bool takeDamage;

    private void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        ai = transform.parent.GetComponent<AI>();
        takeDamage = false;
    }

    private void Update()
    {
        if (takeDamage)
            pc.TakeDamage();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!pc.IsHidden() && !pc.IsInWardrobe())
            {
                if (ai != null)
                    ai.isMoving = false;
                pc = collision.GetComponent<PlayerController>();
                takeDamage = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (ai != null)
                ai.isMoving = true;
            takeDamage = false;
        }
    }
}
