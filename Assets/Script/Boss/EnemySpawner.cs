using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject boss;                         // 보스 오브젝트

    private void Awake()
    {
        StartCoroutine("SpawnBoss");
    }

    private IEnumerator SpawnBoss()
    {
        yield return new WaitForSeconds(1.0f);
        boss.SetActive(true);
        boss.GetComponent<Boss>().ChangeState(BossState.MoveToAppearpoint);
    }
}
