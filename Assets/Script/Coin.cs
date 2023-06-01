using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Coin : MonoBehaviour
{
    public double CoinAmount;
    private void OnCollisionEnter2D(Collision2D collision)
    {

        CoinAmount = GameManager.instance.GetCoin();

        if(collision.gameObject.name=="Coin")
        {
            GameManager.instance.Coin += 10;
            Destroy(gameObject);
        }
        else if(collision.gameObject.name == "Coin1")
        {
            GameManager.instance.Coin += 12;
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame[
    void Update()
    {
        
    }
}
