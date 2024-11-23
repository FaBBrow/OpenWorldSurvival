using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static GameObject itemBeingDragged;

    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private Transform startParent;
    private Vector3 startPosition;
    [SerializeField] private AudioClip DragSound;
    [SerializeField] private AudioClip DropSound;


    private void Awake()
    {
        canvas = ReferenceManager.instance.getCamvas();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.7f;
        canvasGroup.blocksRaycasts = false;
        startPosition = transform.position;
        startParent = transform.parent;
        transform.SetParent(transform.root);
        itemBeingDragged = gameObject;
        PlayerAudioManager.instance.TakeAudioClip(DragSound);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeingDragged = null;
        if (transform.parent == startParent || transform.parent == transform.root)
        {
            transform.position = startPosition;
            transform.SetParent(startParent);
            
        }
        PlayerAudioManager.instance.TakeAudioClip(DropSound);

        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
}