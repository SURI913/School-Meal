using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    //체력은 전부 GameMnager에서 가져오고 변경한다.
    private double maxHP;  
    private double currentHP;
    private SpriteRenderer spriteRenderer;

    private bool isDamage = false;
    [SerializeField]
    private float damageInterval = 1.0f; // 데미지를 주는 간격


    //데미지 애니메이션
    private Animator animator;



    private void Start()
    {
        //게임매니저에 있는 전체체력을 가져온다.
        currentHP = GameManager.instance.GetCurrnetHP();
        maxHP = GameManager.instance.GetMaxHP();
        spriteRenderer = GetComponent<SpriteRenderer>();

        animator = GetComponent<Animator>(); //애니메이션
    }

    public void TakeDamage(float damage)
    {
        //데미지를 입은 경우 최근체력 감소시킴
        StartCoroutine(DamageMotion());
        currentHP -= damage;
        GameManager.instance.PlayPlayerHitSound();
        GameManager.instance.setCurrentHp(currentHP);   //체력값 전달

        //체력이 0이면 플레이어 죽음
        if(currentHP <= 0) 
        {
            Debug.Log("Player HP : 0.. Die");
            Destroy(gameObject);
            Time.timeScale = 0; //일시정지
        }
    }

    IEnumerator DamageMotion(){
        animator.SetBool("isHunted", true);
        yield return new WaitForSecondsRealtime(0.5f);
        animator.SetBool("isHunted", false);
    }

    private void OnCollisionStay2D(Collision2D other) {
        //에너미 근접공격
        if(other.collider.CompareTag("Enemy") && isDamage ==false){
            StartCoroutine(DamageCooltime());
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Enemy"))
        {
            isDamage = false;
        }
    }

    IEnumerator DamageCooltime(){
        isDamage = true;
        TakeDamage(1);
        yield return new WaitForSecondsRealtime(damageInterval);
        isDamage = false;
    }


}
