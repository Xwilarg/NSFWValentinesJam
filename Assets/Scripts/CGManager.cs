using UnityEngine;
using UnityEngine.UI;

public class CGManager : MonoBehaviour
{
    [SerializeField]
    private Sprite victory, deathSouls, deathLight;

    private void Start()
    {
        switch (GameObject.Find("GameOverManager").GetComponent<GameOverManager>().type)
        {
            case GameOverManager.EndType.Victory:
                GetComponent<Image>().sprite = victory;
                break;

            case GameOverManager.EndType.DeathSouls:
                GetComponent<Image>().sprite = deathSouls;
                break;

            case GameOverManager.EndType.DeathLight:
                GetComponent<Image>().sprite = deathLight;
                break;
        }
    }
}
