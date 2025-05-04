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
        "Yýl 2092... Pizza artýk sadece bir yemek deðil.",
        "Bozulma gerçekleþtiðinde, sýradan bir pizzacýdan çok daha fazlasý oldun.",
        "Paralel evrenlerin çýlgýn sipariþleriyle artýk sen sadece bir aþçý deðil, boyutlar arasý bir elçisin.",
        "Her malzeme bir evrenin kaderini deðiþtirebilir.",
        " Paralel evrenler arasýnda geçen bu pizzacýlýk macerasýnda, sadece pizzalar deðil, geleceðin dengesi de senin ellerinde!",
        "Hazýrsan Baþlayalým!"
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
                LoadNextScene(); // Hikaye bitince sahne geçiþi
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
        // Örneðin pizzacý sahnesine geç
        UnityEngine.SceneManagement.SceneManager.LoadScene("SiparisHazirlamaEkrani");
    }
}
