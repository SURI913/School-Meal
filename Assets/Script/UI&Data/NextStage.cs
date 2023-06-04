using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "1-1" && Input.GetKeyDown(KeyCode.Space.ToString())){
            SceneManager.LoadScene(other.tag);
            PlayerData.StageNum1=1;
            PlayerData.StageNum2=1;
        }
        else if(other.tag == "1-2" && Input.GetKeyDown(KeyCode.Space.ToString())){
            SceneManager.LoadScene(other.tag);
            PlayerData.StageNum1=1;
            PlayerData.StageNum2=2;
        }
        else if(other.tag == "1-3" && Input.GetKeyDown(KeyCode.Space.ToString())){
            SceneManager.LoadScene(other.tag);
            PlayerData.StageNum1=1;
            PlayerData.StageNum2=3;
        }
        else if(other.tag == "1-4" && Input.GetKeyDown(KeyCode.Space.ToString())){
            SceneManager.LoadScene(other.tag);
            PlayerData.StageNum1=1;
            PlayerData.StageNum2=4;
        }
        else if(other.tag == "2-1" && Input.GetKeyDown(KeyCode.Space.ToString())){
            SceneManager.LoadScene(other.tag);
            PlayerData.StageNum1=2;
            PlayerData.StageNum2=1;
        }
        else if(other.tag == "2-2" && Input.GetKeyDown(KeyCode.Space.ToString())){
            SceneManager.LoadScene(other.tag);
            PlayerData.StageNum1=2;
            PlayerData.StageNum2=2;
        }
        else if(other.tag == "2-3" && Input.GetKeyDown(KeyCode.Space.ToString())){
            SceneManager.LoadScene(other.tag);
            PlayerData.StageNum1=2;
            PlayerData.StageNum2=3;
        }
        else if(other.tag == "Cafeteria" && Input.GetKeyDown(KeyCode.Space.ToString())){
            SceneManager.LoadScene(other.tag);
            PlayerData.StageNum1=9;
            PlayerData.StageNum2=9;
        }
        else if(other.tag == "3-1" && Input.GetKeyDown(KeyCode.Space.ToString())){
            SceneManager.LoadScene(other.tag);
            PlayerData.StageNum1=3;
            PlayerData.StageNum2=1;
        }
        else if(other.tag == "3-2" && Input.GetKeyDown(KeyCode.Space.ToString())){
            SceneManager.LoadScene(other.tag);
            PlayerData.StageNum1=3;
            PlayerData.StageNum2=2;
        }
        else if(other.tag == "3-3" && Input.GetKeyDown(KeyCode.Space.ToString())){
            SceneManager.LoadScene(other.tag);
            PlayerData.StageNum1=3;
            PlayerData.StageNum2=3;
        }
        else if(other.tag == "4-1" && Input.GetKeyDown(KeyCode.Space.ToString())){
            SceneManager.LoadScene(other.tag);
            PlayerData.StageNum1=4;
            PlayerData.StageNum2=1;
        }
        else if(other.tag == "4-2" && Input.GetKeyDown(KeyCode.Space.ToString())){
            SceneManager.LoadScene(other.tag);
            PlayerData.StageNum1=4;
            PlayerData.StageNum2=2;
        }
        else if(other.tag == "4-3" && Input.GetKeyDown(KeyCode.Space.ToString())){
            SceneManager.LoadScene(other.tag);
            PlayerData.StageNum1=4;
            PlayerData.StageNum2=3;
        }
        else if(other.tag == "5-1" && Input.GetKeyDown(KeyCode.Space.ToString())){
            SceneManager.LoadScene(other.tag);
            PlayerData.StageNum1=5;
            PlayerData.StageNum2=1;
        }
        else if(other.tag == "5-2" && Input.GetKeyDown(KeyCode.Space.ToString())){
            SceneManager.LoadScene(other.tag);
            PlayerData.StageNum1=5;
            PlayerData.StageNum2=2;
        }
        else if(other.tag == "5-3" && Input.GetKeyDown(KeyCode.Space.ToString())){
            SceneManager.LoadScene(other.tag);
            PlayerData.StageNum1=5;
            PlayerData.StageNum2=3;
        }
        else if(other.tag == "Office" && Input.GetKeyDown(KeyCode.Space.ToString())){
            SceneManager.LoadScene(other.tag);
            PlayerData.StageNum1=0;
            PlayerData.StageNum2=0;
        }
        else if(other.tag == "Shop" && Input.GetKeyDown(KeyCode.Space.ToString())){ //정비스테이지
            SceneManager.LoadScene(other.tag);
            PlayerData.StageNum1=11;
            PlayerData.StageNum2=11;
        }
        else if(other.tag == "CoinEvent" && Input.GetKeyDown(KeyCode.Space.ToString())){ //정비스테이지
            SceneManager.LoadScene(other.tag);
            PlayerData.StageNum1=22;
            PlayerData.StageNum2=22;
        }
    }
}
