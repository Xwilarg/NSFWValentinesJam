﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialog : MonoBehaviour
{
    [SerializeField]
    private Text nameText, dialogText;

    private int id = 0;

    public void Launch()
    {
        id++;
        if (id == 1)
            Enable(Constants.GetLine("Guy", Constants.LanguageName.en) + " 1", Constants.GetLine("invocation1", Constants.LanguageName.en));
        else if (id == 2)
            Enable(Constants.GetLine("Guy", Constants.LanguageName.en) + " 2", Constants.GetLine("invocation2", Constants.LanguageName.en));
        else if (id == 3)
            Enable(Constants.GetLine("Guy", Constants.LanguageName.en) + " 3", Constants.GetLine("invocation3", Constants.LanguageName.en));
        else if (id == 4)
            Enable(Constants.GetLine("Guy", Constants.LanguageName.en) + " 2", Constants.GetLine("invocation4", Constants.LanguageName.en));
        else if (id == 5)
            Enable(Constants.GetLine("Guy", Constants.LanguageName.en) + " 1", Constants.GetLine("invocation5", Constants.LanguageName.en));
        else if (id == 6)
            Enable(Constants.GetLine("Guy", Constants.LanguageName.en) + " 3", Constants.GetLine("invocation6", Constants.LanguageName.en));
        else if (id == 7)
            Enable("Tsuma", Constants.GetLine("invocation7", Constants.LanguageName.en));
        else if (id == 8)
            SceneManager.LoadScene("Main");
    }

    private void Enable(string name, string content)
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
            Launch();
        }
    }
}