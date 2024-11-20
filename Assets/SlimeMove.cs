using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMove : MonoBehaviour
{
    // Start is called before the first frame update
   
    Transform tr;
    public float speed;
    public float jumpHeight = 5f;   // ������ ����
    public float jumpDuration = 1f; // �����ϴ� �� �ɸ��� �ð�(��)

    private float timeElapsed = 0f; // �ð� ������ ����

    void Start()
    {
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        // �̵� (X��)
        tr.Translate(Vector2.left * speed * Time.deltaTime);

        // ���� (Y��)
        timeElapsed += Time.deltaTime;

        // ���� �Լ� �̿��ؼ� ���� ���� ����
        float jumpOffset = Mathf.Sin(timeElapsed * Mathf.PI / jumpDuration) * jumpHeight;

        // Y ��ǥ�� ���� �������� ����
        tr.position = new Vector3(tr.position.x, jumpOffset, tr.position.z);
    }
}
