using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform target;
    public float speed=3;
    public Vector2 center;
    public Vector2 size;
    float height;
    float width;

    Vector3 NonTagetTransform = new Vector3(0,0,0);
    void Start()
    {
        height = Camera.main.orthographicSize;//세로의 절반크기를 orthographicSize로 얻음 
        width = height * Screen.width / Screen.height;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;// 카메라 테두리 확인을 위해 노란색으로 표시 
        Gizmos.DrawWireCube(center, size);
    }
    // Update is called once per frame
    private void LateUpdate()
    {
        float lx;
        float clampX;
        if (target != null)
        {  
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);//플레이어 위치를 받옴 
            lx = size.x * 0.5f - width;
            clampX = Mathf.Clamp(transform.position.x, -lx + center.x, lx + center.x);

            transform.position = new Vector3(clampX, 0, -10f);
        }
        else
        {

            transform.position = Vector3.Lerp(transform.position, NonTagetTransform, Time.deltaTime * speed);
            //마지막에 있던 타겟의 위치값 저장해둔거를 고정해서 사용하도록 수정부탁드려요
        }
        
        //y위치인데 이건 고정 
        //float lx = size.x * 0.5f - width;
        //float clampX = Mathf.Clamp(transform.position.x, -lx + center.x, lx + center.x);

        //transform.position = new Vector3(clampX,0, -10f);//ī ޶  z        

    }
}
