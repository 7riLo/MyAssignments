/*
 * Levi Wyant
 * Prototype3
 * player controller file. Player input, audio, and animation drivers
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce;
    public ForceMode jumpForceMode;
    public float gravityModifier;

    public bool isOnGround = true ;
    public bool gameOver   = false;

    public Animator playerAnimator;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        //set a reference to our rigidbody component
        rb = GetComponent<Rigidbody>();
        //set a ref to our animator component
        playerAnimator = GetComponent<Animator>();
        //set ref to audio source comp
        playerAudio = GetComponent<AudioSource>();


        //start running animation on start
        playerAnimator.SetFloat("Speed_f", 1.0f);
        jumpForceMode = ForceMode.Impulse;


        
        
        
        //Physics.gravity *= gravityModifier;
        if(Physics.gravity.y > -10)
        {
            Physics.gravity *= gravityModifier;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //jump with space
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, jumpForceMode);
            isOnGround = false;

            //set trigger to set jump animation
            playerAnimator.SetTrigger("Jump_trig");

            //stop drit
            dirtParticle.Stop();
            //used different jump sound than videos. Is a litte quiet so turned it up to 1.6... RIP headphone users (/s). 
            playerAudio.PlayOneShot(jumpSound, 1.6f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            //play dirt particle
            dirtParticle.Play();
            
        }
        else if (collision.gameObject.CompareTag("Obstacle") && !gameOver)
        {
            Debug.Log("Game Over!");
            gameOver = true;

            //Play death animation
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);

            //Play explosion animation
            explosionParticle.Play();

            //stop dirt play
            dirtParticle.Stop();

            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
       
    }
}
