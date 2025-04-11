using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Player = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Player == null)
        {
            return;
        }
        else
        {
            Vector2 position_To_Follow = Player.transform.position;
            transform.position = new Vector3(Player.transform.position.x,Player.transform.position.y, transform.position.z);
        }
    }
}
