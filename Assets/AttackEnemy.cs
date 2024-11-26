using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    private Score scoreScript;
    private Dictionary<GameObject, int> clickCounts = new Dictionary<GameObject, int>();

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

            if (hit.collider != null)
            {
                Debug.Log("Hit: " + hit.collider.tag); // Log hit collider tag

                if (hit.collider.tag == "enemy")
                {
                    Destroy(hit.collider.gameObject);
                    
                    if (scoreScript != null)
                    {
                        scoreScript.IncreaseScore();
                    }
                }
                else if (hit.collider.tag == "enemy_2")
                {
                    
                    GameObject enemy = hit.collider.gameObject;
                    if (!clickCounts.ContainsKey(enemy))
                    {
                        clickCounts[enemy] = 0;
                    }

                    clickCounts[enemy]++;

                    Debug.Log("enemy_2 click count: " + clickCounts[enemy]); // Log click count

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
