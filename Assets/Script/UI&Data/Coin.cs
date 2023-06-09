using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Coin : MonoBehaviour
{
    private int CoinAmount;
    public int min=0;
    public int max=0;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //공간안에 있는게 플레이어라면
            if (Input.GetKeyDown(KeyCode.G))
            {
                RandomAmountCoin();

            
                //G키를 눌렀을 때
                GameManager.instance.SetCoin(CoinAmount);
                GameManager.instance.HitCountCheck(1);
                //게임매니저에 코인값을 보낸다.
                Debug.Log("코인 먹었다.");
                Destroy(gameObject);
            }
        }
    }
    
    private void RandomAmountCoin()
    {
        CoinAmount = Random.Range(min, max);
    }
}
