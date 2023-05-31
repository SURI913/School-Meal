using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState {  MoveToAppearpoint , Phase01 , Phase02, }

public class Boss : MonoBehaviour
{
    [SerializeField]
    private GameObject bossDie;
    [SerializeField]
    private float bossAppearPoint = 0;
    private BossState bossState;
    private Movement2D movement2D;
    private BossWeapon bossWeapon;
    private BossHP bossHP;
    //데미지 애니메이션
    private Animator animator;

    private void Awake()
    {
        movement2D = GetComponent<Movement2D>();
        bossWeapon = GetComponent<BossWeapon>();
        bossHP = GetComponent<BossHP>();
        animator = GetComponent<Animator>();
    }
    public void ChangeState(BossState newState)
    {
        // ������ ������̴� ���� ����
        StopCoroutine(bossState.ToString());
        // ���� ����
        bossState = newState;
        // ���ο� ���� ���
        StartCoroutine(bossState.ToString());
    }

    private IEnumerator MoveToAppearpoint()
    {
        movement2D.MoveTo(Vector3.down);

        while (true)
        {
            if(transform.position.y <= bossAppearPoint )
            {
                //animator.SetBool("isRun", false);   //애니메이션
                // �̵������� (0, 0, 0)���� ������ ���ߵ��� �Ѵ�.
                movement2D.MoveTo(Vector3.zero);
                // Phase01 ���·� ����
                ChangeState(BossState.Phase01);
            }
            yield return null;
        }
    }

    private IEnumerator Phase01()
    {
        animator.SetBool("isRun", true);   //애니메이션
        // �� ������ ��� ���� ����
        bossWeapon.StartFiring(AttackType.CircleFire);

        while (true)
        {
            if(bossHP.currentHP <= 500*0.7f)
            {
                // �� ��� ���� ����
                Debug.Log("1페이즈 끝");
                bossWeapon.StopFiring(AttackType.CircleFire);
                // 2페이즈 시작
                bossWeapon.StartFiring(AttackType.CircleFire02);
                break;
            }
            yield return null;
        }
        while (true)
        {
            if (bossHP.currentHP <= 500 * 0.3f)
            {
                //animator.SetBool("isRun", false);   //애니메이션
                // �� ��� ���� ����
                Debug.Log("2페이즈 끝");
                bossWeapon.StopFiring(AttackType.CircleFire02);
                // 3페이즈 시작
                bossWeapon.StartFiring(AttackType.CircleFire03);
                break;
            }
            yield return null;
        }
    }

    public void Ondie()
    {
        // 보스 죽음 파티클 생성
        Instantiate(bossDie, transform.position, Quaternion.identity);
        // 보스삭제
        Destroy(gameObject);
    }

}
