using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isPushKey = false;
    private void OnTriggerStay2D(Collider2D other) {

        if(other.gameObject.name == "BackDoor" && Input.GetKeyDown(KeyCode.Space) && isPushKey ==false){
            isPushKey = true;
            PlayerData.StageRoute.Pop();
            GameManager.instance.BackDoor.tag = PlayerData.StageRoute.Peek();
            GameManager.instance.ResetHitCount();
            GameManager.instance.StageNumberTag = other.tag;
            PlayerData.currnetStage = other.tag;
            Debug.Log(PlayerData.StageRoute.Peek());

            //백도어는 모두 클리어씬
            if(GameManager.instance.BackDoor.tag == "1-1"){
                SceneManager.LoadScene("1-1Clear");
            }
            if(GameManager.instance.BackDoor.tag == "1-2"){
                SceneManager.LoadScene("1-2Clear");
            }
            if(GameManager.instance.BackDoor.tag == "1-3"){
                SceneManager.LoadScene("1-3Clear");
            }
            if(GameManager.instance.BackDoor.tag == "2-1"){
                SceneManager.LoadScene("2-1Clear");
            }
            if(GameManager.instance.BackDoor.tag == "2-2"){
                SceneManager.LoadScene("2-2Clear");
            }
            if(GameManager.instance.BackDoor.tag == "2-3"){
                SceneManager.LoadScene("2-3Clear");
            }
            if(GameManager.instance.BackDoor.tag == "3-1"){
                SceneManager.LoadScene("3-1Clear");
            }
            if(GameManager.instance.BackDoor.tag == "3-2"){
                SceneManager.LoadScene("3-2Clear");
            }
            if(GameManager.instance.BackDoor.tag == "4-1"){
                SceneManager.LoadScene("4-1Clear");
            }
            if(GameManager.instance.BackDoor.tag == "4-2"){
                SceneManager.LoadScene("4-2Clear");
            }
            if(GameManager.instance.BackDoor.tag == "4-3"){
                SceneManager.LoadScene("4-3Clear");
            }
            if(GameManager.instance.BackDoor.tag == "Cafeteria"){
                SceneManager.LoadScene("CafeteriaClear");
            }

        }

        else{
            //백도어가 아닐  
            if(other.tag == "1-1" && Input.GetKeyDown(KeyCode.Space) && isPushKey ==false){
                isPushKey = true;

                PlayerData.currnetStage = other.tag;
                PlayerData.StageRoute.Push(other.tag);
                GameManager.instance.StageNumberTag = other.tag;
                
                GameManager.instance.ResetHitCount();
                if(PlayerData.S1_1Clear == true){
                    SceneManager.LoadScene("1-1Clear");
                }
                else{
                    SceneManager.LoadScene(other.tag);
                }
            }
            else if(other.tag == "1-2" && Input.GetKeyDown(KeyCode.Space) && isPushKey ==false){
                isPushKey = true;
                PlayerData.currnetStage = other.tag;
                PlayerData.StageRoute.Push(other.tag);
                GameManager.instance.StageNumberTag = other.tag;
                
                GameManager.instance.ResetHitCount();
                if(PlayerData.S1_2Clear == true){
                    SceneManager.LoadScene("1-2Clear");
                }
                else{
                    SceneManager.LoadScene(other.tag);
                }

            }
            else if(other.tag == "1-3" && Input.GetKeyDown(KeyCode.Space) && isPushKey ==false){
                isPushKey = true;
                PlayerData.currnetStage = other.tag;
                PlayerData.StageRoute.Push(other.tag);
                GameManager.instance.StageNumberTag = other.tag;
                
                GameManager.instance.ResetHitCount();

                if(PlayerData.S1_3Clear == true){
                    SceneManager.LoadScene("1-3Clear");
                }
                else{
                    SceneManager.LoadScene(other.tag);
                }

            }
            else if(other.tag == "2-1" && Input.GetKeyDown(KeyCode.Space) && isPushKey ==false){
                isPushKey = true;
                PlayerData.currnetStage = other.tag;
                PlayerData.StageRoute.Push(other.tag);
                GameManager.instance.StageNumberTag = other.tag;
                
                GameManager.instance.ResetHitCount();
                if(PlayerData.S2_1Clear == true){
                    SceneManager.LoadScene("2-1Clear");
                }
                else{
                    SceneManager.LoadScene(other.tag);
                }
                
            }
            else if(other.tag == "2-2" && Input.GetKeyDown(KeyCode.Space) && isPushKey ==false){
                isPushKey = true;
                PlayerData.currnetStage = other.tag;
                PlayerData.StageRoute.Push(other.tag);
                GameManager.instance.StageNumberTag = other.tag;
                
                GameManager.instance.ResetHitCount();
                if(PlayerData.S2_2Clear == true){
                    SceneManager.LoadScene("2-2Clear");
                }
                else{
                    SceneManager.LoadScene(other.tag);
                }
                
            }
            else if(other.tag == "2-3" && Input.GetKeyDown(KeyCode.Space) && isPushKey ==false){
                isPushKey = true;
                PlayerData.currnetStage = other.tag;
                PlayerData.StageRoute.Push(other.tag);
                GameManager.instance.StageNumberTag = other.tag;
                
                GameManager.instance.ResetHitCount();
                if(PlayerData.S2_3Clear == true){
                    SceneManager.LoadScene("2-3Clear");
                }
                else{
                    SceneManager.LoadScene(other.tag);
                }
                
            }
            else if(other.tag == "Cafeteria" && Input.GetKeyDown(KeyCode.Space)&& isPushKey ==false){
                isPushKey = true;
                PlayerData.currnetStage = other.tag;
                PlayerData.StageRoute.Push(other.tag);
                GameManager.instance.StageNumberTag = other.tag;
                
                GameManager.instance.ResetHitCount();
                if(PlayerData.MidBossClear == true){
                    SceneManager.LoadScene("CafeteriaClear");
                }
                else{
                    SceneManager.LoadScene(other.tag);
                }
                
            }
            else if(other.tag == "3-1" && Input.GetKeyDown(KeyCode.Space)&& isPushKey ==false){
                isPushKey = true;
                PlayerData.currnetStage = other.tag;
                PlayerData.StageRoute.Push(other.tag);
                GameManager.instance.StageNumberTag = other.tag;
                GameManager.instance.ResetHitCount();
                if(PlayerData.S2_3Clear == true){
                    SceneManager.LoadScene("3-1Clear");
                }
                else{
                    SceneManager.LoadScene(other.tag);
                }
                
            }
            else if(other.tag == "3-2" && Input.GetKeyDown(KeyCode.Space)&& isPushKey ==false){
                isPushKey = true;
                PlayerData.currnetStage = other.tag;
                PlayerData.StageRoute.Push(other.tag);
                GameManager.instance.StageNumberTag = other.tag;
                GameManager.instance.ResetHitCount();
                if(PlayerData.S3_2Clear == true){
                    SceneManager.LoadScene("3-2Clear");
                }
                else{
                    SceneManager.LoadScene(other.tag);
                }
                
            }
            else if(other.tag == "4-1" && Input.GetKeyDown(KeyCode.Space)&& isPushKey ==false){
                isPushKey = true;
                PlayerData.currnetStage = other.tag;
                PlayerData.StageRoute.Push(other.tag);
                GameManager.instance.StageNumberTag = other.tag;
                GameManager.instance.ResetHitCount();
                if(PlayerData.S4_1Clear == true){
                    SceneManager.LoadScene("4-1Clear");
                }
                else{
                    SceneManager.LoadScene(other.tag);
                }
            }
            else if(other.tag == "4-2" && Input.GetKeyDown(KeyCode.Space)&& isPushKey ==false){
                isPushKey = true;
                PlayerData.currnetStage = other.tag;
                PlayerData.StageRoute.Push(other.tag);
                GameManager.instance.StageNumberTag = other.tag;
                GameManager.instance.ResetHitCount();
                if(PlayerData.S4_2Clear == true){
                    SceneManager.LoadScene("4-2Clear");
                }
                else{
                    SceneManager.LoadScene(other.tag);
                }
            }
            else if(other.tag == "4-3" && Input.GetKeyDown(KeyCode.Space)&& isPushKey ==false){
                isPushKey = true;
                PlayerData.currnetStage = other.tag;
                PlayerData.StageRoute.Push(other.tag);
                GameManager.instance.StageNumberTag = other.tag;
                GameManager.instance.ResetHitCount();
                if(PlayerData.S4_3Clear == true){
                    SceneManager.LoadScene("4-3Clear");
                }
                else{
                    SceneManager.LoadScene(other.tag);
                }
                
            }
            else if(other.tag == "Office" && Input.GetKeyDown(KeyCode.Space)&& isPushKey ==false){
                isPushKey = true;
                PlayerData.StageRoute.Push(other.tag);
                PlayerData.currnetStage = other.tag;
                GameManager.instance.StageNumberTag = other.tag;
                GameManager.instance.ResetHitCount();
                SceneManager.LoadScene(other.tag);
                
            }
            else if(other.tag == "Shop1" && Input.GetKeyDown(KeyCode.Space)&& isPushKey ==false){ //정비스테이지
                isPushKey = true;
                PlayerData.StageRoute.Push(other.tag);
                PlayerData.currnetStage = other.tag;
                GameManager.instance.StageNumberTag = other.tag;
                GameManager.instance.ResetHitCount();
                SceneManager.LoadScene(other.tag);
                
            }
            else if(other.tag == "Shop2" && Input.GetKeyDown(KeyCode.Space)&& isPushKey ==false){ //정비스테이지
                isPushKey = true;
                PlayerData.StageRoute.Push(other.tag);
                PlayerData.currnetStage = other.tag;
                GameManager.instance.StageNumberTag = other.tag;
                GameManager.instance.ResetHitCount();
                SceneManager.LoadScene(other.tag); 
            }

        }
        

        
    }
}
