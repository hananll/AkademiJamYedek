using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;  // TextMeshPro bileþeni
    public float countdown = 30f;     // Baþlangýç süresi (saniye)

    void Update()
    {
        if (countdown > 0f)
        {
            countdown -= Time.deltaTime;
            int seconds = Mathf.CeilToInt(countdown);
            timeText.text = "Kalan: " + seconds.ToString() + " sn";
        }
        else
        {
            timeText.text = "Süre doldu!";
            // Buraya sahne geçiþi veya baþka bir iþlem ekleyebilirsin
        }
    }
}
