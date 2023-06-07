using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTrigger : TutorialBase
{
    [SerializeField]
	private	TargetControll	playerController;
    
	[SerializeField]
	private	Transform	triggerObject;

    [SerializeField]
	private	Text Cointext = null;
	
	public	bool isTrigger { set; get; } = false;
	private bool isSetting = false;

	public override void Enter()
	{
		// 플레이어 이동 가능
		playerController.IsMoved = true;
		// Trigger 오브젝트 활성화
		triggerObject.gameObject.SetActive(true);
	}

	public override void Execute(TutorialController controller)
	{
		/// 충돌 기준
		// TutorialTrigger 오브젝트의 위치를 플레이어와 동일하게 설정 (Trigger 오브젝트와 충돌할 수 있도록)
		transform.position = playerController.transform.position;
        if ( isTrigger == true && triggerObject.CompareTag("TutorialShop") && Input.GetKeyDown(KeyCode.Space))
		{
			controller.SetNextTutorial();
		}
        else if ( isTrigger == true && triggerObject.CompareTag("CoinEvent") && Input.GetKeyDown(KeyCode.G))
		{
            //코인텍스트 값 전달 해줄거임
            if(Cointext != null){
                Cointext.text = "15";
				isSetting = true;
            }
            //이거는 게임매니저에 전달 x
			controller.SetNextTutorial();
		}
		else if ( isTrigger == true && triggerObject.CompareTag("TutorialBox")){
			controller.SetNextTutorial();
		}
	}

	public override void Exit()
	{
		// 플레이어 이동 불가능
		playerController.IsMoved = false;
		// Trigger 오브젝트 비활성화
		triggerObject.gameObject.SetActive(false);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if ( collision.transform.Equals(triggerObject) )
		{
			isTrigger = true;

			if(triggerObject.CompareTag("TutorialShop")){
				collision.gameObject.SetActive(true);
			}
			else if(triggerObject.CompareTag("CoinEvent") && isSetting ==true){
				collision.gameObject.SetActive(false);
			}
			else if(triggerObject.CompareTag("TutorialBox")){
				collision.gameObject.SetActive(false);
			}
		}
	}
}
