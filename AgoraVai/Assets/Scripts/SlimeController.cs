using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public float SlimeHP
    {
        set
        {
            slimeHP = value;
            if(slimeHP <= 0)
            {
                Defeated();
            }
        }
        get
        {
            return slimeHP;
        }


    }
    public float slimeHP = 1;
    public float SlimeSpeed = 3.5f;
    private Vector2 SlimeDirection;
    private Rigidbody2D SlimeRigidbody2D;

    Animator animator;

    public DetectController _detectionArea;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        SlimeRigidbody2D = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        SlimeDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));   
    }

    private void FixedUpdate()
    {
        if(_detectionArea.detectedObjs.Count > 0) 
        {
            animator.SetBool("Detect", true);
            SlimeDirection = (_detectionArea.detectedObjs[0].transform.position - transform.position).normalized;

            SlimeRigidbody2D.MovePosition(SlimeRigidbody2D.position + SlimeSpeed * Time.fixedDeltaTime * SlimeDirection);
        }
        

    }

    

     public void Defeated()
    {
        animator.SetTrigger("Defeated");

    }

    public void RemoveEnemy()
    {
        
        Destroy(gameObject);
    }
}

