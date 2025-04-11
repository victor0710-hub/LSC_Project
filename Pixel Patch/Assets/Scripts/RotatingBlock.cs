using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBlock : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float rotationSpeed = 0.2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed);
    }
}
