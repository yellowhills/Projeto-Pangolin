using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public float SlimeSpeed = 3.5f;
    private Vector2 SlimeDirection;
    private Rigidbody2D SlimeRigidbody2D;

    public DetectController _detectionArea;

    // Start is called before the first frame update
    void Start()
    {
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
            SlimeDirection = (_detectionArea.detectedObjs[0].transform.position - transform.position).normalized;

            SlimeRigidbody2D.MovePosition(SlimeRigidbody2D.position + SlimeSpeed * Time.fixedDeltaTime * SlimeDirection);
        }

    }

}

