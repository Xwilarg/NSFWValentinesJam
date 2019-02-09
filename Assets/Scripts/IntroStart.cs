using UnityEngine;

public class IntroStart : MonoBehaviour
{
    [SerializeField]
    public AudioSource source;
    [SerializeField]
    private Dialog dialog;

    private void Start()
    {
        dialog.source = source;
        dialog.Launch();
    }
}
