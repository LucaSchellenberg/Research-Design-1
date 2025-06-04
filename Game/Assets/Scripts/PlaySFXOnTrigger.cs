using UnityEngine;

public class PlaySFXOnTrigger : MonoBehaviour
{
    public AudioClip clip;
    private AudioSource source;

    void Start() => source = GetComponent<AudioSource>();

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            source.PlayOneShot(clip);
        }
    }
}
