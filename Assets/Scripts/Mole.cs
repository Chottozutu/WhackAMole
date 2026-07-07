using UnityEngine;
using UnityEngine.EventSystems;

public class Mole : MonoBehaviour, IPointerClickHandler
{
    private CanvasGroup canvasGroup;
    private bool isHit;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isHit)
            return;

        isHit = true;

        GameManager.Instance.AddScore(1);

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