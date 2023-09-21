using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentObject : MonoBehaviour
{

    [Range(0, 1)]
   [SerializeField] private float TransparencyValue = 0.7f;
   [SerializeField] private float TransparencyFadeTime = .4f;

    private SpriteRenderer SpriteRenderer;



    // Start is called before the first frame update
    void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>())
        {
            StartCoroutine(FadeTree(SpriteRenderer, TransparencyFadeTime, SpriteRenderer.color.a, TransparencyValue));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            StartCoroutine(FadeTree(SpriteRenderer, TransparencyFadeTime, SpriteRenderer.color.a, 1f));
        }
    }

    private IEnumerator FadeTree(SpriteRenderer SpriteTransparency, float FadeTime, float StartValue, float TargetTransparency)
    {
        float TimeElapsed = 0;
        while(TimeElapsed < FadeTime)
        {
            TimeElapsed += Time.deltaTime;
            float NewAlpha = Mathf.Lerp(StartValue, TargetTransparency, TimeElapsed/FadeTime);
            SpriteTransparency.color = new Color(SpriteTransparency.color.r, SpriteTransparency.color.g, SpriteTransparency.color.b, NewAlpha);

            yield return null;
        }
        

    }
    // Update is called once per frame

}
