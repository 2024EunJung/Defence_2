using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    public GameObject prefabEnemy;
    public Vector2 limitMin;
    public Vector2 limitMax;
    public Score scoreScript;  // Score ��ũ��Ʈ�� ����

    private float delay;  // �⺻ ���� �ð�
    private int level;

    void Start()
    {
        // Score ��ũ��Ʈ�� �ڵ����� ã��
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
                delay = 2.0f / (0.5f * currentLevel); // ������ ���� ���� �ð� �ϸ��ϰ� ����
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
