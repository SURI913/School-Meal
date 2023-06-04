using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType {  CircleFire = 0, CircleFire02=1, CircleFire03 }

public class BossWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;  // 공격할 때 생성되는 발사체 프래팹

    public void StartFiring(AttackType attackType)
    {
        // attackType 열거형의 이름과 같은 코루틴을 실행
        StartCoroutine(attackType.ToString());
    }

    public void StopFiring(AttackType attackType)
    {
        // attackType 열거형의 이름과 같은 코루틴을 중지
        StopCoroutine(attackType.ToString());
    }

    private IEnumerator CircleFire()
    {
        Debug.Log("1페이즈 시작");
        float attackRate = 1.5f;                 // 공격 주기
        int count = 10;                              // 발사체 생성 개수
        float intervalAngle = 360 / count;  // 발사체 사이의 각도
        float weightAngle = 0;                   // 가중되는 각도 (항상 같은 위치로 발사하지 않도록 설정)

        // 원 형태로 방사하는 발사체 생성(count 갯수 만큼)
        while (true)
        {
            for (int i = 0; i < count; i++)
            {
                // 발사체 생성
                GameObject clone = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                // 발사체 이동방향(각도)
                float angle = weightAngle * i * intervalAngle;
                // 발사체 이동 방향(벡터)
                float x = Mathf.Cos(angle * Mathf.PI / 180.0f); // cos(각도), 라디안 단위의 각도 표현을 위해 PI / 180을 곱함
                float y = Mathf.Sin(angle * Mathf.PI / 180.0f);
                // 발사체 이동방향 설정
                clone.GetComponent<Movement2D>().MoveTo(new Vector2(x, y));
            }

            // 발사체가 생성되는 시작 각도 설정을 위한 변수
            weightAngle += 1;

            // attackRate 시간만큼 대기
            yield return new WaitForSeconds(attackRate);
        }
    }

    private IEnumerator CircleFire02()
    {
        Debug.Log("2페이즈 시작");
        float attackRate = 1.0f;                 // 공격 주기
        int count = 20;                              // 발사체 생성 개수
        float intervalAngle = 360 / count;  // 발사체 사이의 각도
        float weightAngle = 0;                   // 가중되는 각도 (항상 같은 위치로 발사하지 않도록 설정)

        // 원 형태로 방사하는 발사체 생성(count 갯수 만큼)
        while (true)
        {
            for (int i = 0; i < count; i++)
            {
                // 발사체 생성
                GameObject clone = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                // 발사체 이동방향(각도)
                float angle = weightAngle * i * intervalAngle;
                // 발사체 이동 방향(벡터)
                float x = Mathf.Cos(angle * Mathf.PI / 180.0f); // cos(각도), 라디안 단위의 각도 표현을 위해 PI / 180을 곱함
                float y = Mathf.Sin(angle * Mathf.PI / 180.0f);
                // 발사체 이동방향 설정
                clone.GetComponent<Movement2D>().MoveTo(new Vector2(x, y));
            }

            // 발사체가 생성되는 시작 각도 설정을 위한 변수
            weightAngle += 1;

            // attackRate 시간만큼 대기
            yield return new WaitForSeconds(attackRate);
        }
    }

    private IEnumerator CircleFire03()
    {
        Debug.Log("3페이즈 시작");
        float attackRate = 0.5f;                 // 공격 주기
        int count = 25;                              // 발사체 생성 개수
        float intervalAngle = 360 / count;  // 발사체 사이의 각도
        float weightAngle = 0;                   // 가중되는 각도 (항상 같은 위치로 발사하지 않도록 설정)

        // 원 형태로 방사하는 발사체 생성(count 갯수 만큼)
        while (true)
        {
            for (int i = 0; i < count; i++)
            {
                // 발사체 생성
                GameObject clone = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                // 발사체 이동방향(각도)
                float angle = weightAngle * i * intervalAngle;
                // 발사체 이동 방향(벡터)
                float x = Mathf.Cos(angle * Mathf.PI / 180.0f); // cos(각도), 라디안 단위의 각도 표현을 위해 PI / 180을 곱함
                float y = Mathf.Sin(angle * Mathf.PI / 180.0f);
                // 발사체 이동방향 설정
                clone.GetComponent<Movement2D>().MoveTo(new Vector2(x, y));
            }

            // 발사체가 생성되는 시작 각도 설정을 위한 변수
            weightAngle += 1;

            // attackRate 시간만큼 대기
            yield return new WaitForSeconds(attackRate);
        }
    }
}
