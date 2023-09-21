using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D PlayerRigidbody2D;
    public float PlayerSpeed;
    private Vector2 PlayerDirection;
    private float PlayerInitialSpeed;
    public float PlayerRunSpeed;
    private Animator PlayerAnimator;

    private bool IsAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRigidbody2D = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();

        PlayerInitialSpeed = 5;
        
    }

    // Update is called once per frame
    void Update()
    {



        PlayerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(PlayerDirection.sqrMagnitude > 0)
        {
            PlayerAnimator.SetInteger("Movimento", 1);

            if(PlayerDirection.y > 0)
            {
                PlayerAnimator.SetInteger("VerticalMovement", 1);


            }
            else if(PlayerDirection.y < 0)
            {
                PlayerAnimator.SetInteger("VerticalMovement", -1);
            }
            else
            {
                PlayerAnimator.SetInteger("VerticalMovement", 0);
            }


        }
        else
        {
            PlayerAnimator.SetInteger("Movimento", 0);
            PlayerAnimator.SetInteger("VerticalMovement", 0);
        }

        Flip();

        PlayerRun();

        OnAttack();

        if(IsAttacking)
        {
            PlayerAnimator.SetInteger("VerticalMovement", 0);
            PlayerAnimator.SetInteger("Movimento", 0);
            PlayerAnimator.SetInteger("Ataque", 1);
        }
        else
        {
            PlayerAnimator.SetInteger("Ataque", 0);
        }
    }

    void FixedUpdate()
    {
        PlayerRigidbody2D.MovePosition(PlayerRigidbody2D.position + PlayerDirection.normalized * PlayerSpeed * 
            Time.fixedDeltaTime); 
    }

    void Flip()
    {
        if (PlayerDirection.x > 0)
        {
            transform.eulerAngles = new Vector2(0f, 0f);

        }
        else if(PlayerDirection.x < 0)
        {
            transform.eulerAngles = new Vector2(0f, 180f);

        }

    }


    void PlayerRun()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            PlayerSpeed = PlayerRunSpeed;

        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            PlayerSpeed = PlayerInitialSpeed;

        }

    }

    void OnAttack()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl) || Input.GetMouseButtonDown(0))
        {
            IsAttacking = true;
            PlayerSpeed = 0;

        }

        if(Input.GetKeyUp(KeyCode.LeftControl) || Input.GetMouseButtonUp(0))
        {
            IsAttacking = false;
            PlayerSpeed = PlayerInitialSpeed;
        }
    }
}
