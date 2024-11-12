using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // HP 바 이미지를 UI로 표시하기 위해 필요

public class HPGuage : MonoBehaviour
{
    public int maxHP = 10;
    private int currentHP;
    public Image hpImage; // HP 바 이미지를 사용하기 위해 Image 컴포넌트 사용

    void Start()
    {
        currentHP = maxHP;
        UpdateHPImage();
    }

    void UpdateHPImage()
    {
        if (hpImage != null)
        {
            hpImage.fillAmount = (float)currentHP / maxHP;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "enemy")
        {
            currentHP -= 1;
            int i = 1;
            UpdateHPImage();
            print(1);
        }
        else if (collision.collider.tag == "enemy_2")
        {
            currentHP -= 2;
            int i = 2;
            UpdateHPImage();
            print(2);
        }

        if (currentHP <= 0)
        {
            // 플레이어 사망 처리
            Debug.Log("Player Died");

            // 적 게임 오브젝트 비활성화
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
            GameObject[] enemies2 = GameObject.FindGameObjectsWithTag("enemy_2");

            foreach (GameObject enemy in enemies)
            {
                enemy.SetActive(false);
            }

            foreach (GameObject enemy2 in enemies2)
            {
                enemy2.SetActive(false);
            }
        }
    }
}

