using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState {  MoveToAppearpoint = 0, Phase01, }

public class Boss : MonoBehaviour
{
    [SerializeField]
    private GameObject bossDie;
    [SerializeField]
    private float bossAppearPoint = 0;
    private BossState bossState;
    private Movement2D movement2D;
    private BossWeapon bossWeapon;

    private void Awake()
    {
        movement2D = GetComponent<Movement2D>();
        bossWeapon = GetComponent<BossWeapon>();
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
        // �̵����� ����[�ڷ�ƾ ���� �� 1ȸ ȣ��]
        movement2D.MoveTo(Vector3.down);

        while (true)
        {
            if(transform.position.y <= bossAppearPoint )
            {
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
        // �� ������ ��� ���� ����
        bossWeapon.StartFiring(AttackType.CircleFire);

        while (true)
        {
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
