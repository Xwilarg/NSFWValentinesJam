using UnityEngine;

public class IntroStart : MonoBehaviour
{
    [SerializeField]
    private Dialog dialog;

    private void Start()
    {
        dialog.Launch();
    }
}
