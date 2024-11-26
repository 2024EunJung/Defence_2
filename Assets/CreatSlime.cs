using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatSlime : MonoBehaviour
{
    public GameObject prefabEnemy;
    public Vector2 limitMin;
    public Vector2 limitMax;
    private GameObject gameManager;  // ������ ������ �����ϴ� ���� �Ŵ���

    private float delay = 7.0f;  // 7�� ���� �ð�

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
            if (gameManager.GetComponent<Score>().GetLevel() >= 14)  // ������ 14 �̻����� Ȯ��
            {
                // y���� limitMin.y�� limitMax.y ���̿��� �������� ����
                float randomY = Random.Range(limitMin.y, limitMax.y);

                // ���� ��ġ ��� (x�� limitMin.x, y�� ����)
                Vector2 spawnPosition = new Vector2(limitMin.x, randomY);

                // �� ����
                Instantiate(prefabEnemy, spawnPosition, Quaternion.identity);
            }

            // 7�� �������� ������ ����
            yield return new WaitForSeconds(delay);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(limitMin, limitMax);
    }
}
