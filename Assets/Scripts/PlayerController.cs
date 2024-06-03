using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Networking.PlayerConnection;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float downForce;
    public bool isOnGround = true;
    private Rigidbody playerRb;
    public bool gameOver;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    private GameManager gameManager;
    public int obstacleCounter;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        gameManager = GameObject.Find("gameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && !isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.down * downForce, ForceMode.Impulse);
        }
        
         
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            if(!gameOver)
            {
                dirtParticle.Play();
            }
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            transform.Translate(Vector3.back);
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            gameManager.GameOver();
        }
        else if(collision.gameObject.CompareTag("Reward"))
        {
            gameManager.UpdateScore(1);
            Destroy(collision.gameObject);
        }else if (collision.gameObject.CompareTag("Finish"))
        {
            gameOver = true;
            gameManager.EndGame();
            // animations should stop here too
        }
    }
}

