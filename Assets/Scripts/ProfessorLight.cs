using UnityEngine;
public class ProfessorLight : MonoBehaviour
{
    private PlayerController pc;

    private void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController pc = collision.GetComponent<PlayerController>();
            if (!pc.IsHidden())
                pc.TakeDamage();
        }
    }
}
