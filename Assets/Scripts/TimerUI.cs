using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;  // TextMeshPro bile�eni
    public float countdown = 30f;     // Ba�lang�� s�resi (saniye)

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
            timeText.text = "S�re doldu!";
            // Buraya sahne ge�i�i veya ba�ka bir i�lem ekleyebilirsin
        }
    }
}
