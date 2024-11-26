using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float HP = 10; // 캐릭터 HP

    public delegate void ZombieCollideHandler();
    public event ZombieCollideHandler OnZombieCollide;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            HP -= 1; // 좀비와 충돌 시 HP 감소
            if (HP <= 0)
            {
                OnZombieCollide?.Invoke();
                Destroy(gameObject); // HP가 0이 되면 캐릭터 파괴
            }
            Destroy(collision.gameObject); // 좀비 파괴
        }
    }
}
