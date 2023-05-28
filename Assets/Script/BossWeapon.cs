using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType {  CircleFire = 0, }

public class BossWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;  // ������ �� �����Ǵ� �߻�ü ������

    public void StartFiring(AttackType attackType)
    {
        // attackType �������� �̸��� ���� �ڷ�ƾ�� ����
        StartCoroutine(attackType.ToString());
    }

    public void StopFiring(AttackType attackType)
    {
        // attackType �������� �̸��� ���� �ڷ�ƾ�� ����
        StopCoroutine(attackType.ToString());   
    }

    private IEnumerator CircleFire()
    {
        float attackRate = 0.5f;                 // ���� �ֱ�
        int count = 30;                              // �߻�ü ���� ����
        float intervalAngle = 360 / count;  // �߻�ü ������ ����
        float weightAngle = 0;                   // ���ߵǴ� ���� (�׻� ���� ��ġ�� �߻����� �ʵ��� ����)

        // �� ���·� ����ϴ� �߻�ü ����(count ���� ��ŭ)
        while(true)
        {
            for(int i = 0; i < count; i++)
            {
                // �߻�ü ����
                GameObject clone = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                // �߻�ü �̵�����(����)
                float angle = weightAngle * i * intervalAngle;
                // �߻�ü �̵� ����(����)
                float x = Mathf.Cos(angle * Mathf.PI / 180.0f); // cos(����), ���� ������ ���� ǥ���� ���� PI / 180�� ����
                float y = Mathf.Sin(angle * Mathf.PI / 180.0f);
                // �߻�ü �̵����� ����
                clone.GetComponent<Movement2D>().MoveTo(new Vector2(x, y));
            }

            // �߻�ü�� �����Ǵ� ���� ���� ������ ���� ����
            weightAngle += 1;

            // attackRate �ð���ŭ ���
            yield return  new WaitForSeconds(attackRate);
        }
    }
}