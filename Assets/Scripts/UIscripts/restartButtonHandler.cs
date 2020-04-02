using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartButtonHandler : MonoBehaviour
{
    //this button needs to truncate everything end unload the scene, loading the start menu again
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void handle()
    {
        nextScene();
    }

    private void nextScene()
    {
        SceneManager.LoadScene("Scenes/startMenu");
    }
}
