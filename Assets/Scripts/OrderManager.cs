using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public TextMeshProUGUI orderNumberText;
    public TextMeshProUGUI universeNumberText;
    public Transform ingredientListParent;
    public GameObject ingredientTextPrefab; // Prefab olarak TMP Text objesi

    public List<string> allIngredients = new List<string> { "Sucuk", "Biber", "Mantar", "Zeytin", "Peynir" };

    void Start()
    {
        GenerateNewOrder();
    }

    void GenerateNewOrder()
    {
        // Sipari� ve evren numaras�
        int orderNo = Random.Range(1000, 9999);
        int universeNo = Random.Range(1, 100);

        orderNumberText.text = "" + orderNo;
        universeNumberText.text = "" + universeNo;

        // Eski malzemeleri temizle
        foreach (Transform child in ingredientListParent)
        {
            Destroy(child.gameObject);
        }

        // Rastgele 3�4 malzeme se�
        List<string> selectedIngredients = new List<string>();
        int count = 3;

        while (selectedIngredients.Count < count)
        {
            string randomIngredient = allIngredients[Random.Range(0, allIngredients.Count)];
            if (!selectedIngredients.Contains(randomIngredient))
            {
                selectedIngredients.Add(randomIngredient);
            }
        }

        foreach (string ingredient in selectedIngredients)
        {
            GameObject newText = Instantiate(ingredientTextPrefab, ingredientListParent);

            TextMeshProUGUI textComponent = newText.GetComponent<TextMeshProUGUI>();
            if (textComponent != null)
            {
                textComponent.text = "� " + ingredient;
            }
            else
            {
                Debug.LogWarning("TextMeshProUGUI component not found on ingredient prefab.");
            }
        }
    }
}
