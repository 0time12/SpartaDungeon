using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrapEntrance : MonoBehaviour
{
    public float detectionDistance = 3f;
    public float knockbackForce = 1000000f;
    
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
        Ray ray = new Ray(transform.position, directionToPlayer);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, detectionDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                isPlayerDetected = true;
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
            playerRigidbody.velocity = Vector3.zero;

            // ���� ���� ���͸� ����ϰ� Y�� ���� �����մϴ�.
            Vector3 horizontalDirection = (player.transform.position - transform.position);
            horizontalDirection.y = 0;
            horizontalDirection.Normalize();

            // ���� �������� ƨ�ܳ����� ���� ���մϴ�.
            playerRigidbody.AddForce(horizontalDirection * knockbackForce, ForceMode.Impulse);

            // ���� ƨ�ܳ����� ���� ������ ���մϴ�.
            // verticalKnockbackForce ���� ���ϴ� ��� �����غ�����.
            float verticalKnockbackForce = 200f;
            playerRigidbody.AddForce(Vector3.up * verticalKnockbackForce, ForceMode.Impulse);

            isPlayerDetected = false;
        }
    }
}