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

    //�θ� Ŭ������ scriptalbleObject�� ����ϸ� �ش� Ŭ������ ���� ������ ���·� ���尡��,
    //5��° �ٰ� ���� Ŭ���� ��ܿ� [CreateAssetMenu]�� ���̸� Project View�� Create("+") �޴��� �޴��� ��ϵȴ�.
}
