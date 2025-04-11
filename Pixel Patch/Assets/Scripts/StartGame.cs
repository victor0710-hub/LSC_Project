using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
 public void Game()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void CloseGame()
    {
        Application.Quit();
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
