using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrapEntrance : MonoBehaviour
{
    public float detectionDistance = 5f;
    public float knockbackForce = 500f;

    private GameObject player;
    private Rigidbody playerRigidbody;
    private bool isPlayerDetected = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerRigidbody = player.GetComponent<Rigidbody>();
        }
    }

    void Update()
    {
        if (player == null) return;

        Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
        Vector3 rayStartPoint = transform.position + directionToPlayer * 0.5f;
        Vector3 rayDirection = (player.transform.position - rayStartPoint).normalized;
        RaycastHit hit;

        Debug.DrawRay(rayStartPoint, rayDirection * detectionDistance, Color.red);

        if (Physics.Raycast(rayStartPoint, rayDirection, out hit, detectionDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                isPlayerDetected = true;
            }
            else
            {
                isPlayerDetected = false;
            }
        }
        else
        {
            isPlayerDetected = false;
        }
    }

    void FixedUpdate()
    {
        if (isPlayerDetected && playerRigidbody != null)
        {
            playerRigidbody.velocity = new Vector3(0, playerRigidbody.velocity.y, 0);

            // 튕겨나가는 방향
            Vector3 knockbackDirection = (player.transform.position - transform.position);
            knockbackDirection.y = 0; 
            knockbackDirection.Normalize();

            playerRigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);

            isPlayerDetected = false;
        }
    }
}