using UnityEngine;
using UnityEngine.EventSystems;

public class PizzaDropZone : MonoBehaviour, IDropHandler
{
    public Transform pizzaUstuPaneli;      // Pizza'nın üstündeki UI alanı
    public GameObject domatesPrefab;       // Pizza üstüne eklenecek domates prefab

    public void OnDrop(PointerEventData eventData)
    {
        GameObject suruklenenDomates = eventData.pointerDrag;

        if (suruklenenDomates != null && suruklenenDomates.CompareTag("Domates"))
        {
            // Domates pizza üstüne bırakıldıysa yeni bir tane oluştur
            GameObject yeniDomates = Instantiate(domatesPrefab, pizzaUstuPaneli);
            RectTransform yeniRect = yeniDomates.GetComponent<RectTransform>();
            Vector2 localPos;

            // Ekran pozisyonunu local pozisyona çevir
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                pizzaUstuPaneli as RectTransform,
                eventData.position,
                eventData.pressEventCamera,
                out localPos
            );

            yeniRect.anchoredPosition = localPos;

            // Orijinal domatesi yok et (tabaktan eksilsin)
            Destroy(suruklenenDomates);
        }
    }
}
