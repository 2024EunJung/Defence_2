using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy_2 : MonoBehaviour
{
    public GameObject prefabEnemy;
    public Vector2 limitMin;
    public Vector2 limitMax;

    private float delay;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartCreatingAfterDelay(30.0f)); // 30초 후에 적 생성 시작
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator StartCreatingAfterDelay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(Create());
    }

    IEnumerator Create()
    {
        while (true)
        {

            count++;

            float r = Random.Range(limitMin.y, limitMax.y);
            Vector2 creatingPoint = new Vector2(limitMin.x, r);

            Instantiate(prefabEnemy, creatingPoint, Quaternion.identity);


            delay = 30.0f / (count + 4);
            yield return new WaitForSeconds(delay);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(limitMin, limitMax);
    }
}
