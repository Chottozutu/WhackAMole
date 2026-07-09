using UnityEngine;

public class BGMManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip bgm;

    private void Start()
    {
        audioSource.clip = bgm;
        audioSource.loop = true;
        audioSource.Play();
    }
}