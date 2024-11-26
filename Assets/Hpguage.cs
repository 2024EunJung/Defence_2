using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // HP �� �̹����� UI�� ǥ���ϱ� ���� �ʿ�

public class HPGuage : MonoBehaviour
{
    public float maxHP = 10;
    private float currentHP;
    public Image hpImage; // HP �� �̹����� ����ϱ� ���� Image ������Ʈ ���

    void Start()
    {
        currentHP = maxHP;
        hpImage.fillAmount = 1;
    }

    void Update()
    {
        if (hpImage != null)
        {
            hpImage.fillAmount = (float)(currentHP / maxHP);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            currentHP -= 1;
            
        }
        else if (collision.gameObject.tag == "enemy_2")
        {
            currentHP -= 2;
           
        }

        if (currentHP <= 0)
        { 
            GameObject[] enemys = GameObject.FindGameObjectsWithTag("enemy");
            GameObject[] enemy_2s = GameObject.FindGameObjectsWithTag("enemy_2");
            foreach (GameObject enemy in enemys)
            {
                enemy.SetActive(false);
            }
            foreach (GameObject enemy_2 in enemy_2s)
            {
                enemy_2.SetActive(false);
            }
        }

        if (currentHP <= 0)
        {
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

