using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TMPColor : MonoBehaviour
{
    [SerializeField]
    private float lerpTime = 0.1f;
    private TextMeshProUGUI textBossWarning;
    [SerializeField]
    private GameObject textBoss;

    private void Awake()
    {
        textBossWarning = GetComponent<TextMeshProUGUI>();
    }
    private IEnumerator Start()
    {
        StartCoroutine("ColorLerpLoop");
        yield return new WaitForSeconds(2.0f);
        StopCoroutine("ColorLerpLoop");
        Destroy(gameObject);
    }

    private IEnumerator ColorLerpLoop()
    {
        while(true)
        {
            // 색상이 하얀색에서 빨간색으로
            yield return StartCoroutine(ColorLerp(Color.white, Color.red));
            // 색상이 빨간색에서 하얀색으로 
            yield return StartCoroutine(ColorLerp(Color.red, Color.white));
        }
    }

    private IEnumerator ColorLerp(Color startColor, Color endColor)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1)
        {
            // lerpTime 시간동안 while() 반복문 실행
            currentTime += Time.deltaTime;
            percent = currentTime / lerpTime;

            // Text - TextMesh의 폰트 색상을 startColor에서 endColor로 변경
            textBossWarning.color = Color.Lerp(startColor, endColor, percent);

            yield return null;
        }
    }

}
