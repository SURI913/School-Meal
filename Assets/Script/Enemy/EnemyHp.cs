using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    //체력은 전부 GameMnager에서 가져오고 변경한다.
    private double maxHP;  
    private double currentHP;
    private SpriteRenderer spriteRenderer;

    public double MaxHP => maxHP;               // maxHP 다른 함수에서 얘를 부를 수 있게
    public double CurrentHP => currentHP;      // currentHP ������ ������ �� �ִ� ������Ƽ (Get�� ����)

    
    //이거 가져오는게 실시간으로 모든 값 가져오는게 아니라 초기값만 가져오는지 체크

    //데미지 애니메이션
    private Animator animator;


    private void Start()
    {
        currentHP = 100;
        maxHP = 100;
        spriteRenderer = GetComponent<SpriteRenderer>();

        animator = GetComponent<Animator>(); //애니메이션
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("너드남 데미지 들어감");
        //데미지를 입은 경우 최근체력 감소시킴
        StartCoroutine(DamageMotion());
        currentHP -= damage;
        GameManager.instance.setenemyHP(currentHP);   //적 체력값 전달
        GameManager.instance.PlayEnemyHitSound();
        GameManager.instance.setWhoseDamage(1); //잡몹이 데미지 입음

        //체력이 0이면 플레이어 죽음
        if(currentHP <= 0) 
        {
            Debug.Log("Enemy HP : 0.. Die");
            GameManager.instance.HitCountCheck(1);
            Destroy(gameObject);
        }
    }
    //캐릭터 데미지 x이유 총알이 들어간걸 인식 x

    IEnumerator DamageMotion(){
        animator.SetBool("isHunted", true);
        yield return new WaitForSecondsRealtime(0.5f);
        animator.SetBool("isHunted", false);
    }
}
