using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource audioSource;

    [Header("SE")]
    [SerializeField] private AudioClip hitSE;
    [SerializeField] private AudioClip missSE;

    private bool hitThisClick;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void BeginClick()
    {
        hitThisClick = false;
    }

    public void NotifyHit()
    {
        hitThisClick = true;
        audioSource.PlayOneShot(hitSE);
    }

    public void EndClick()
    {
        if (!hitThisClick)
        {
            audioSource.PlayOneShot(missSE);
        }
    }
}