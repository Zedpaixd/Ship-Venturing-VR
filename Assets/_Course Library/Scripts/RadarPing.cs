using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarPing : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float disappearTimer;
    private float disappearTimerMax;
    private Color color;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        disappearTimerMax = 1f;
        disappearTimer = 0f;
        color = new Color(1, 1, 1, 1f);
    }
    // Update is called once per frame
    void Update()
    {
        disappearTimer += Time.deltaTime;

        color.a = Mathf.Lerp(disappearTimerMax, 0f, disappearTimer / disappearTimerMax);
        spriteRenderer.color = color;

        if(disappearTimer>=disappearTimerMax)
        {
            Destroy(gameObject);
        }
    }

    public void SetColor()
    {
        this.color = color;
    }

    public void OnConnectedToServer()
    {
        this.disappearTimerMax = disappearTimerMax;
        disappearTimer = 0f;
     
    }
}
