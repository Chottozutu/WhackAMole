using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class Mole : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip hitSE;

    private CanvasGroup canvasGroup;
    private bool isHit;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        // èâä˙èÛë‘ÇÕîÒï\é¶
        Hide();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isHit)
            return;

        isHit = true;

        GameManager.Instance.HitThisFrame = true;

        GameManager.Instance.AddScore(1);

        AudioManager.Instance.NotifyHit();

        Hide();
    }

    public void Show()
    {
        isHit = false;

        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    public void Hide()
    {
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}