using UnityEngine;

public class AmbiantSoundManager : MonoBehaviour
{
    public AudioSource normalAudio { private set; get; }
    public AudioSource dangerAudio { private set; get; }

    private void Start()
    {
        AudioSource[] sources = GetComponents<AudioSource>();
        normalAudio = sources[0];
        dangerAudio = sources[1];
    }
}
