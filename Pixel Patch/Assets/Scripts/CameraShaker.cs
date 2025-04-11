using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    [SerializeField] Animator CameraAnimator;
    // Start is called before the first frame update
 
    void Start()
    {
        
    }

    // Update is called once per frame
    public void ActivateShacker()
    {
        CameraAnimator.SetTrigger("Shake");
    }
}
