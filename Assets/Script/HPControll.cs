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

    private double PlayerMaxHp;
    private double PlayerCurrentHP;
    private double AllEnemyMaxHp;
    private double AllEnemyCurrentHP;

    public void PlayerSliderEvent(){
        PlayerSliderHP.value = (float)PlayerCurrentHP;
        PlayerText.text = $"{PlayerCurrentHP}/{PlayerMaxHp}";
    }

    public void AllEnemySliderEvent(){
        AllEnemySliderHP.value = (float)AllEnemyCurrentHP;
        AllEnemyText.text = $"{AllEnemyCurrentHP}/{AllEnemyMaxHp}";
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerCurrentHP = GameManager.instance.GetCurrnetHP();
        PlayerMaxHp = GameManager.instance.GetMaxHP();
        PlayerSliderEvent();
        //변수 받아와서 누가 공격받았는지 보고 띄우도록 수정
        if(GameManager.instance.WhoseDamage() == 1){
            EnemyHp.SetActive(true);
            //잡몹이 공격당했다.
            AllEnemyCurrentHP = GameManager.instance.GetenemyHP();
            AllEnemyMaxHp = GameManager.instance.GetenemyHP();
            AllEnemySliderEvent();
            Enemyface.SetActive(true);
            MidBossface.SetActive(false);
            Bossface.SetActive(false);
        }
        else if(GameManager.instance.WhoseDamage() == 2){
            EnemyHp.SetActive(true);
            //중간보스몹이 공격당했다.
            AllEnemyCurrentHP = GameManager.instance.GetMidBossHP();
            AllEnemyMaxHp = 200;
            AllEnemySliderEvent();
            Enemyface.SetActive(false);
            MidBossface.SetActive(true);
            Bossface.SetActive(false);
        }
        else if(GameManager.instance.WhoseDamage() == 3){
            EnemyHp.SetActive(true);
            //보스몹이 공격당했다.
            AllEnemyCurrentHP = GameManager.instance.GetBossHP();
            AllEnemyMaxHp = 500;
            AllEnemySliderEvent();
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