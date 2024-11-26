using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatSlime : MonoBehaviour
{
    public GameObject prefabEnemy;
    public Vector2 limitMin;
    public Vector2 limitMax;
    private GameObject gameManager;  // 슬라임 레벨을 추적하는 게임 매니저

    private float delay = 7.0f;  // 7초 지연 시간

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        if (gameManager != null)
        {
            StartCoroutine(CreateSlime());
        }
        else
        {
            Debug.LogError("GameManager object not found!");
        }
    }

    void Update()
    {
    }

    IEnumerator CreateSlime()
    {
        while (true)
        {
            if (gameManager.GetComponent<Score>().GetLevel() >= 14)  // 레벨이 14 이상인지 확인
            {
                // y값은 limitMin.y와 limitMax.y 사이에서 랜덤으로 선택
                float randomY = Random.Range(limitMin.y, limitMax.y);

                // 생성 위치 계산 (x는 limitMin.x, y는 랜덤)
                Vector2 spawnPosition = new Vector2(limitMin.x, randomY);

                // 적 생성
                Instantiate(prefabEnemy, spawnPosition, Quaternion.identity);
            }

            // 7초 간격으로 슬라임 생성
            yield return new WaitForSeconds(delay);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(limitMin, limitMax);
    }
}
