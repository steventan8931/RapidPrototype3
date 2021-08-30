using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndManage : MonoBehaviour
{
  
    public void exitGame()
    {
        Application.Quit();
    }

    public void backToMenu()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
