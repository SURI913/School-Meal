using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialFadeEffect : TutorialBase  //상속 받아옴
{
    [SerializeField]
    private FadeEffect fadeEffect;  //페이드 주는 변수
    [SerializeField]
    private GameObject fadeEffectObject;  //페이드 주는 변수

    //효과 재생이 완료되었는지 체크하는 변수
    [SerializeField]
    private bool isFadeIn = false;
    private bool isCompleted = false;
    
    public override void Enter(){
        fadeEffectObject.SetActive(true);
        if(isFadeIn == true){
            fadeEffect.FadeIn(OnAfterFadeEffect);
        }
        else{
            fadeEffect.FadeOut(OnAfterFadeEffect);
        }
        //추상클래스 튜토리얼베이스를 상속받았기 때문에 추상 메소드인
        //Enter(), Execute(), Exit()메소드 재정의
    }

    //페이드 효과 종료 함수
    private void OnAfterFadeEffect(){
        fadeEffectObject.SetActive(false);
        isCompleted = true;

    }
    
    public override void Execute(TutorialController controller){
       if(isCompleted == true){
            controller.SetNextTutorial();
        }
    }

    public override void Exit(){ }  //1회호출
}
