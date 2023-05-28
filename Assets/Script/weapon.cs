using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float attackRate = 0.1f;

    public void StartFiring()
    {
        StartCoroutine("TryAttack");
    }
    public void StopFiring()
    {
        StopCoroutine("TryAttack");
    }
    private IEnumerator TryAttack()
    {
        while (true)
        {
            //�߻�ü ����
            Instantiate(bullet, transform.position, Quaternion.identity);

            //attackRate �ð���ŭ ���
            yield return new WaitForSeconds(attackRate);
        }
    }
}
