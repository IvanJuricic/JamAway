using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrowseAudioFiles : MonoBehaviour {

    public void NextSceneAndBrowse()
    {
        SceneManager.LoadScene("EndlessMode");
    }

}
