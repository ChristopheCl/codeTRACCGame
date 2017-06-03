using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    #region oud versnellen vars
    //animation speed increase
    //public float animIncrease = 60f;
    //public float walkSpeedIncrease = 4f;
    #endregion

    public float speedMultiplier;
    public float speedIncreaseMilestone;
    private float speedMilestoneCount;
    public float animMultiplier;

    //animation
    private Animator anim;
    public float animationWalkSpeed;

    //audio
    public AudioClip jumpAudio;

    void Start()
    {
        anim = GetComponent<Animator>();
        myController = GetComponent<CharacterController>();
        animationWalkSpeed = 1f;
        runSpeed = 7f;
        animMultiplier = 1f;
        speedMilestoneCount = speedIncreaseMilestone;
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

        if(transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            runSpeed = runSpeed * speedMultiplier;
            animationWalkSpeed = animationWalkSpeed * animMultiplier;
        }

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
        // animationWalkSpeed += Time.deltaTime / animIncrease;
        // anim.SetFloat("movementSpeed", animationWalkSpeed);

        // runSpeed += Time.deltaTime / walkSpeedIncrease;


        // if (runSpeed >= 23)
        // {
        //     runSpeed = 23;
        // }

        //if (animationWalkSpeed >= 3)
        //{
        //     animationWalkSpeed = 4;
        //}
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

    void SpeedApply()
    {
        //Debug.Log("speed applied");
        myController.Move(transform.forward * forwardSpeed * Time.deltaTime); // myController.Move(transform.forward * forwardSpeed * Time.deltaTime);
        myController.Move(new Vector3(0, ySpeed, 0) * Time.deltaTime);
    }
}
