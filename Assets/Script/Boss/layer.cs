using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class layer : MonoBehaviour
{
    public float lerpTime = 0.1f;
    [SerializeField]
    private int damage = 15;
    SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();

    }


    private void OnEnable()
    {
        StartCoroutine("ColorLerpLoop");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Player") && this.gameObject.tag=="Enemy")
        {
            collision.GetComponent<PlayerHp>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    private IEnumerator ColorLerpLoop()
    {
        while (true)
        {
            // 색상을 하얀색에서 빨간색으로
            //yield return StartCoroutine(ColorLerp(Color.white, Color.red));
            // 색상을 빨간색에서
            // yield return StartCoroutine(ColorLerp(Color.red, Color.white));
            yield return StartCoroutine("Invincibility");
        }
    }
    private IEnumerator ColorLerp(Color startColor, Color endColor)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while(percent < 1)
        {
            // lerpTime 시간동안 while() 반복문 실행
            currentTime += Time.deltaTime;
            percent = currentTime / lerpTime;

            sprite.color = Color.Lerp(startColor, endColor, percent);

            yield return null;
        }
        sprite.color = endColor;
        yield return new WaitForSeconds(1f);
        Destroy(sprite.gameObject);
    }

    IEnumerator Invincibility()  // 색깔 깜빡임
    {
        int countTime = 0;
        while (countTime <= 8)   //0.2초마다 countTime++
        {
            if (countTime % 2 == 0) sprite.color = new Color32(255, 0, 0, 50);
            else sprite.color = new Color32(255, 0, 0, 90);
            yield return new WaitForSeconds(0.2f);
            countTime++;
        }
        sprite.color = new Color32(255, 0, 0, 200);
        this.gameObject.tag = "Enemy";
        yield return new WaitForSeconds(1.5f);
        this.gameObject.tag = "Untagged";
        Destroy(sprite.gameObject);
    }


}
