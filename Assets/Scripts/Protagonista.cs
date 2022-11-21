using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Protagonista : MonoBehaviour
{
    public float speed = 3f;
    public float jumpSpeed = 5f;
    private float direction = 0f;
    private Rigidbody2D player;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;

    private Animator playerAnimation;

    private Vector3 respawnPoint;
    public GameObject fallDetector;
    public Text scoreText;
    public HealthBar healthBar;
    
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        respawnPoint = transform.position;
        scoreText.text = "Score: " + Scoring.totalScore;
    }

    
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        direction = Input.GetAxis("Horizontal");

        if (direction > 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            transform.localScale = new Vector2(0.26f, 0.26f);
        }
        else if (direction < 0f) {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            transform.localScale = new Vector2(-0.26f, 0.26f);
        }
        else
        {
            player.velocity = new Vector2(0,player.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }

        playerAnimation.SetFloat("Speed", Mathf.Abs(player.velocity.x));
        playerAnimation.SetBool("Ground", isTouchingGround);

        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="FallDectector")
        {
            transform.position = respawnPoint;
        }
        else if (collision.tag == "CheckPoint1")
        {
            respawnPoint = transform.position;
        }
        else if(collision.tag == "NextLevel")
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            respawnPoint = transform.position;
        }
         else if(collision.tag == "PreviusChegou")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            respawnPoint = transform.position;
        }
        else if (collision.tag == "Cystal")
        {
           Scoring.totalScore +=1;
           scoreText.text = "Score: " + Scoring.totalScore;
            collision.gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Spike")
        {
            healthBar.Damage(0.002f);
        }
       
    }
}
