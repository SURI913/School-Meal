using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    //게임 내 플레이어에게 필요한 정보 저장하는 스크립트
    

    public static double CurrnetHp = 100;
    public static double MaxHp = 100;
    public static int coin = 0;
    public static string currnetStage = "1-1";
    public static Stack<string> StageRoute = new Stack<string>();

    public static int  WeaponType = 0;

    void Awake () { //가장 먼저 업뎃
        try {
            CurrnetHp = 100;
            MaxHp = 100;
            coin = 100;
            StageRoute.Push("1-1");
        }       
        catch (NullReferenceException)
        {
            Debug.Log("myLight was not set in the inspector");
        }
    }

    //게임매니저가 있을 때 데이터를 초기화 한다.
    private void Update() { //이거 문제인가? 체크하자
        if(GameManager.instance){   //게임매니저 인스턴스가 있다면
            CurrnetHp = GameManager.instance.GetCurrnetHP();
            MaxHp = GameManager.instance.GetMaxHP();
            coin = GameManager.instance.GetCoin();
            WeaponType = playerattack.atktype;
        }
        else{
            //스토리 씬 제외해야함
            CurrnetHp = 100;
            MaxHp = 100;
            coin = 0;
            //CurrentStageTag = "1-1";
            //BackStageTag = "1-1"; //스트링으로 관리
            //인스턴스가 없으면 싹다 초기화
        }
    }

    public static bool S1_1Clear = false;
    public static bool S1_2Clear = false;
    public static bool S1_3Clear = false;
    public static bool S2_1Clear = false;    //코인방
    public static bool S2_2Clear = false;
    public static bool S2_3Clear = false;
    public static bool S3_1Clear = false;
    public static bool S3_2Clear = false;
    public static bool S4_1Clear = false; //코인방
    public static bool S4_2Clear = true;
    public static bool S4_3Clear = false;
    public static bool MidBossClear = false;
    public static bool BossClear = false;
}
