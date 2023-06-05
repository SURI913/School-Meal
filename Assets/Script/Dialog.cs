using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor.Rendering.PostProcessing;


public class Dialog : MonoBehaviour, IPointerDownHandler
{
    // 문자열을 큐를 이용에 순차적으로 출력하게함(선입선출:먼저들어간게 먼저 나온다.)
    public Text dialogText; // 대화 메세지
    public GameObject SkipButton; 

    public Queue<string> sentences;
    public string currentsentences;
    public float textSpeed = 0.1f; //텍스트 타이핑 속도 
    public bool istyping;
    void Start()
    {
        sentences = new Queue<string>(); //sentences 초기화
    }


   
    public void Ondialogue(string[] lines)
    {//대화 메세지 큐에 넣는 함수 
        sentences.Clear(); //큐에 들어있는 쓰레기 데이터 지워줌
        foreach (string line in lines)
        {
            sentences.Enqueue(line); //큐에 글자들을 차례대로 넣는다 
        }
        
    }

    public void NextSentences()
    {
        if(sentences.Count !=0)
        {
            currentsentences = sentences.Dequeue();
            //dequeue 를 통해 currentsentences 에 넣어주고 삭제한다.
            //여기서 꺼내온 string 은 코루틴을 이용해 타이핑 효과를 준다.
            istyping = true;
            SkipButton.SetActive(false);
            StartCoroutine(Typing(currentsentences));//StartCoroutine으로 Typing 실행하고 currentsentences전달
        }
    }
   

    IEnumerator Typing(string line)
    {
        dialogText.text = "";//inspector 에서 적은 글자를 초기화 
        foreach (char letter in line.ToCharArray())// ToCharArray()는 문자열을 문자배열로 반환해주는 함수 
        {
            dialogText.text += letter; //한글자씩 dialogText 더해줄거임 
            yield return new WaitForSeconds(textSpeed);//타이핑 딜레이 
        }
    }
    void Update()
    {
        if (dialogText.text.Equals(currentsentences))//dialogText==currentsentences 라면 한줄 끝
        {
            istyping = false;
        }
    }
    public void OnPointerDown(PointerEventData eventData)//해당 스크립트가 붙은 오브젝트에 클릭 될때 호출 
    {
        if (istyping)
        {
            NextSentences();//클릭시 skipButton 함수 호출 
        }
    }
}
