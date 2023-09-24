using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DetectController : MonoBehaviour
{
    public string TagTargetDetect = "Player";
    
    public List<Collider2D> detectedObjs = new List<Collider2D>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == TagTargetDetect)
        {
            detectedObjs.Add(collision);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == TagTargetDetect)
        {
            detectedObjs.Remove(collision);

        }
    }
}
