using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBox : MonoBehaviour
{
    // Start is called before the first frame updates
    [SerializeField] float Falling_Speed = 250f;
    private Rigidbody2D BoxRB;
    void Start()
    {
        BoxRB = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            BoxRB.velocity = new Vector2(0f,-Falling_Speed * Time.deltaTime);


        }
    }
}
