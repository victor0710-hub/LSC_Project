using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartController : MonoBehaviour
{
    private float TimeLeft_To_Reset = 0.75f;

    private float initialTime;
    // Start is called before the first frame update
    void Start()
    {
        initialTime = TimeLeft_To_Reset;
    }

    // Update is called once per frame
    void Update()
    {
        RestartGame();
        RestoreTime();
    }

    private void RestoreTime()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            TimeLeft_To_Reset = initialTime;
            Debug.Log("Restart seted back to normal" + TimeLeft_To_Reset);
        }
    }

    private void RestartGame()
    {
        if (Input.GetKey(KeyCode.R))
        {
            if (TimeLeft_To_Reset >= 0)
            {
                TimeLeft_To_Reset -= Time.deltaTime;
                Debug.Log("The level is restarting" + TimeLeft_To_Reset);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Debug.Log("Level Restarted");
            }
        }
    }
}
