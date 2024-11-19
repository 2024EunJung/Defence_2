using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    public GameObject prefabEnemy;
    public Vector2 limitMin;
    public Vector2 limitMax;
    public Score scoreScript;  // Score 스크립트를 참조

    private float delay;  // 기본 지연 시간
    private int level;

    void Start()
    {
        // Score 스크립트를 자동으로 찾기
        if (scoreScript != null)
        {
        }
        else
        {
            scoreScript = FindObjectOfType<Score>();
        }

        StartCoroutine(Create());
    }

    IEnumerator Create()
    {
        while (true)
        {
            float r = Random.Range(limitMin.y, limitMax.y);
            Vector2 creatingPoint = new Vector2(limitMin.x, r);

            Instantiate(prefabEnemy, creatingPoint, Quaternion.identity);

            if (scoreScript != null)
            {
                int currentLevel = scoreScript.GetLevel();
                delay = 2.0f / (0.5f * currentLevel); // 레벨에 따라 지연 시간 완만하게 감소
            }

            yield return new WaitForSeconds(delay);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(limitMin, limitMax);
    }
}
