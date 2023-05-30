using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private static DontDestroy s_Instance = null;
    // Start is called before the first frame update
    void Awake()
    {
        if(s_Instance){
            DestroyImmediate(this.gameObject);
            return;
        }
        s_Instance = this;
        DontDestroyOnLoad(this.gameObject);
        
    }
}
