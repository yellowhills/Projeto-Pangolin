using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody2D PlayerRigidbody2D;
    public float PlayerSpeed;
    private Vector2 PlayerDirection;
    private float PlayerInitialSpeed;
    public float PlayerRunSpeed;
    private Animator PlayerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRigidbody2D = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();

        PlayerInitialSpeed = PlayerSpeed;
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(PlayerDirection.sqrMagnitude > 0)
        {
            PlayerAnimator.SetInteger("Movimento", 1);

        }
        else
        {
            PlayerAnimator.SetInteger("Movimento", 0);
        }

        Flip();

        PlayerRun();
    }

    void FixedUpdate()
    {
        PlayerRigidbody2D.MovePosition(PlayerRigidbody2D.position + PlayerDirection * PlayerSpeed * 
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
}
