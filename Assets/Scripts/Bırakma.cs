using UnityEngine;
using UnityEngine.EventSystems;

public class Birakma : MonoBehaviour, IDropHandler
{
    public Transform pizzaUstuPaneli;      // Pizza'nın üstündeki UI alanı
    public GameObject domatesPrefab;       // Pizza üstüne eklenecek domates prefab

    

    public void OnDrop(PointerEventData eventData)
    {
        GameObject suruklenenDomates = eventData.pointerDrag;

        if (suruklenenDomates != null && suruklenenDomates.CompareTag("Domates"))
        {
            // Sınır kontrolü
            if (!IngredientManager.Instance.CanAddIngredient())
                return;

            // Domates pizza üstüne bırakıldıysa yeni bir tane oluştur
            GameObject yeniDomates = Instantiate(domatesPrefab, pizzaUstuPaneli);
            RectTransform yeniRect = yeniDomates.GetComponent<RectTransform>();
            Vector2 localPos;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                pizzaUstuPaneli as RectTransform,
                eventData.position,
                eventData.pressEventCamera,
                out localPos
            );

            yeniRect.anchoredPosition = localPos;

            // Sayaç +1
            IngredientManager.Instance.AddIngredient();

            // Orijinal domatesi yok et (tabaktan eksilsin)
            Destroy(suruklenenDomates);

            
        }
    }
}
