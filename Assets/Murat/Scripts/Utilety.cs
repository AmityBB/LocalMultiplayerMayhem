using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Utilety : MonoBehaviour
{
    [SerializeField] private GameObject gesscreen;
    public void Back()
    {
        gesscreen.SetActive(false);
    }
    public void GoToStart()
    {
        SceneManager.LoadScene("Start");
    }
    public void GoToGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void GoToMiniGame1()
    {
        SceneManager.LoadScene("MiniGame1");
    }
}
