
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{


    public CharacterController2D controller;
    public Animator animator;
    public Joystick joystick;
    public GameObject GameManager;


    [Range(20f, 60f)]
    public float runSpeed = 40f;
    [HideInInspector]
    public float horizontalMove = 0f;
    float verticalMove = 0f;


    [HideInInspector]
    public bool pause = false;
    bool jump = false;
    bool Grounded = true;

    //Animation Bools
    bool JumpAnimation;
    bool MovingAnimation;
    //Animation Bools




    private void Awake()
    {

        GameManager.GetComponent<GameManager>().StartGame();            //StartGame Music and Game

    }

    void Update()
    {


        //Animation Handling ----------------------------------------------------------------

        if (MovingAnimation == false)
        {
            animator.SetBool("StartAnim", false);
        }
        if (MovingAnimation == true)
        {
            animator.SetBool("StartAnim", true);
        }
        if (JumpAnimation == true)
        {
            animator.SetBool("IsJumping", true);
        }
        if (JumpAnimation == false)
        {
            animator.SetBool("IsJumping", false);
        }


        //Animation Handling ----------------------------------------------------------------


        if (transform.position.y < -1f)
        {
            GameManager.GetComponent<GameManager>().GameOver();         //If Player Dead Stop Music and show Game Over
        }

        if (!pause)
        {
            //Sensitivity Handling of Joystick - Horizontal Movement
            if (joystick.Horizontal >= 0.5f)
            {
                horizontalMove = runSpeed;
            }
            else if (joystick.Horizontal <= -0.5f)
            {
                horizontalMove = -runSpeed;
            }
            else
            {
                horizontalMove = 0f;
            }
            //Sensitivity Handling of Joystick  - Horizontal Movement


            //Animation Handling --------------------------------
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
            animator.SetFloat("Pressing", Mathf.Abs(horizontalMove));

            if (Mathf.Abs(horizontalMove) < 0.01f)
            {
                MovingAnimation = false;
                
            }
            //Animation Handling --------------------------------


            verticalMove = joystick.Vertical;
            if (verticalMove >= 0.5f && Grounded)     //Jumping
            {
                jump = true;

                JumpAnimation = true;
              
            }


            if (Input.GetButtonDown("Cancel"))          //Pausing Game
            {
                GameManager.GetComponent<GameManager>().PauseGame();
            }

        }
    }


    void FixedUpdate()
    {

        //Fixed Movement Horizontal and Vertical
        if (!pause)
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
            jump = false;
        }

    }





    private void OnTriggerEnter2D(Collider2D collision)
    {

        bool rightofme = joystick.Horizontal > 0 && collision.gameObject.transform.position.x > transform.position.x;
        bool leftofme = joystick.Horizontal < 0 && collision.gameObject.transform.position.x < transform.position.x;
        bool underneathme = collision.gameObject.transform.position.y <= transform.position.y;


        if (collision.gameObject.tag == "FIN") {
            GameManager.GetComponent<GameManager>().HitFinish();            //Ziel erreicht 
        }


        if (collision.gameObject.tag == "groundandobst" && underneathme)    //Auf Boden oder Gegenstand
        {
            Grounded = true;

            JumpAnimation = false;
          
        }


        if (collision.gameObject.tag == "pressing" && (rightofme || leftofme))  //Verschiebbares Hinderniss
        {

            MovingAnimation = true;
          

        }
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        bool rightofme = joystick.Horizontal > 0 && collision.gameObject.transform.position.x > transform.position.x;
        bool leftofme = joystick.Horizontal < 0 && collision.gameObject.transform.position.x < transform.position.x;
        bool underneathme = collision.gameObject.transform.position.y <= transform.position.y;

        if (collision.gameObject.tag == "pressing" && (rightofme || leftofme))  //An einem Verschiebbares Hinderniss
        {
            MovingAnimation = true;
            

        }
        if (collision.gameObject.tag == "groundandobst" && underneathme)        //Auf Boden oder Gegenstand
        {

            JumpAnimation = false;
        
            Grounded = true;


        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "pressing") //Verlasse ich Verschiebbares Hinderniss
        {

            MovingAnimation = false;
            

        }

        if (collision.gameObject.tag == "groundandobst")    //Verlasse ich Boden oder Gegenstand
        {
            Grounded = false;

        }
    }







}
