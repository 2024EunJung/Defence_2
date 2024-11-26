using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float HP = 10; // ĳ���� HP

    public delegate void ZombieCollideHandler();
    public event ZombieCollideHandler OnZombieCollide;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            HP -= 1; // ����� �浹 �� HP ����
            if (HP <= 0)
            {
                OnZombieCollide?.Invoke();
                Destroy(gameObject); // HP�� 0�� �Ǹ� ĳ���� �ı�
            }
            Destroy(collision.gameObject); // ���� �ı�
        }
    }
}
