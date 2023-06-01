using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform target;
    public float speed;
    public Vector2 center;
    public Vector2 size;
    float height;
    float width;
    void Start()
    {
        height = Camera.main.orthographicSize;// ���� ���� orthographicSize �� ����
        width=height*Screen.width / Screen.height;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;// ī�޶� �׵θ� ���̰� ���󺯰�
        Gizmos.DrawWireCube(center,size);
    }
    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime*speed);//���� ��ġ�� �ӵ��� ī�޶��̵�
             
        // transform.position = new Vector3(transform.position.x,0, -10f);  //ī�޶� y�� 0���� ����,z��-10 ���� ���� �¿�θ� ī�޶� �̵� 
        //ī�޶� ���� ����� �ʰ�  
       // Mathf.Clamp(value, min, max) value���� min��max ���̸� value ��ȯ
        //min���� ������ min, max���� ũ�� max ��ȯ
        float lx = size.x * 0.5f - width;
        float clampX = Mathf.Clamp(transform.position.x, -lx + center.x, lx + center.x);

        //float ly = size.y * 0.5f - height;
        //float clampY = Mathf.Clamp(transform.position.y, -ly + center.y, ly + center.y);

        transform.position = new Vector3(clampX,0, -10f);//ī�޶� z�� ���� 

    }
}