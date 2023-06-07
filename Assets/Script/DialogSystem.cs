using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Net.Http.Headers;

public class DialogSystem : MonoBehaviour
{
    [SerializeField]
    private Speaker[] speakers;                     //캐릭터들 UI배열
    [SerializeField]                                
    private DialogData[] dialogs;                   //대사 목록 배열
    [SerializeField]
    private bool isAutoStart = true;                //자동시작 여부
    private bool isFirst = true;                    //1회만 호출 
    private int currentDialogIndex = -1;            //현재 대사 순번
    private int currnetSpearkerIndex = 0;           //말하는 화자의 speakers 순번 

    private void Awake()
    {
        Setup();
    }

    public void Setup()
    {
        //모든 대화관련 게임오브젝트 비활
        for(int i =0; i<speakers.Length;++i)
        {
            SetActiveObjects(speakers[i], false);
            //캐릭터 이미지는 보이도록 설정
            speakers[i].spriteRenderer.gameObject.SetActive(true);
        }
    }

    public bool UpdateDialog()
    {
        //대사 분기가 시작될떄 1회만 호출 
        if (isFirst == true)
        {
            //초기화. 캐릭터 이미지는 활성화하고, 대사 관련 UI는 모두 비활
            Setup();

            //자동재생 (isAutoStart==true)로 설정되어 있으면 첫번째 대사 재생
            if (isAutoStart) SetNextDialog();
            isFirst = false;
        }

        if(Input.GetMouseButtonDown(0))
        {
            //대사가 남아있을경우 다음 대사 재생 
            if(dialogs.Length > currentDialogIndex +1 )
            {
                SetNextDialog();
            }
            else
            {
                for(int i=0; i < speakers.Length; ++ i)
                {
                    SetActiveObjects(speakers[i], false);
                    speakers[i].spriteRenderer.gameObject.SetActive(true);
                }
                return true;
            }
        }
        return false;
    }
   private void SetNextDialog()
    {
        SetActiveObjects(speakers[currnetSpearkerIndex], false);

        currentDialogIndex ++;

        currnetSpearkerIndex = dialogs[currentDialogIndex].speakerIndex;

        SetActiveObjects(speakers[currnetSpearkerIndex], true);

        speakers[currnetSpearkerIndex].TextName.text = dialogs[currentDialogIndex].name;

        speakers[currnetSpearkerIndex].TextDaiolg.text = dialogs[currentDialogIndex].dialogue;
    }
    private void SetActiveObjects(Speaker speaker,bool visible)
    {
        speaker.panelplayer.gameObject.SetActive(visible);
        speaker.TextName.gameObject.SetActive(visible);
        speaker.TextDaiolg.gameObject.SetActive(visible);

        speaker.TextSkip.gameObject.SetActive(false);

        Color color = speaker.spriteRenderer.color;
        color.a = visible == true ? 1 : 0.2f;
        speaker.spriteRenderer.color = color;
    }
}

[System.Serializable]
public struct Speaker
{
    public GameObject panelplayer; 
    public SpriteRenderer spriteRenderer; //캐릭터 이미지 

    public Text TextDaiolg; //대화
    public Text TextName; //캐릭터 이름
    public Text TextSkip; //skip

}
[System.Serializable]
public struct DialogData
{
    public int speakerIndex; // 대사출력할 순번 (즉 캐릭터 )
    public string name; //이름
    [TextArea(3, 5)]
    public string dialogue; //대사 
}