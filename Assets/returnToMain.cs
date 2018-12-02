using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class returnToMain : MonoBehaviour {

    public void returnToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
