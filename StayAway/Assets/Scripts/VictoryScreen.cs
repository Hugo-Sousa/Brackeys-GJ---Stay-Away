using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BackToTitle());
    }

    IEnumerator BackToTitle()
    {

        yield return new WaitForSeconds(10);

        SceneManager.LoadScene("TitleScreen");
    }
}
