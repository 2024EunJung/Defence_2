using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    private Score scoreScript;

    void Start()
    {
        scoreScript = FindObjectOfType<Score>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D ray = new Ray2D(wp, Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null && hit.collider.CompareTag("enemy"))
            {
                Destroy(hit.collider.gameObject);

                if (scoreScript != null)
                {
                    scoreScript.IncreaseScore();
                }
            }
        }
    }
}
