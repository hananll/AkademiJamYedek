using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public string[] allowedScenes = { "Start", "StoryScene" }; // Müziðin devam edeceði sahneler

    private static AudioManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // Ýkinci AudioManager varsa yok et
            return;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        bool shouldPlay = false;

        foreach (string sceneName in allowedScenes)
        {
            if (scene.name == sceneName)
            {
                shouldPlay = true;
                break;
            }
        }

        if (shouldPlay && !musicSource.isPlaying)
        {
            musicSource.Play();
        }
        else if (!shouldPlay && musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }
}
