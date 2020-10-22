using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float direction;
    private Rigidbody2D playerBody;
    private Animator animPlayer;
    private bool isGrounded = false;
    private float groundRadius = 0.4f;
    private float ReloadTime = 0.5f;
    private float Reload = 0.0f;
    public LayerMask WhatIsGround;
    public Transform groundCheck;
    public Joystick joystick;
    public float speed = 3.0f;
    void Start()
    {

        playerBody = GetComponent<Rigidbody2D>();
        animPlayer = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        Reload -= Time.deltaTime;
    }
    public void Jump()
    {
        if (isGrounded)
        {
            playerBody.AddForce(new Vector2(0, 10.0f), ForceMode2D.Impulse);
        }
    }

    public void Attack()
    {
        if(Reload <= 0 && !isAnimationHitPlaying("hit"))
        {
            var _attack = GetComponent<Attack>();
            _attack._Attack();
            Reload = ReloadTime;
        }
    }

    public bool isAnimationHitPlaying(string animationName)
    {
        var animatorStateInfo = animPlayer.GetCurrentAnimatorStateInfo(0);

        if (animatorStateInfo.IsName(animationName))
            return true;
        else
            return false;
    }

    private void FixedUpdate()
    {
      

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, WhatIsGround);
        direction = joystick.Horizontal;
        playerBody.velocity = new Vector2(speed * direction, playerBody.velocity.y);
        animPlayer.SetFloat("isRun", Mathf.Abs(direction));
        animPlayer.SetBool("isGrounded", isGrounded);
        animPlayer.SetFloat("vSpeed", playerBody.velocity.y);
        Flip(direction);
       

    }




    void Flip(float direction)
    {
        if(direction > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        if(direction < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

}
