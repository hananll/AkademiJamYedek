using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public TextMeshProUGUI storyText;
    public float typingSpeed = 0.05f;

    private string[] storyLines = new string[]
    {
        "Y�l 2092... Pizza art�k sadece bir yemek de�il.",
        "Bozulma ger�ekle�ti�inde, s�radan bir pizzac�dan �ok daha fazlas� oldun.",
        "Paralel evrenlerin ��lg�n sipari�leriyle art�k sen sadece bir a��� de�il, boyutlar aras� bir el�isin.",
        "Her malzeme bir evrenin kaderini de�i�tirebilir.",
        " Paralel evrenler aras�nda ge�en bu pizzac�l�k maceras�nda, sadece pizzalar de�il, gelece�in dengesi de senin ellerinde!",
        "Haz�rsan Ba�layal�m!"
    };

    private int currentLine = 0;
    private bool isTyping = false;

    void Start()
    {
        StartCoroutine(TypeLine());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isTyping)
        {
            if (currentLine < storyLines.Length)
                StartCoroutine(TypeLine());
            else
                LoadNextScene(); // Hikaye bitince sahne ge�i�i
        }
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        storyText.text = "";

        foreach (char letter in storyLines[currentLine].ToCharArray())
        {
            storyText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
        currentLine++;
    }

    void LoadNextScene()
    {
        // �rne�in pizzac� sahnesine ge�
        UnityEngine.SceneManagement.SceneManager.LoadScene("SiparisHazirlamaEkrani");
    }
}
