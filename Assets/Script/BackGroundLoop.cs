using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    // Start is called before the first frame update
    private float width;

    private void Awake() {
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;  //박스콜라이더의 사이즈.x값 사용을 위한 초기화
    }
    
    // Update is called once per frame
    void Update()
    {
        //현재 위치가 원점에서 원점으로 width 이상 이동했을 때 위치를 재배치
        if(transform.position.x <= -width){
            Reposition();
        }
        
    }
    private void Reposition(){
        //현재 위치에서 오른쪽으로 가로 길이 *2 만큼 이동
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}
