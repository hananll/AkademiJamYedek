using UnityEngine;

public class NesneyiKesmeEkraninaKoy : MonoBehaviour
{
    public GameObject targetToShow;

    public void ShowObject()
    {
        if (targetToShow != null)
            targetToShow.SetActive(true);
    }
}
