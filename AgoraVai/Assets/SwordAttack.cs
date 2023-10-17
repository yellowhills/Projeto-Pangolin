using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{

    public float damage = 3;
    
    Vector2 RTattackOffset;

    public Collider2D swordCollider;
    // Start is called before the first frame update
    private void Start()
    {
       
        RTattackOffset = transform.position;
    }

    

    public void AttackR()
    {
        
        swordCollider.enabled = true;
        transform.localPosition = RTattackOffset;
    }

    public void AttackL()
    {
        
        swordCollider.enabled = true;
        transform.localPosition = new Vector3(RTattackOffset.x * -1, RTattackOffset.y);
    }

    public void StopAttack()
    {
        swordCollider.enabled = false;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            //Controle de dano
            SlimeController enemy = collision.GetComponent<SlimeController>();

            if(enemy != null)
            {
                enemy.SlimeHP -= damage;
            }
        }
    }
}
