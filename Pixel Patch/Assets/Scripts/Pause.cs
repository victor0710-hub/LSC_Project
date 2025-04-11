using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject UI_Pause;
    private bool GameOnPause = false;
    // Start is called before the first frame update
    void Start()
    {
        UI_Pause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UI_Pause.SetActive(GameOnPause);

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameOnPause = !GameOnPause;
            switch(GameOnPause)
            {
                case false:
                    Time.timeScale = 1f;
                    break;

                case true:
                    Time.timeScale = 0f;
                    break;
            }
        }
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        GameOnPause = !GameOnPause;

    }
    public void ExitGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
