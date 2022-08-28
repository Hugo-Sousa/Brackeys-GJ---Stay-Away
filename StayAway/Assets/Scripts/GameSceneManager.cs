using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public Player player;

    public Transform[] citySpawnpoints; // subway - 0 / cafe - 1 / shop - 2 / con - 3
    public Transform[] interiorsSpawnpoints; // subway - 0 / cafe - 1 / shop - 2 / con - 3

    public GameObject subway;
    public GameObject city;
    public GameObject cafe;
    public GameObject market;
    public GameObject con;

    private void Awake()
    {
        LoadPlace(0);
        player.transform.position = interiorsSpawnpoints[0].position;
    }

    public void Spawn(bool enter, int place)
    {
        if (enter)
        {
            LoadPlace(place);
            SceneManager.UnloadSceneAsync("City");
            //city.SetActive(false);
            player.transform.position = interiorsSpawnpoints[place].position;
        }

        if (!enter)
        {
            SceneManager.LoadScene("City", LoadSceneMode.Additive);
            //city.SetActive(true);
            UnloadPlace(place);
            player.transform.position = citySpawnpoints[place].position;
        }
    }

    private void LoadPlace(int place)
    {
        switch (place)
        {
            case 0:
                SceneManager.LoadScene("Subway", LoadSceneMode.Additive);
                //subway.SetActive(true);
                player.ChangeScale(0.7f);
                break;
            case 1:
                SceneManager.LoadScene("Cafe", LoadSceneMode.Additive);
                //cafe.SetActive(true);
                player.ChangeScale(0.8f);
                break;
            case 2:
                SceneManager.LoadScene("Supermarket", LoadSceneMode.Additive);
                //market.SetActive(true);
                player.ChangeScale(0.8f);
                break;
            case 3:
                SceneManager.LoadScene("Convention", LoadSceneMode.Additive);
                //con.SetActive(true);
                player.ChangeScale(0.9f);
                break;
        }
    }
    private void UnloadPlace(int place)
    {
        player.ChangeScale(1f);
        switch (place)
        {
            case 0:
                SceneManager.UnloadSceneAsync("Subway");
                //subway.SetActive(false);
                break;
            case 1:
                SceneManager.UnloadSceneAsync("Cafe");
                //cafe.SetActive(false);
                break;
            case 2:
                SceneManager.UnloadSceneAsync("Supermarket");
                //market.SetActive(false);
                break;
            case 3:
                SceneManager.UnloadSceneAsync("Convention");
                //con.SetActive(false);
                break;
        }
    }
    
}
