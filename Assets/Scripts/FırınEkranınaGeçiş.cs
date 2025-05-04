using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FırınEkranınaGeçiş : MonoBehaviour
{
  
    public void FirinSahnesineGit()
    {
        SceneManager.LoadScene(3); 
    }
    public void KesmeTahtasiSahnesineGit()
    {
        SceneManager.LoadScene(4);
    }
}


