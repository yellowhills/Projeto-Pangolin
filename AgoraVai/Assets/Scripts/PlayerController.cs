using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D PlayerRigidbody2D;
    public float PlayerSpeed;
    private Vector2 PlayerDirection;


    void Start()
    {
        PlayerRigidbody2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    }

    void FixedUpdate()
    {
        PlayerRigidbody2D.MovePosition(PlayerRigidbody2D.position + PlayerDirection * PlayerSpeed * Time.fixedDeltaTime);
        

    }
}
