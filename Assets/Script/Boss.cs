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
        // 이전에 재생중이던 상태 종료
        StopCoroutine(bossState.ToString());
        // 상태 변경
        bossState = newState;
        // 새로운 상태 재생
        StartCoroutine(bossState.ToString());
    }

    private IEnumerator MoveToAppearpoint()
    {
        // 이동방향 설정[코루틴 실행 시 1회 호출]
        movement2D.MoveTo(Vector3.down);

        while (true)
        {
            if(transform.position.y <= bossAppearPoint )
            {
                // 이동방향을 (0, 0, 0)으로 설정해 멈추도록 한다.
                movement2D.MoveTo(Vector3.zero);
                // Phase01 상태로 변경
                ChangeState(BossState.Phase01);
            }
            yield return null;
        }
    }

    private IEnumerator Phase01()
    {
        // 원 형태의 방사 공격 시작
        bossWeapon.StartFiring(AttackType.CircleFire);

        while (true)
        {
            yield return null;
        }
    }

    public void Ondie()
    {
        // 보스 파괴 파티클 생성
        Instantiate(bossDie, transform.position, Quaternion.identity);
        // 보스 오브젝트 삭제;
        Destroy(gameObject);
    }

}
