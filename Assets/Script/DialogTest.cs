using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogTest : MonoBehaviour
{
    [SerializeField]
    private DialogSystem dialogSystem01;
    [SerializeField]
    private DialogSystem dialogSystem02;
    [SerializeField]
    private TextMeshProUGUI textCountdown;

    private IEnumerator Start()
    {
        textCountdown.gameObject.SetActive(false);
        //첫번쨰 시작 
       
        yield return new WaitUntil(() => dialogSystem01.UpdateDialog());

        textCountdown.gameObject.SetActive(true);
        //int count = 3;
        //while(count>0)
        //{
        //    textCountdown.text = count.ToString();
        //    count--;
        //    yield return new WaitForSeconds(1);
        //}
        textCountdown.gameObject.SetActive(false);

        //두번째 시작
        yield return new WaitUntil(() => dialogSystem02.UpdateDialog());

        textCountdown.gameObject.SetActive(true);
        textCountdown.text = "GAME START";

        yield return new WaitForSeconds(2);

        UnityEditor.EditorApplication.ExitPlaymode();
        }
}
