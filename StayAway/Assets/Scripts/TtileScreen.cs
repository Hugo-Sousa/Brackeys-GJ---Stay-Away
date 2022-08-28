using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TtileScreen : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Manager");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
