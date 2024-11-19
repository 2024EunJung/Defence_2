using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMove : MonoBehaviour
{
    // Start is called before the first frame update
   
    Transform tr;
    public float speed;
    public float jumpHeight = 5f;   // 점프의 높이
    public float jumpDuration = 1f; // 점프하는 데 걸리는 시간(초)

    private float timeElapsed = 0f; // 시간 추적용 변수

    void Start()
    {
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        // 이동 (X축)
        tr.Translate(Vector2.left * speed * Time.deltaTime);

        // 점프 (Y축)
        timeElapsed += Time.deltaTime;

        // 사인 함수 이용해서 점프 동작 구현
        float jumpOffset = Mathf.Sin(timeElapsed * Mathf.PI / jumpDuration) * jumpHeight;

        // Y 좌표에 점프 오프셋을 적용
        tr.position = new Vector3(tr.position.x, jumpOffset, tr.position.z);
    }
}
