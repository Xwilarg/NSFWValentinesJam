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
        Object[] objs = FindObjectsOfType(GetType());
        if (objs.Length > 1)
        {
            foreach (Object obj in objs)
            {
                if (this != obj)
                {
                    GameOverManager tmp = obj as GameOverManager;
                    Destroy(tmp.gameObject);
                }
            }
        }
    }
}
