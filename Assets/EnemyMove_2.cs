using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove_2 : MonoBehaviour
{
    Transform tr;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        tr.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
