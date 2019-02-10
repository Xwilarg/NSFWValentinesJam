using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterLoadMenu : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
            SceneManager.LoadScene("MainMenu");
    }
}
