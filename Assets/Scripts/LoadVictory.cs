using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadVictory : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("GoodEnding");
    }
}
