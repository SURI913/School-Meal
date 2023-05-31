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
        animator.SetBool("isRun", true);   //애니메이션
        // �̵����� ����[�ڷ�ƾ ���� �� 1ȸ ȣ��]
        movement2D.MoveTo(Vector3.down);

        while (true)
        {
            if(transform.position.y <= bossAppearPoint )
            {
                animator.SetBool("isRun", false);   //애니메이션
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
                animator.SetBool("isRun", false);   //애니메이션
                // �� ��� ���� ����
                Debug.Log("������ ����");
                bossWeapon.StopFiring(AttackType.CircleFire);
                // phase02�� ����
                ChangeState(BossState.Phase02);
            }
            yield return null;
        }
    }

    private IEnumerable Phase02()
    {
        animator.SetBool("isRun", true);   //애니메이션
        Debug.Log("������ ����");
        bossWeapon.StartFiring(AttackType.CircleFire02);

        Vector3 direction = Vector3.right;
        movement2D.MoveTo(direction);
        while (true)
        {
            if (transform.position.x <= 9 || transform.position.x >= -9)
            {
                animator.SetBool("isRun", false);   //애니메이션
                direction *= -1;
                movement2D.MoveTo(direction);
            }
            yield return null;
        }
    }

    public void Ondie()
    {
        // ���� �ı� ��ƼŬ ����
        Instantiate(bossDie, transform.position, Quaternion.identity);
        // ���� ������Ʈ ����;
        Destroy(gameObject);
    }

}
