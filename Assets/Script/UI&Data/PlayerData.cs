using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    //게임 내 플레이어에게 필요한 정보 저장하는 스크립트
    //공격 주기값 변경하는것도 이걸로 바꿀 수 있을것같아요
    //오브젝트도 여기서 값 받아서 변경합시다.

    public static double CurrnetHp = 100;
    public static double MaxHp = 100;
    public static int coin = 0;

    public static int StageNum1 = 1;
    public static int StageNum2 = 1;
    public static GameObject WeaponL;
    public static GameObject WeaponR;

    void Start () {
        try {
            CurrnetHp = 100;
            MaxHp = 100;
            coin = 100;
            StageNum1 = 1;
            StageNum2 = 1;
        }       
        catch (NullReferenceException)
        {
            Debug.Log("myLight was not set in the inspector");
        }
    }

    private void Update() {
        if(GameManager.instance){   //게임매니저 인스턴스가 있다면
            CurrnetHp = GameManager.instance.GetCurrnetHP();
            MaxHp = GameManager.instance.GetMaxHP();
            coin = GameManager.instance.GetCoin();
            WeaponL = GameManager.instance.GetWeaposnL();
            WeaponR = GameManager.instance.GetWeaposnR();
        }
        else{
            CurrnetHp = 100;
            MaxHp = 100;
            coin = 0;
            StageNum1 = 1;
            StageNum2 = 1;
            //인스턴스가 없으면 싹다 초기화
        }
    }

    public bool S1_1Clear = false;
    public bool S1_2Clear = false;
    public bool S1_3Clear = false;
    public bool S1_4Clear = false;
    public bool S2_1Clear = false;
    public bool S2_2Clear = false;
    public bool S2_3Clear = false;
    public bool S3_1Clear = false;
    public bool S3_2Clear = false;
    public bool S3_3Clear = false;
    public bool S4_1Clear = false;
    public bool S4_2Clear = false;
    public bool S4_3Clear = false;
}
