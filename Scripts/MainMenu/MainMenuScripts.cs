using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScripts : MonoBehaviour {

    public void Play()
    {
        SceneManager.LoadScene("ChooseGameTypeScene");
    }

    public void Exit()
    {
        Debug.Log("Out!");
        Application.Quit();    
    }

    public void OptionsMenu()
    {
        SceneManager.LoadScene("OptionsMenu");
    }
	
}
