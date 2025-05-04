using UnityEngine;
using UnityEngine.EventSystems;

public class Surukleme : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Transform originalParent;
    private Canvas canvas;

    private bool canDrag = true;
    private bool previouslyOnPizza = false;

    [Header("Tabağa dönüş alanı (IngredientPlate)")]
    public Transform plateParent;
    [Header("Drop hedefi (PizzaHamuru)")]
    public Transform dropTargetParent;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;

        previouslyOnPizza = (originalParent == dropTargetParent);

        // Eğer pizza üstündeyse ve geri alınacaksa, sayacı azalt
        if (previouslyOnPizza)
        {
            IngredientManager.Instance.RemoveIngredient();
        }
        else
        {
            // Yeni bir ekleme yapılacaksa sınırı kontrol et
            if (!IngredientManager.Instance.CanAddIngredient())
            {
                canDrag = false;
                return;
            }
        }

        canDrag = true;
        transform.SetParent(canvas.transform);
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!canDrag) return;
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!canDrag) return;

        GameObject dropObject = eventData.pointerCurrentRaycast.gameObject;

        if (dropObject != null && dropObject.transform == dropTargetParent)
        {
            // Pizza üstüne bırakıldıysa ve orijinal yeri pizza değilse sayaç artır
            transform.SetParent(dropTargetParent);

            if (!previouslyOnPizza)
            {
                IngredientManager.Instance.AddIngredient();
            }
        }
        else
        {
            // Tabağa dönerse oraya koy
            transform.SetParent(originalParent);
            transform.SetAsLastSibling(); // ✔️ Domatesin önde görünmesini sağlar
        }

        canvasGroup.blocksRaycasts = true;
    }
}
