using UnityEngine;

[RequireComponent(typeof(DialogSystem))]
public class TutorialDialog : TutorialBase
{
	// 캐릭터들의 대사를 진행하는 DialogSystem
	private	DialogSystem dialogSystem;

	//잠깐 꺼두는 상점 오브젝트
	[SerializeField]
	private GameObject shopItem1 = null;
	[SerializeField]
	private GameObject shopItem2 = null;
	[SerializeField]
	private GameObject shopItem3 = null;
	[SerializeField]
	private GameObject shopItem4 = null;

	public override void Enter()
	{
		dialogSystem = GetComponent<DialogSystem>();
		dialogSystem.Setup(); //이거 이미 있네 아무튼 세팅
	}

	public override void Execute(TutorialController controller)
	{
		// 현재 분기에 진행되는 대사 진행
		bool isCompleted = dialogSystem.UpdateDialog();
		if(shopItem1 != null && shopItem2 != null && shopItem3 != null && shopItem4 != null){
			shopItem1.SetActive(false);
			shopItem2.SetActive(false);
			shopItem3.SetActive(false);
			shopItem4.SetActive(false);
		}

		// 현재 분기의 대사 진행이 완료되면
		if ( isCompleted == true )
		{
			if(shopItem1 != null && shopItem2 != null && shopItem3 != null && shopItem4 != null){
				shopItem1.SetActive(true);
				shopItem2.SetActive(true);
				shopItem3.SetActive(true);
				shopItem4.SetActive(true);
			}
			// 다음 튜토리얼로 이동
			controller.SetNextTutorial();
		}
	}

	public override void Exit()
	{
	}
}

