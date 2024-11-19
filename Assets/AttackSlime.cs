using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSlime : MonoBehaviour
{
    private int touchCount = 0; // 터치 횟수를 추적하는 변수
    public int requiredTouches = 15; // 오브젝트가 파괴되기 위한 터치 횟수

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
            Ray2D ray = new Ray2D(wp, Vector2.zero); // 레이 방향을 0으로 설정
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            // 레이가 물체에 닿았는지 확인
            if (hit.collider != null)
            {
                print("hit");
                if (hit.collider.CompareTag("Slime"))
                {
                    // 터치 횟수를 증가
                    touchCount++;

                    // 터치 횟수가 15번에 도달하면 오브젝트 파괴
                    if (touchCount >= requiredTouches)
                    {
                        Destroy(hit.collider.gameObject); // 적 오브젝트 파괴
                        touchCount = 0; // 터치 횟수 초기화 (다시 0으로 설정)
                    }
                }
            }
        }
    }
    
}
