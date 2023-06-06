using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TutorialBase : MonoBehaviour
{
    // abstract가 추상
    //상속을 위한 추상 클래스
    
    // 해당 튜토리얼 과정을 시작 할 때 1회 호출
    public abstract void Enter();

    //해당 튜토리얼 과정을 진행하는 동안 매 프레임 호출
    public abstract void Execute(TutorialController controller);
    
    // 해당 튜토리얼 과정을 종료해 때 1회 호출
    public abstract void Exit();
}
