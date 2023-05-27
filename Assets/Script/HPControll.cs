using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HPControll : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    public void OnSliderEvent(float value){
        text.text = $"HP {value*1}/100";
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
