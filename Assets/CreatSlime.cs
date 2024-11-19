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
    private int level = 1; // ���� ���� ����, ������ ���� 1�� ����

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
            // ������ 5 �̻��� ���� ���� ����
            if (level >= 5)
            {
                count++; // ���� ������ ������ ī��Ʈ ����

                // y���� limitMin.y�� limitMax.y ���̿��� �������� ����
                float r = Random.Range(limitMin.y, limitMax.y);

                // ���� ��ġ ��� (x�� limitMin.x, y�� ����)
                Vector2 creatingPoint = new Vector2(limitMin.x, r);

                // �� ����
                Instantiate(prefabEnemy, creatingPoint, Quaternion.identity);
            }

            // 7�� �������� ����
            yield return new WaitForSeconds(7.0f);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(limitMin, limitMax);
    }
}
