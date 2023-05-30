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
        height = Camera.main.orthographicSize;// 세로 반을 orthographicSize 로 구함
        width=height*Screen.width / Screen.height;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;// 카메라 테두리 보이게 색상변경
        Gizmos.DrawWireCube(center,size);
    }
    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime*speed);//현재 위치와 속도로 카메라이동
             
        // transform.position = new Vector3(transform.position.x,0, -10f);  //카메라값 y축 0으로 고정,z축-10 으로 고정 좌우로만 카메라 이동 
        //카메라가 맵을 벗어나지 않게  
       // Mathf.Clamp(value, min, max) value값이 min과max 사이면 value 반환
        //min보다 작으면 min, max보다 크면 max 반환
        float lx = size.x * 0.5f - width;
        float clampX = Mathf.Clamp(transform.position.x, -lx + center.x, lx + center.x);

        //float ly = size.y * 0.5f - height;
        //float clampY = Mathf.Clamp(transform.position.y, -ly + center.y, ly + center.y);

        transform.position = new Vector3(clampX,0, -10f);//카메라 z축 고정 

    }
}
