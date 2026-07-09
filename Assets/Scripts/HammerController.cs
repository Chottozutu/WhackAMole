using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class HammerController : MonoBehaviour
{
    [SerializeField] private Image hammerImage;
    [SerializeField] private Sprite idleSprite;
    [SerializeField] private Sprite hitSprite;
    [SerializeField] private float hitTime = 0.1f;
    [SerializeField] private Vector2 offset = new Vector2(-40, 40);
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip missSE;

    private RectTransform rect;
    private Coroutine hitCoroutine;

    void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    void Update()
    {
        rect.position = Mouse.current.position.ReadValue() + offset;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            AudioManager.Instance.BeginClick();

            if (hitCoroutine != null)
                StopCoroutine(hitCoroutine);

            hitCoroutine = StartCoroutine(Hit());
        }
    }

    IEnumerator Hit()
    {
        hammerImage.sprite = hitSprite;

        yield return null;

        AudioManager.Instance.EndClick();

        yield return new WaitForSeconds(hitTime);

        hammerImage.sprite = idleSprite;
    }
}