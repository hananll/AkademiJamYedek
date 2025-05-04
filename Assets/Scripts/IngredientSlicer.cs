using UnityEngine;
using UnityEngine.UI;

public class IngredientSlicer : MonoBehaviour
{
    public Image cuttingImage;              // KesilecekMalzeme Image objesi
    public Sprite[] slicingStages;          // 1-2-3 dilimli sprite'lar

    private int currentStage = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowNextSlice();
        }
    }

    void ShowNextSlice()
    {
        if (currentStage >= slicingStages.Length) return;

        cuttingImage.sprite = slicingStages[currentStage];
        currentStage++;
    }
}