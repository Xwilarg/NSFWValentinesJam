using UnityEngine;
using Sound;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialog : MonoBehaviour
{
    [SerializeField]
    public AudioSource source;
    private SoundManager voice;
    [SerializeField]
    private Text nameText, dialogText;

    [SerializeField]
    private Flash flash;

    [SerializeField]
    private Shake shake;

    [SerializeField]
    private SpriteRenderer reiSr;

    Constants.LanguageName lang;

    private void Start()
    {
        GameObject manager = GameObject.FindGameObjectWithTag("LanguageManager");
        if (manager != null)
            lang = manager.GetComponent<LanguageManager>().GetLanguage();
        else
            lang = Constants.LanguageName.en;
    }

    [SerializeField]
    private int id = 0;

    public void Launch()
    {
        voice = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
        if (id == 0)
            Enable(Constants.GetLine("student", lang) + " 3", Constants.GetLine("invocation0", lang), voice.sounds["invoCthulhu"]);
        else if (id == 1)
        {
            shake.ShakeCamera();
            Enable(Constants.GetLine("student", lang) + " 1", Constants.GetLine("invocation1", lang), voice.sounds["invocation1"]);
        }
        else if (id == 2)
            Enable(Constants.GetLine("student", lang) + " 2", Constants.GetLine("invocation2", lang), voice.sounds["invocation2"]);
        else if (id == 3)
        {
            reiSr.enabled = true;
            Enable(Constants.GetLine("student", lang) + " 3", Constants.GetLine("invocation3", lang), voice.sounds["invocation3"]);
        }
        else if (id == 4)
        {
            flash.FlashPanel();
            reiSr.enabled = false;
            Enable(Constants.GetLine("student", lang) + " 2", Constants.GetLine("invocation4", lang), voice.sounds["invocation4"]);
        }
        else if (id == 5)
            Enable(Constants.GetLine("student", lang) + " 1", Constants.GetLine("invocation5", lang), voice.sounds["invocation5"]);
        else if (id == 6)
            Enable(Constants.GetLine("student", lang) + " 3", Constants.GetLine("invocation6", lang), voice.sounds["invocation6"]);
        else if (id == 7)
            Enable("Tsuma", Constants.GetLine("invocation7", lang), voice.sounds["invocation7"]);
        else if (id == 8)
            SceneManager.LoadScene("Main");
        else if (id == 100)
            Enable("Tsuma", Constants.GetLine("ending1", lang), voice.sounds["footstep"]);
        else if (id == 101)
            Enable("Tsuma", Constants.GetLine("ending2", lang), voice.sounds["footstep"]);
        else if (id == 102)
            Enable("Tsuma", Constants.GetLine("ending3", lang), voice.sounds["footstep"]);
        else if (id == 103)
        {
            Enable("Tsuma", Constants.GetLine("ending3", lang), voice.sounds["footstep"]);
            GameObject go = new GameObject("GameOverManager", typeof(GameOverManager));
            go.GetComponent<GameOverManager>().type = GameOverManager.EndType.Victory;
            SceneManager.LoadScene("Ending");
        }
        id++;
    }

    private void Enable(string name, string content, AudioClip sound)
    {
        nameText.enabled = true;
        dialogText.enabled = true;
        nameText.text = name;
        dialogText.text = content;
        source.clip = sound;
        source.Play();
    }

    private void Update()
    {
        if (nameText.enabled && Input.anyKeyDown)
        {
            Launch();
        }
    }
}