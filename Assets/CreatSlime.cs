using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatSlime : MonoBehaviour
{
    public GameObject prefabEnemy;
    public Vector2 limitMin;
    public Vector2 limitMax;

    private float delay;
    private int count;
    private int level = 1; // 현재 레벨 변수, 시작은 레벨 1로 설정

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Create());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Create()
    {
        while (true)
        {
            // 레벨이 5 이상일 때만 적을 생성
            if (level >= 5)
            {
                count++; // 적을 생성할 때마다 카운트 증가

                // y값은 limitMin.y와 limitMax.y 사이에서 랜덤으로 선택
                float r = Random.Range(limitMin.y, limitMax.y);

                // 생성 위치 계산 (x는 limitMin.x, y는 랜덤)
                Vector2 creatingPoint = new Vector2(limitMin.x, r);

                // 적 생성
                Instantiate(prefabEnemy, creatingPoint, Quaternion.identity);
            }

            // 7초 간격으로 생성
            yield return new WaitForSeconds(7.0f);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(limitMin, limitMax);
    }
}
