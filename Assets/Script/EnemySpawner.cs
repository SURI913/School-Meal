using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] 
    private GameObject enemyPrefab;         // �����ؼ� ������ �� ĳ���� ������
    [SerializeField]
    private Transform canvasTransform;          // UI�� ǥ���ϴ� Canvas ������Ʈ�� Transform
    [SerializeField]
    private GameObject boss;                         // ���� ������Ʈ
    [SerializeField]
    private float spawnTime;                           // ���� �ֱ�
    [SerializeField]
    private int maxEnemyCount = 5;              // ���� ���������� ���� �� ���� ����

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
            // x ��ġ�� ���������� ũ�� ���� ������ ������ ���� ����
            float positionX = Random.Range(-9, 9);
            // �� ���� ��ġ
            Vector3 position = new Vector3(positionX, -4.0f, 0.0f);
            // �� ĳ���� ����
            GameObject enemyClone = Instantiate(enemyPrefab, position, Quaternion.identity);
            //Instantiate(enemyPrefab, new Vector3(positionX, stageData.LimitMax.y+1, 0.0f),Quaternion.identity);

            
            // �� ���� ���� ����
            currentEnemyCount++;
            // ���� �ִ� ���ڱ��� �����ϸ� �� ���� �ڷ�ƾ ����, ���� ���� �ڷ�ƾ ����
            if(currentEnemyCount == maxEnemyCount)
            {
                StartCoroutine("SpawnBoss");
                break;
            }

            // spawnTime ��ŭ ���
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
