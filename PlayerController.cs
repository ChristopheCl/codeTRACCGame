using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region UITLEG SCRIPT
/* de control van player 
 * player loopt vanzelf
 * snelheid versnelt ook na bepaalde tijd/afstand
 * jump => klik/tap op scherm */
#endregion

public class PlayerController : MonoBehaviour
{
    //run
    private CharacterController myController;

    public float gravityForce;
    public float ySpeed;

    public float jumpForce;
    public float hangTime;
    public float hangTimer;
    public float gravityModifier;

    public float forwardSpeed;
    public float runSpeed;
    public float lerpTime;
    // public Vector3 moveDirection = Vector3.zero;    

    public float newSpeed;
    public float newAnimationWalkSpeed;

    #region oud versnellen vars
    //animation speed increase
    public float animIncrease = 60f;
    public float walkSpeedIncrease = 4f;
    #endregion

    //public float speedMultiplier;
    //public float speedIncreaseMilestone;
    //private float speedMilestoneCount;
    //public float animMultiplier;

    //animation
    private Animator anim;
    public float animationWalkSpeed;

    //public float RunSpeed
    //{
    //    get { return runSpeed; }
    //    set { runSpeed = value; }
    //}

    public float NewSpeed
    {
        get { return newSpeed; }
        set { newSpeed = value; }
    }

    public float NewAnimationWalkSpeed
    {
        get { return newAnimationWalkSpeed; }
        set { newAnimationWalkSpeed = value; }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        myController = GetComponent<CharacterController>();
        //animationWalkSpeed = 1f;
        runSpeed = 7f;
        animationWalkSpeed = 1f;
        //animMultiplier = 1.1f;
        // speedMilestoneCount = speedIncreaseMilestone;
    }

    void FixedUpdate()
    {
        SpeedApply();
    }

    void Update()
    {

        myGravity();
        Jump();
        ForwardMovement();
    }

    void myGravity()
    {
        //Debug.Log("before changed" + ySpeed + "to velocity" + myController.velocity.y);

        /*if(transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            runSpeed = runSpeed * speedMultiplier;
            animationWalkSpeed = animationWalkSpeed * animMultiplier;
        }
        */
        ySpeed = myController.velocity.y;
        // Debug.Log("changed" + ySpeed);
        ySpeed -= gravityForce * Time.deltaTime;
    }

    void Jump()
    {
        if (myController.isGrounded && Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("JumpStart");

            hangTimer = hangTime;
            ySpeed = jumpForce;
            SpeedApply();
            //  Debug.Log("jump" + ySpeed);

            AudioManager.instance.PlaySound("Player Jump", transform.position);
        }
        else
        {
            if (hangTimer > 0)
            {
                hangTimer -= Time.deltaTime;
                ySpeed += gravityModifier * hangTimer * Time.deltaTime;
            }
        }
        // anim.SetTrigger("Ground")
    }

    void ForwardMovement()
    {
        #region oud versnellen
       //Debug.Log(animationWalkSpeed);
        animationWalkSpeed += Time.deltaTime / animIncrease;
        anim.SetFloat("movementSpeed", animationWalkSpeed);

        runSpeed += Time.deltaTime / walkSpeedIncrease;


        if (runSpeed >= 15)
        {
            runSpeed = 15;
        }

        if (animationWalkSpeed >= 1.5f)
        {
            animationWalkSpeed = 1.5f;
        }

        NewSpeed = runSpeed;
        NewAnimationWalkSpeed = animationWalkSpeed;
        
        #endregion

        if (myController.isGrounded)
        {
            // anim.SetBool("isGrounded", true);
            if (forwardSpeed <= runSpeed - .1f || forwardSpeed >= runSpeed + .1f)
            {
                forwardSpeed = Mathf.Lerp(forwardSpeed, runSpeed, lerpTime);
            }
            else
            {
                forwardSpeed = runSpeed;
            }
        }
    }

    public void resetSpeedToBegin()
    {
        runSpeed = 7f;
        animationWalkSpeed = 1f;
    }

    void SpeedApply()
    {
        //Debug.Log("speed applied");
        myController.Move(transform.forward * forwardSpeed * Time.deltaTime); // myController.Move(transform.forward * forwardSpeed * Time.deltaTime);
        myController.Move(new Vector3(0, ySpeed, 0) * Time.deltaTime);
    }
}
