
/*
 *
 * jaime fins 2019
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharMovement
{
    public class PlayerMovement : MonoBehaviour
    {
        public Transform ground;
        //horizontal velocity 
        public float vy,vx;
        public float speed { get; set; }
        public float jumpForce { get; set; }
        private Animator myAnimator;
        private SpriteRenderer _spriteRenderer;
        private PlayerController myPlayerControllerJf;
        private bool isJumping;
        private float gravity;
        private bool isCrouched;
        
        // Start is called before the first frame update
        void Start()
        {
            isJumping = false;
            isCrouched = false;
            gravity = 1f;
            
            //jump force 
            jumpForce = 22;
            
            //character movement
            speed = 7;
            myAnimator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            vx = vy = 0;
            myPlayerControllerJf = GetComponent<PlayerController>();
        }

        
        // Update is called once per frame
        void Update()
        {
            if (vx < 0) _spriteRenderer.flipX = false;
            if (vx > 0) _spriteRenderer.flipX = true;
            
            if (myPlayerControllerJf.buttonA) { myAnimator.SetTrigger("kick"); }
            if (myPlayerControllerJf.buttonB) { myAnimator.SetTrigger("punch"); }
            
            //if the player pressed Up and my character is not jumping - preventing double jump
            if (myPlayerControllerJf.axisY == 1 && !isJumping)
            {
                vy=jumpForce;
                isJumping = true;
                myAnimator.SetBool("jump", isJumping);
            }
            
            //if the player pressed Down and my character is not jumping 
            if (myPlayerControllerJf.axisY == -1 && !isJumping)
            {
                //crouch
                isCrouched= true;
                myAnimator.SetBool("crouch", isCrouched);
            }
            else
            {
                isCrouched= false;
                myAnimator.SetBool("crouch", isCrouched);
                
            }
            
           

            //if the player is performing the Ground kick or the Ground punch animation or Crouch State shouldnt be able to move in X
            if (!isCrouched&& !myAnimator.GetCurrentAnimatorStateInfo(0).IsName("kick") && !myAnimator.GetCurrentAnimatorStateInfo(0).IsName("punch"))
            {
                transform.position = new Vector3(transform.position.x + vx * Time.deltaTime,transform.position.y);
               
            }
            
            //updates gravity - it is important to be done here as in the next statements
            //if the player reaches the floor it will prevent him from moving 
            vy -= gravity;
            transform.position = new Vector3(transform.position.x, transform.position.y +vy*Time.deltaTime);
            
            // the character reached the floor then he shouldnt be allowed to fall more.
            if (transform.position.y <= ground.position.y)
            {
                transform.position = new Vector3(transform.position.x, ground.position.y);
                vy = 0;
                isJumping = false; //he can jump again
                //setting the animation parameter to the same value as isJumping - in this case false
                myAnimator.SetBool("jump", isJumping);
            }
  
           
            //updates horizontal movement
            vx = myPlayerControllerJf.axisX * speed;
            myAnimator.SetInteger("vx", (int)vx);
            myAnimator.SetInteger("vy", Mathf.Abs((int)vy));
        }
    }
}