using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public float jumpForce = 10;
    public float gravityModifier = 0;

    public bool isOnGround = true;

    public bool gameOver = false;

    private Animator playerAnim;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;

    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier;
        
    }

    // Update is called once per frame
    void Update()
    {
        // if space is held and isOnGround bool is true
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true && !gameOver)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // add a jump force 
            isOnGround = false; // set the isOnGround bool to false
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1f);
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        // if the player collides with ground
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            if (!gameOver)
            {
                dirtParticle.Play();
            }
        }
        // if the player collides with obstacle
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1f);
        }
    }
}
