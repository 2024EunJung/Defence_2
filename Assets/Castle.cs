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
    public Sprite destroyedSprite; // �ı��� ���� ��������Ʈ

    // Start is called before the first frame update
    void Start()
    {
        MaxHp = 10;
        Damge = 1;
        GuageBar = GameObject.Find("HpGuage").GetComponent<Image>();
        GuageBar.fillAmount = 1;
        spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer �ʱ�ȭ
    }

    // Update is called once per frame
    void Update()
    {
        if (GuageBar.fillAmount <= 0)
        {
            spriteRenderer.sprite = destroyedSprite; // ��������Ʈ ����
            spriteRenderer.transform.localScale = new Vector3(3, 3, 1); // ��������Ʈ ũ�� ����
            StartCoroutine(DestroyCastle()); // �� �ı� �ڷ�ƾ ����
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GuageBar.fillAmount -= Damge / MaxHp;
        Destroy(collision.gameObject);
    }

    private IEnumerator DestroyCastle()
    {
        yield return new WaitForSeconds(2); // �̹��� ǥ�� �ð� ���
        SceneManager.LoadScene("GameOver"); // GameOver �� �ε�
    }
}
