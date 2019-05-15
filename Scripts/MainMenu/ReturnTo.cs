using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnTo : MonoBehaviour {

	public void Return()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
