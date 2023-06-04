using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePaused : MonoBehaviour
{
    bool pauseActive = false;
    public GameObject AllBulrCam;
    // Start is called before the first frame update
    
    public void PauseButton(){
        if(pauseActive){
            Time.timeScale = 1; //일시정지 해제
            pauseActive = false;
            AllBulrCam.SetActive(false);
        }
        else{
            Time.timeScale = 0; //일시정지
            pauseActive = true;
            AllBulrCam.SetActive(true);
        }
    }
}
