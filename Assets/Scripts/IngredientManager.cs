using UnityEngine;

public class IngredientManager : MonoBehaviour
{
    public static IngredientManager Instance;

    public int maxIngredientCount = 20;
    private int currentIngredientCount = 0;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public bool CanAddIngredient()
    {
        return currentIngredientCount < maxIngredientCount;
    }

    public void AddIngredient()
    {
        currentIngredientCount++;
    }
}
