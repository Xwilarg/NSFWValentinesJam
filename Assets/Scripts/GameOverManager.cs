using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public enum EndType
    {
        Victory,
        DeathSouls,
        DeathLight
    }

    public EndType type { set; get; }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
