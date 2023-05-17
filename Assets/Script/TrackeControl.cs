using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class TrackeControl : MonoBehaviour
{
    Rigidbody2D rb;
    Transform target;

    [Header("�߰� �ӵ�")]
    [SerializeField] [Range(1f, 4f)] float moveSpeed = 3f;

    [Header("�����Ÿ�")]
    [SerializeField] [Range(0f, 3f)] float contactDistance = 1f;

    bool follow = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        FollowTarget();

    }
    void FollowTarget()
    {
        if (Vector2.Distance(transform.position, target.position) > contactDistance && follow)
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        else
            rb.velocity = Vector2.zero;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        follow = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        follow = false;
    }
}
