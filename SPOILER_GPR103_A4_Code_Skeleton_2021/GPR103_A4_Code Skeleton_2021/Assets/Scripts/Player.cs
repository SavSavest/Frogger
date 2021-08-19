using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShortcutManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This script must be used as the core Player script for managing the player character in the game.
/// </summary>
public class Player : MonoBehaviour
{
    public string playerName = ""; //The players name for the purpose of storing the high score
   
    public int playerTotalLives; //Players total possible lives.
    public int playerLivesRemaining; //PLayers actual lives remaining.
   
    public bool playerIsAlive = true; //Is the player currently alive?
    public bool playerCanMove = false; //Can the player currently move?
    public bool isOnPlatform = false;
    public bool isInWater = false;
    public bool didPlayerDrown = false;
    public bool hitByCar = false;
    public int playerScore = 0;// ---------------- ADD PLAYER SCORE AND DISPLAY-------
    private Animator animator;
   
    //Audio
    private AudioSource myAudioSource;
    public AudioClip jumpSound;
    public AudioClip carHitSound;
    public AudioClip drownSound;
    private GameManager myGameManager; //A reference to the GameManager in the scene.
   
   



    // Start is called before the first frame update
    void Start()
    {
        myGameManager = GameObject.FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
        

    }

    // Update is called once per frame
    void Update()
    {
        myAudioSource = GetComponent<AudioSource>();
        //Player movement, player can move 1 pixel at a time.
        if (playerIsAlive == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < myGameManager.levelConstraintTop)
            {
                animator.SetBool("isHopping", true);
                transform.Translate(new Vector2(0, 1));
                myAudioSource.clip = jumpSound;
                myAudioSource.pitch = Random.Range(0.5f, 1f);
                myAudioSource.Play();
                myGameManager.UpdateScore(1);
            }

            else if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > myGameManager.levelConstraintLeft)
            {
                animator.SetBool("isHopping", true);
                transform.Translate(new Vector2(-1, 0));
                myAudioSource.clip = jumpSound;
                myAudioSource.pitch = Random.Range(0.5f, 1f);
                myAudioSource.Play();
            }

            else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > myGameManager.levelConstraintBottom)
            {
                animator.SetBool("isHopping", true);
                transform.Translate(new Vector2(0, -1));
                myAudioSource.clip = jumpSound;
                myAudioSource.pitch = Random.Range(0.5f, 1f);
                myAudioSource.Play();
            }

            else if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < myGameManager.levelConstraintRight)
            {
                animator.SetBool("isHopping", true);
                transform.Translate(new Vector2(1, 0));
                myAudioSource.clip = jumpSound;
                myAudioSource.pitch = Random.Range(0.5f, 1f);
                myAudioSource.Play();
                
            }

            else
            {
                animator.SetBool("isHopping", false);
            }

            //Rotate Frog in direction it's going
          


        }
        
        
    }

    void LateUpdate()
    {
        if (playerIsAlive == true)
        {
            if (isInWater == true && isOnPlatform == false)
            {
                PlayerDrowned();
            }
        }
    }

    //Player collisions
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerIsAlive == true)
        {
            if (collision.transform.GetComponent<Vehicle>() != null)
            {
                KillPlayer();
            }

            if (collision.transform.gameObject.tag == "Water")
            {
                isInWater = true;
            }

            else if (collision.transform.GetComponent<Platform>() != null)
            {
                transform.SetParent(collision.transform);
                isOnPlatform = true;
                
            }

            else if (collision.transform.tag == "Bonus")
            {
                myGameManager.UpdateScore(10);
                Destroy(collision.gameObject);
                
               

            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (playerIsAlive == true)
        {
            if (collision.transform.GetComponent<Platform>() != null)
            {
                transform.SetParent(null);
                isOnPlatform = false;
            }
            else if(collision.transform.tag == "Water")
            {
                isInWater = false;
            }
        }

    }

    //When the player hits a vehicle
    void KillPlayer()
    {
        hitByCar = false;
        playerIsAlive = false;
        playerCanMove = false;
        print("squished!");
        myAudioSource.PlayOneShot(carHitSound);
        

        if (hitByCar == false)
        {
        animator.SetBool("diedByCar", true);
            Invoke("Restart", 2f);
        }
        else
        {
            animator.SetBool("diedByCar", false);
        }
        

    }

    //Yes, even though it is a frog... it drowned, don't @ me.
    void PlayerDrowned()
    {
        didPlayerDrown = false;
        playerIsAlive = false;
        playerCanMove = false;
        myAudioSource.PlayOneShot(drownSound);
        print("You have drowned");
        if (didPlayerDrown == false)
        {
            animator.SetBool("diedByWater", true);
            Invoke("Restart", 2f);
        }
        else
        {
            animator.SetBool("diedByWater", false);
        }
     }

    void Restart()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //A function to collect and store the player score
}

   




                
