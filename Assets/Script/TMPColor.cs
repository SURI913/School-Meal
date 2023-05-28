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
            // ������ �Ͼ������ ����������
            yield return StartCoroutine(ColorLerp(Color.white, Color.red));
            // ������ ���������� �Ͼ������ 
            yield return StartCoroutine(ColorLerp(Color.red, Color.white));
        }
    }

    private IEnumerator ColorLerp(Color startColor, Color endColor)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1)
        {
            // lerpTime �ð����� while() �ݺ��� ����
            currentTime += Time.deltaTime;
            percent = currentTime / lerpTime;

            // Text - TextMesh�� ��Ʈ ������ startColor���� endColor�� ����
            textBossWarning.color = Color.Lerp(startColor, endColor, percent);

            yield return null;
        }
    }

}
