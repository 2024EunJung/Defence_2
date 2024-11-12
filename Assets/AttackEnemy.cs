using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    private Dictionary<GameObject, int> clickCounts = new Dictionary<GameObject, int>();
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D ray = new Ray2D(wp, Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                if (hit.collider.tag == "enemy")
                {
                    Destroy(hit.collider.gameObject);
                }
                else if (hit.collider.tag == "enemy_2")
                {
                    GameObject enemy = hit.collider.gameObject;
                    if (!clickCounts.ContainsKey(enemy))
                    {
                        clickCounts[enemy] = 0;
                    }

                    clickCounts[enemy]++;

                    if (clickCounts[enemy] >= 2)
                    {
                        Destroy(enemy);
                        clickCounts.Remove(enemy);
                    }
                }
            }
        }
    }
}

   