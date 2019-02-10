using UnityEngine;
using UnityEngine.UI;
using Sound.play;

public class CGManager : MonoBehaviour
{
    [SerializeField]
    private playSound sound;
    [SerializeField]
    private Sprite victory, deathSouls, deathLight;

    private void Start()
    {
        switch (GameObject.Find("GameOverManager").GetComponent<GameOverManager>().type)
        {
            case GameOverManager.EndType.Victory:
                GetComponent<Image>().sprite = victory;
                sound.play("duoCG");
                break;

            case GameOverManager.EndType.DeathSouls:
                GetComponent<Image>().sprite = deathSouls;
                sound.play("dedSoul");
                break;

            case GameOverManager.EndType.DeathLight:
                GetComponent<Image>().sprite = deathLight;
                sound.play("dedStudent");
                break;
        }
    }
}
