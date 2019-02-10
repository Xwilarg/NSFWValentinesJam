using UnityEngine;
using UnityEngine.UI;
using static Constants;

public class LanguageManager : MonoBehaviour
{
    private LanguageName language;

    [SerializeField]
    private Text playText, creditsText;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        language = LanguageName.en;
    }

    public void SetEnglish()
    {
        language = LanguageName.en;
        playText.text = GetLine("play", LanguageName.en);
        creditsText.text = GetLine("credits", LanguageName.en);
    }

    public void SetDutch()
    {
        language = LanguageName.nl;
        playText.text = GetLine("play", LanguageName.nl);
        creditsText.text = GetLine("credits", LanguageName.nl);
    }

    public void SetFrench()
    {
        language = LanguageName.fr;
        playText.text = GetLine("play", LanguageName.fr);
        creditsText.text = GetLine("credits", LanguageName.fr);
    }

    public LanguageName GetLanguage()
    {
        return (language);
    }
}
