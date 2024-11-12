using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Castle : MonoBehaviour
{
    private float MaxHp;
    private float Damge;
    private Image GuageBar;
    private SpriteRenderer spriteRenderer;
    public Sprite destroyedSprite; // 파괴된 성의 스프라이트

    // Start is called before the first frame update
    void Start()
    {
        MaxHp = 10;
        Damge = 1;
        GuageBar = GameObject.Find("HpGuage").GetComponent<Image>();
        GuageBar.fillAmount = 1;
        spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer 초기화
    }

    // Update is called once per frame
    void Update()
    {
        if (GuageBar.fillAmount <= 0)
        {
            spriteRenderer.sprite = destroyedSprite; // 스프라이트 변경
            spriteRenderer.transform.localScale = new Vector3(3, 3, 1); // 스프라이트 크기 조정
            StartCoroutine(DestroyCastle()); // 성 파괴 코루틴 시작
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GuageBar.fillAmount -= Damge / MaxHp;
        Destroy(collision.gameObject);
    }

    private IEnumerator DestroyCastle()
    {
        yield return new WaitForSeconds(2); // 이미지 표시 시간 대기
        SceneManager.LoadScene("GameOver"); // GameOver 씬 로드
    }
}
