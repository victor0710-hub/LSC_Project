using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoivngPlatform : MonoBehaviour
{
    [SerializeField] float speed;

    public enum Types { Horizontal, Vertical };
    public Types Movement_Mode = Types.Horizontal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(Movement_Mode)
        {
            case Types.Horizontal:
                transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
                break;

            case Types.Vertical:
                transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
                break;

        }
        
    }
    public void forceVerticalMove()
    {
         Movement_Mode = Types.Vertical;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            speed *= -1;      
        }
    }
}
