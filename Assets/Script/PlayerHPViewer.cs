using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPViewer : MonoBehaviour
{
    [SerializeField]
    private PlayerHp playerHP;
    private Slider sliderHP;

    private void Awake()
    {
        sliderHP = GetComponent<Slider>();
    }

    private void Update()
    {
        // Slider UI�� ���� ü�� ������ ������Ʈ
        sliderHP.value = playerHP.CurrentHP / playerHP.MaxHP;
    }
}
