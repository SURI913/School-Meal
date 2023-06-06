using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "1-1" && Input.GetKeyDown(KeyCode.Space)){
            PlayerData.BackStageTag = PlayerData.CurrentStageTag;
            if(PlayerData.S1_1Clear == true){
                SceneManager.LoadScene("1-1Clear");
                PlayerData.CurrentStageTag = other.tag;
            }
            else{
                SceneManager.LoadScene(other.tag);
                PlayerData.CurrentStageTag = other.tag;
            }  
        }
        else if(other.tag == "1-2" && Input.GetKeyDown(KeyCode.Space)){
            PlayerData.BackStageTag = PlayerData.CurrentStageTag;
            if(PlayerData.S1_2Clear == true){
                SceneManager.LoadScene("1-2Clear");
                PlayerData.CurrentStageTag = other.tag;
            }
            else{
                SceneManager.LoadScene(other.tag);
                PlayerData.CurrentStageTag = other.tag;
            }

        }
        else if(other.tag == "1-3" && Input.GetKeyDown(KeyCode.Space)){
            PlayerData.BackStageTag = PlayerData.CurrentStageTag;
            if(PlayerData.S1_3Clear == true){
                SceneManager.LoadScene("1-3Clear");
                PlayerData.CurrentStageTag = other.tag;
            }
            else{
                SceneManager.LoadScene(other.tag);
                PlayerData.CurrentStageTag = other.tag;
            }

        }
        else if(other.tag == "2-1" && Input.GetKeyDown(KeyCode.Space)){
            PlayerData.BackStageTag = PlayerData.CurrentStageTag;
            if(PlayerData.S2_1Clear == true){
                SceneManager.LoadScene("2-1Clear");
                PlayerData.CurrentStageTag = other.tag;
            }
            else{
                SceneManager.LoadScene(other.tag);
                PlayerData.CurrentStageTag = other.tag;
            }
            
        }
        else if(other.tag == "2-2" && Input.GetKeyDown(KeyCode.Space)){
            PlayerData.BackStageTag = PlayerData.CurrentStageTag;
            if(PlayerData.S2_2Clear == true){
                SceneManager.LoadScene("2-2Clear");
                PlayerData.CurrentStageTag = other.tag;
            }
            else{
                SceneManager.LoadScene(other.tag);
                PlayerData.CurrentStageTag = other.tag;
            }
            
        }
        else if(other.tag == "2-3" && Input.GetKeyDown(KeyCode.Space)){
            PlayerData.BackStageTag = PlayerData.CurrentStageTag;
            if(PlayerData.S2_3Clear == true){
                SceneManager.LoadScene("2-3Clear");
                PlayerData.CurrentStageTag = other.tag;
            }
            else{
                SceneManager.LoadScene(other.tag);
                PlayerData.CurrentStageTag = other.tag;
            }
            
        }
        else if(other.tag == "Cafeteria" && Input.GetKeyDown(KeyCode.Space)){
            PlayerData.BackStageTag = PlayerData.CurrentStageTag;
            if(PlayerData.MidBossClear == true){
                SceneManager.LoadScene("CafeteriaClear");
                PlayerData.CurrentStageTag = other.tag;
            }
            else{
                SceneManager.LoadScene(other.tag);
                PlayerData.CurrentStageTag = other.tag;
            }
            
        }
        else if(other.tag == "3-1" && Input.GetKeyDown(KeyCode.Space)){
            PlayerData.BackStageTag = PlayerData.CurrentStageTag;
            if(PlayerData.S3_1Clear ==true){
                SceneManager.LoadScene("3-1Clear");
                PlayerData.CurrentStageTag = other.tag;
            }
            else{
                SceneManager.LoadScene(other.tag);
                PlayerData.CurrentStageTag = other.tag;
            }
            
        }
        else if(other.tag == "3-2" && Input.GetKeyDown(KeyCode.Space)){
            PlayerData.BackStageTag = PlayerData.CurrentStageTag;
            if(PlayerData.S3_2Clear ==true){
                SceneManager.LoadScene("3-2Clear");
                PlayerData.CurrentStageTag = other.tag;
            }
            else{
                SceneManager.LoadScene(other.tag);
                PlayerData.CurrentStageTag = other.tag;
            }
            
        }
        
        else if(other.tag == "4-1" && Input.GetKeyDown(KeyCode.Space)){
            PlayerData.BackStageTag = PlayerData.CurrentStageTag;
            if(PlayerData.S4_1Clear ==true){
                SceneManager.LoadScene("4-1Clear");
                PlayerData.CurrentStageTag = other.tag;
            }
            else{
                SceneManager.LoadScene(other.tag);
                PlayerData.CurrentStageTag = other.tag;
            }
            
        }
        else if(other.tag == "4-2" && Input.GetKeyDown(KeyCode.Space)){
            PlayerData.BackStageTag = PlayerData.CurrentStageTag;
            if(PlayerData.S4_2Clear ==true){
                SceneManager.LoadScene("4-2Clear");
                PlayerData.CurrentStageTag = other.tag;
            }
            else{
                SceneManager.LoadScene(other.tag);
                PlayerData.CurrentStageTag = other.tag;
            }
            
        }
        else if(other.tag == "4-3" && Input.GetKeyDown(KeyCode.Space)){
            PlayerData.BackStageTag = PlayerData.CurrentStageTag;
            if(PlayerData.S4_3Clear ==true){
                SceneManager.LoadScene("4-3Clear");
                PlayerData.CurrentStageTag = other.tag;
            }
            else{
                SceneManager.LoadScene(other.tag);
                PlayerData.CurrentStageTag = other.tag;
            }
            
        }
        
        else if(other.tag == "Office" && Input.GetKeyDown(KeyCode.Space)){
            PlayerData.BackStageTag = PlayerData.CurrentStageTag;
            SceneManager.LoadScene(other.tag);
            PlayerData.CurrentStageTag = other.tag;
            
        }
        else if(other.tag == "Shop1" && Input.GetKeyDown(KeyCode.Space)){ //정비스테이지
            PlayerData.BackStageTag = PlayerData.CurrentStageTag;
            SceneManager.LoadScene(other.tag);
            PlayerData.CurrentStageTag = other.tag;
            
        }
        else if(other.tag == "Shop2" && Input.GetKeyDown(KeyCode.Space)){ //정비스테이지
            PlayerData.BackStageTag = PlayerData.CurrentStageTag;
            SceneManager.LoadScene(other.tag);
            PlayerData.CurrentStageTag = other.tag;
            
        }
    }
}
