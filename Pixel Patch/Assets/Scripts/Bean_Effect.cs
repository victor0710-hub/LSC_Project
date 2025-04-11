using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bean_Effect : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float TimeToWait = 5f;
    [SerializeField] GameObject Laser;
    private bool Activation = true;


    void Start()
    {
        Laser.SetActive(Activation);
        StartCoroutine(ActivateEffect());
    }
    private IEnumerator ActivateEffect()
    {
        yield return new WaitForSeconds(TimeToWait);
        Activation = !Activation;
        Laser.SetActive(Activation);
        StartCoroutine(ActivateEffect());


    }

    // Update is called once per frame

}
