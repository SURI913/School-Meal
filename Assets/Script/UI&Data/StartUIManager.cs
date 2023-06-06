using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartUIManager : MonoBehaviour
{
    public AudioSource Button;
    public void PlayButtonSound(){
        Button.Play();
    }

    //Start버튼 클릭 시 GameScene으로 이동.
    public void GoGameScene(){
        SceneManager.LoadScene("1-1");
    }

    //Tutorial버튼 클릭 시 TutorialScene으로 이동.
    public void GoTutorialScene(){
        //SceneManager.LoadScene("Tutorial");
    }
}
