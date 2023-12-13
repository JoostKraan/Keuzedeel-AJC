using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject misionsMenu;

    public void PlayGame()
    {
        mainMenu.SetActive(false);
        misionsMenu.SetActive(true);
    }
    public void PlayMisionOne()
    {
        SceneManager.LoadScene("Michel");
    }
    public void PlayMisionTwo()
    {
        SceneManager.LoadScene("Sjoerd");
    }
}
