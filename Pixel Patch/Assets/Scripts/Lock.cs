using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lock : MonoBehaviour
{
    // Start is called before the first frame update
    private bool open = false;
    
    [SerializeField] SpriteRenderer LockSprite;
    [SerializeField] SpriteRenderer LockCircle;



    // Update is called once per frame
    void Update()
    {
        if (open == true)
        {
            LockSprite.color = new Color32(155, 146, 67, 255);
            LockCircle.color = new Color32(155, 146, 67, 255);
        }
    }
 public void Lockopen(bool OpenStatus)
    {
        open = OpenStatus;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && open == true)
        {
            int actualLevel = SceneManager.GetActiveScene().buildIndex;
            int totalScenes = SceneManager.sceneCount-1;

            if (actualLevel == 22)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
