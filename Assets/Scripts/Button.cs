using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("StoryScene"); // Sahnenin ad�n� birebir do�ru yaz!
    }
}
