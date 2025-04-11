using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class After_Video : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ReturnMenu());
    }

    // Update is called once per frame
   IEnumerator ReturnMenu()
    {
        yield return new WaitForSeconds(60f);
        SceneManager.LoadScene(0);
    }
}
