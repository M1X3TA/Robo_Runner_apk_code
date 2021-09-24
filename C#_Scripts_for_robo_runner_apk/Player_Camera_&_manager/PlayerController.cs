using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public float maxSpeed;

    private int desiredLane = 1; //0:left, 1:middle, 2:right
    public float laneDistance = 4; //the distance between two lanes

   

    public float jumpForce;
    public float Gravity = -20;


    public Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
     void Update()
    {
        if (!PlayerManager.isGameStarted)
            return;

        //Increase Speed
        if(forwardSpeed < maxSpeed)

        forwardSpeed += 0.1f * Time.deltaTime;

        animator.SetBool("isGameStarted", true);
        direction.z = forwardSpeed;

        
        

      
        if (controller.isGrounded)
        {

            direction.y = 0;
            if (Swipe_Controller.swipeUp)
            {
               
                Jump();
                //animator.SetBool("isGrounded", isGrounded);
            }

        }
        else
        {
            direction.y += Gravity * Time.deltaTime;
            //animator.SetBool("isGrounded", !isGrounded);
       
        }


        //Gather the inputs on which lane we should be


        if (Swipe_Controller.swipeRight)
        {
            desiredLane++;
            if (desiredLane == 3)
            desiredLane = 2;
        
        }

        if (Swipe_Controller.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
            desiredLane = 0;

        }


        //Calculate where we should be in the future

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;


        if(desiredLane == 0)
        {

            targetPosition += Vector3.left * laneDistance;
        
        }
        
        else if (desiredLane == 2)
        
        {

           targetPosition += Vector3.right * laneDistance;
        
        }
        if (transform.position != targetPosition)
        {
            Vector3 diff = targetPosition - transform.position;
            Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
            if (moveDir.sqrMagnitude < diff.sqrMagnitude)
                controller.Move(moveDir);
            else
                controller.Move(diff);



        }
      


      
        controller.Move(direction * Time.deltaTime);

        //transform.position = Vector3.Lerp(transform.position, targetPosition, 10 * Time.deltaTime);

    }



    private void Jump()
    {
        direction.y = jumpForce;

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Obstacle")
        {
            PlayerManager.gameOver = true;
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
        }
    }

}
