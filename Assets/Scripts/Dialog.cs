using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    [SerializeField]
    private Text nameText, dialogText;
    
    public void Enable(string name, string content)
    {
        nameText.enabled = true;
        dialogText.enabled = true;
        nameText.text = name;
        dialogText.text = content;
    }

    private void Update()
    {
        if (nameText.enabled && Input.anyKeyDown)
        {
            nameText.enabled = false;
            dialogText.enabled = false;
        }
    }
}