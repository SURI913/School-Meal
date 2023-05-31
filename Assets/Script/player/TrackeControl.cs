using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class TrackeControl : MonoBehaviour
{
    
    public bool follow = false;

    private PlayerController player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player"){
            follow = true;
            player.SetFollow(follow);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player"){
            follow = false;
            player.SetFollow(follow);
        }
    }
 
}
