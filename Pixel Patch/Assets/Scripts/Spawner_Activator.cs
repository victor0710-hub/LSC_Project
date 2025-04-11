using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Activator : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("This will just work with 1 item. If you want to add more Gameobjects, add more spawners but it will consume more memory.")]
    [SerializeField] GameObject Object_To_Spawn;
    [SerializeField] Vector2[] Spawn_Points ;

    private bool activation = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && activation == false)
        {
            activation = true;
            Debug.Log("activated");
            for(int i=0; i< Spawn_Points.Length;i++)
            {
                Instantiate(Object_To_Spawn, new Vector3(Spawn_Points[i].x, Spawn_Points[i].y, 0), Quaternion.identity);
                Debug.Log("created");
            }

        }
    }
}
