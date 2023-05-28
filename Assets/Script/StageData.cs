using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StageData : ScriptableObject
{
    [SerializeField]
    private Vector2 limitMin;
    [SerializeField] 
    private Vector2 limitMax;

    public Vector2 LimitMin => limitMin;
    public Vector2 LimitMax => limitMax;

    //부모 클래스로 scriptalbleObject를 사용하면 해당 클래스를 에셋 파일의 형태로 저장가능,
    //5번째 줄과 같이 클래스 상단에 [CreateAssetMenu]를 붙이면 Project View의 Create("+") 메뉴에 메뉴로 등록된다.
}
