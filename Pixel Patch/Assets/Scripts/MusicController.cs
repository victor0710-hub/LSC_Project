using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{

    //Volume_Slider
   
    private void Awake()
    {
        SingletonPattern();
       
    }
    private void Start()
    {
       
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Credits")
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }

    }
    // Start is called before the first frame update
    private void SingletonPattern()
    {
        int Instance = FindObjectsOfType(GetType()).Length;
           if (Instance > 1)
            {
                Destroy(gameObject);
            }
            else
            {

                DontDestroyOnLoad(gameObject);

            }
             
        

    }
}
