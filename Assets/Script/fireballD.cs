using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballD : MonoBehaviour
{
    public float speed;
    public float distance;
    public LayerMask isLayer;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroyfireball", 2);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.right, distance, isLayer);
        if (ray.collider != null)
        {
            if (ray.collider.tag == "enemy")
            {
                gamed.enemyHP = gamed.enemyHP - 1;
            }
            Destroyfireball();
        }
        transform.Translate(transform.up * -1 * speed * Time.deltaTime);
    }

    void Destroyfireball()
    {
        Destroy(gameObject);
    }
}