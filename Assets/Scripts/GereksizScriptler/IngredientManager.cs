using UnityEngine;
using TMPro; // UI sayaç için

public class IngredientManager : MonoBehaviour
{
    public static IngredientManager Instance;

    public int maxIngredientCount = 20;
    private int currentIngredientCount = 0;

    [Header("UI Sayaç")]
    public TextMeshProUGUI counterText; // Sol üstte gösterilecek yazý

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        UpdateCounterUI(); // Oyun baþlarken sayaç güncellensin
    }

    public bool CanAddIngredient()
    {
        return currentIngredientCount < maxIngredientCount;
    }

    public void AddIngredient()
    {
        if (!CanAddIngredient()) return;

        currentIngredientCount++;
        UpdateCounterUI();
    }

    public void RemoveIngredient()
    {
        if (currentIngredientCount > 0)
        {
            currentIngredientCount--;
            UpdateCounterUI();
        }
    }

    private void UpdateCounterUI()
    {
        if (counterText != null)
        {
            counterText.text = $"Malzeme: {currentIngredientCount} / {maxIngredientCount}";
        }
    }
}
