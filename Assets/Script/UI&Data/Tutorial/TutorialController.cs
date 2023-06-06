using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour
{
    [SerializeField]
    //현재 순차적으로 진행할 튜토리얼들을 담아둠
    private List<TutorialBase> tutorials;
    [SerializeField]
    //다음씬 이름을 저장
    private string nextSceneName = "";

    //현재 진행중인 튜토리얼을 보여줌
    private TutorialBase currentTutorial = null;
    private int currentIndex = -1;
    //현재 진행중인 튜토리얼의 인덱스 저장하거나 현재 행동이 마지막 행동인지 체크

    void Start()
    {
        SetNextTutorial();    //다음 튜토리얼 호출
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTutorial != null){
            //currentTutorial.Execute(this); //익스큐트 메소드 호출
        }
    }

    public void SetNextTutorial(){
        //현재 튜토리얼의 Exit() 메소드 호출
        if(currentTutorial != null){
            currentTutorial.Exit(); //종료
        }

        //마지막 튜토리얼을 진행했다면 CompletedAllTutorials()메소드 호출
        if( currentIndex >= tutorials.Count-1){
            CompletedAllTutorials();
            return; //메소드 종료
        }

        //다음 튜토리얼 과정을 currentTutorial로 등록
        currentIndex++; //튜토리얼 남으면 계속 진행
        currentTutorial = tutorials[currentIndex];
        
        // 새로 바뀐 튜토리얼의 Enter()메소드 호출
        //튜토리얼 시작
        currentTutorial.Enter();
    }

    //모든 튜토리얼 끝냄
    public void CompletedAllTutorials(){
        currentTutorial = null;

        // 행동 양식이 여러 종류가 되었을 때 코드 추가 작성
        // 현재는 씬 전환

        Debug.Log("Complete All");

        if( !nextSceneName.Equals("")){
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
