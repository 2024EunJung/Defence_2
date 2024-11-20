using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSlime : MonoBehaviour
{
    private int touchCount = 0; // ��ġ Ƚ���� �����ϴ� ����
    public int requiredTouches = 15; // ������Ʈ�� �ı��Ǳ� ���� ��ġ Ƚ��

    // Start is called before the first frame update
    void Start()
    {
        touchCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("test");
            Vector2 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D ray = new Ray2D(wp, Vector2.zero); // ���� ������ 0���� ����
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            // ���̰� ��ü�� ��Ҵ��� Ȯ��
            if (hit.collider != null)
            {
                print("hit");
                if (hit.collider.CompareTag("Slime"))
                {
                    // ��ġ Ƚ���� ����
                    touchCount++;

                    // ��ġ Ƚ���� 15���� �����ϸ� ������Ʈ �ı�
                    if (touchCount >= requiredTouches)
                    {
                        Destroy(hit.collider.gameObject); // �� ������Ʈ �ı�
                        touchCount = 0; // ��ġ Ƚ�� �ʱ�ȭ (�ٽ� 0���� ����)
                    }
                }
            }
        }
    }
    
}
