using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] 
    private GameObject enemyPrefab;         // 복제해서 생성할 적 캐릭터 프리팹
    [SerializeField]
    private Transform canvasTransform;          // UI를 표현하는 Canvas 오브젝트의 Transform
    [SerializeField]
    private GameObject boss;                         // 보스 오브젝트
    [SerializeField]
    private float spawnTime;                           // 생성 주기
    [SerializeField]
    private int maxEnemyCount = 5;              // 현재 스테이지의 최재 적 생성 숫자

    private void Awake()
    {
        boss.SetActive(false);

        StartCoroutine("SpawnEnemy");

        
    }

    

    private IEnumerator SpawnEnemy()
    {
        int currentEnemyCount = 0;

        while (true)
        {
            // x 위치는 스테이지의 크기 범위 내에서 임의의 값을 선택
            float positionX = Random.Range(-9, 9);
            // 적 생성 위치
            Vector3 position = new Vector3(positionX, -4.0f, 0.0f);
            // 적 캐릭터 생성
            GameObject enemyClone = Instantiate(enemyPrefab, position, Quaternion.identity);
            //Instantiate(enemyPrefab, new Vector3(positionX, stageData.LimitMax.y+1, 0.0f),Quaternion.identity);

            
            // 적 생성 숫자 증가
            currentEnemyCount++;
            // 적을 최대 숫자까지 생성하면 적 생성 코루틴 중지, 보스 생성 코루틴 실행
            if(currentEnemyCount == maxEnemyCount)
            {
                StartCoroutine("SpawnBoss");
                break;
            }

            // spawnTime 만큼 대기
            yield return new WaitForSeconds(spawnTime);
        }
    }

    private IEnumerator SpawnBoss()
    {
        yield return new WaitForSeconds(1.0f);
        boss.SetActive(true);
        boss.GetComponent<Boss>().ChangeState(BossState.MoveToAppearpoint);
    }
}
