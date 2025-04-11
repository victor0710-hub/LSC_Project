using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float jumpForce = 20f;
    [SerializeField] GameObject[] Parts;
    [SerializeField] CameraShaker CameraEffectShake;

    private Rigidbody2D PlayerRB;
    private Animator PlayerAnimator;
    private SpriteRenderer PlayerSpriteRender;

    private bool PlayerAlive = true;
    private bool TouchingGround = false;
    private bool CheckerOneTime_RepeatLevel = true;
    
    // Start is called before the first frame update
    void Start()
    {
      
        PlayerRB = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();
        PlayerSpriteRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(CrossPlatformInputManager.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0));
       
        //Update position first

        //Change animation later

        if (TouchingGround == true && PlayerAlive ==true)
        {
            Momevemnt_animation();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
                
            }
        }
        //Update jumping animation
        PlayerAnimator.SetBool("Jumping", !TouchingGround);

    }
   
    public void Momevemnt_animation()
    {
        float side = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        switch(side)
        {
            case 0:
                PlayerAnimator.SetBool("Moving_right", false);
                PlayerAnimator.SetBool("Moving_left", false);
                break;

            case 1: //right walking
                PlayerAnimator.SetBool("Moving_right", true);
                PlayerAnimator.SetBool("Moving_left", false);
                break;

            case -1: //left walking
                PlayerAnimator.SetBool("Moving_right", false);
                PlayerAnimator.SetBool("Moving_left", true);
                break;
        }

        //  PlayerRB.velocity = new Vector2(speed * CrossPlatformInputManager.GetAxis("Horizontal") ,0f );
           
    }
    private void Jump()
    {
        PlayerRB.AddForce(new Vector2(0f, jumpForce ), ForceMode2D.Impulse);
      
        TouchingGround = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        switch (collision.gameObject.tag)
        {
            case "Ground":
                TouchingGround = true;
                transform.SetParent(collision.transform);
                //  PlayerAnimator.SetBool("Jumping", !TouchingGround);
                break;

            case "Spike":
                foreach (GameObject spikes in Parts)
                {
                    Instantiate(spikes, new Vector3(transform.position.x + Random.Range(-1.2f,1.2f), transform.position.y+Random.Range(-0.5f,0.5f) , transform.position.z), Quaternion.identity);
                    StartCoroutine(RestartAfterDead());
                    PlayerSpriteRender.enabled = false;
                    Destroy(gameObject, 1.1f);
                }

                CameraEffectShake.ActivateShacker();
                
                //Here the code to repeat the level after dying.

                break;
            case "RotationGround":
                TouchingGround = true;
                break;
        }
    }
    private IEnumerator RestartAfterDead()
    {
        yield return new WaitForSeconds(1f);
        if (CheckerOneTime_RepeatLevel == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            CheckerOneTime_RepeatLevel = false;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
           
            case "Spike":
                foreach (GameObject spikes in Parts)
                {
                    Instantiate(spikes, new Vector3(transform.position.x + Random.Range(-1.2f, 1.2f), transform.position.y + Random.Range(-0.5f, 0.5f), transform.position.z), Quaternion.identity);
                    StartCoroutine(RestartAfterDead());
                    PlayerSpriteRender.enabled = false;
                    Destroy(gameObject,1.1f);
                   
                }

                CameraEffectShake.ActivateShacker();

                //Here the code to repeat the level after dying.

                break;
        }
    }
}
