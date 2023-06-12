using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HPControll : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI PlayerText; //플레이어 텍스트
    [SerializeField]
    private Slider PlayerSliderHP; //플레이어 체력바

    [SerializeField]
    private TextMeshProUGUI AllEnemyText; //적 텍스트
    [SerializeField]
    private Slider AllEnemySliderHP; //적 체력바

    [SerializeField]
    private GameObject EnemyHp;//오브젝트 해제
    [SerializeField]
    private GameObject Enemyfacefream;//오브젝트 해제


    [SerializeField]
    private GameObject Enemyface;
    [SerializeField]
    private GameObject MidBossface;
    [SerializeField]
    private GameObject Bossface;

    public static float PlayerMaxHp;
    public static float PlayerCurrentHP;
    public static float AllEnemyMaxHp;
    public static float AllEnemyCurrentHP;

    public void PlayerSliderEvent(){
        PlayerSliderHP.value = PlayerCurrentHP;
        PlayerSliderHP.maxValue = PlayerMaxHp;
        //체력이 0이면 0 만 띄움
        if(PlayerCurrentHP <= 0){
            PlayerText.text = $"{0}/{PlayerMaxHp}";
        }
        else{
            PlayerText.text = $"{PlayerCurrentHP}/{PlayerMaxHp}";
        }
    }

    public void AllEnemySliderEvent(){
        AllEnemySliderHP.value = AllEnemyCurrentHP;
        AllEnemySliderHP.maxValue = AllEnemyMaxHp;
        if(AllEnemyCurrentHP <= 0){
            AllEnemyText.text = $"{0}/{AllEnemyMaxHp}";
        }
        else{
            AllEnemyText.text = $"{AllEnemyCurrentHP}/{AllEnemyMaxHp}";
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerCurrentHP = ((float)GameManager.instance.GetCurrnetHP());
        PlayerMaxHp = ((float)GameManager.instance.GetMaxHP());
        PlayerSliderEvent();
        //변수 받아와서 누가 공격받았는지 보고 띄우도록 수정
        if(GameManager.instance.WhoseDamage() == 1){
            EnemyHp.SetActive(true);
            //잡몹이 공격당했다.
            AllEnemyCurrentHP = ((float)GameManager.instance.GetenemyHP());
            AllEnemyMaxHp = 100;
            AllEnemySliderEvent();
            Enemyfacefream.SetActive(true);
            Enemyface.SetActive(true);
            MidBossface.SetActive(false);
            Bossface.SetActive(false);
        }
        else if(GameManager.instance.WhoseDamage() == 2){
            EnemyHp.SetActive(true);
            //중간보스몹이 공격당했다.
            AllEnemyCurrentHP = ((float)GameManager.instance.GetMidBossHP());
            AllEnemyMaxHp = 500;
            AllEnemySliderEvent();
            Enemyfacefream.SetActive(true);
            Enemyface.SetActive(false);
            MidBossface.SetActive(true);
            Bossface.SetActive(false);
        }
        else if(GameManager.instance.WhoseDamage() == 3){
            EnemyHp.SetActive(true);
            //보스몹이 공격당했다.
            AllEnemyCurrentHP = ((float)GameManager.instance.GetBossHP());
            AllEnemyMaxHp = 800;
            AllEnemySliderEvent();
            Enemyfacefream.SetActive(true);
            Enemyface.SetActive(false);
            MidBossface.SetActive(false);
            Bossface.SetActive(true);
        }
        else if(GameManager.instance.WhoseDamage() == 0){
            //이도저도 아니라면 해제
            EnemyHp.SetActive(false);
            Enemyfacefream.SetActive(false);
        }
    }
}
