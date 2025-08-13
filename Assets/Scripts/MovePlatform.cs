using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public Vector3 startPoint;
    public Vector3 endPoint;
    public float speed = 1.0f;

    void Start()
    {
        startPoint = transform.position;
    }

    void Update()
    {
        // t�� 0�� 1 ���̸� �պ�
        float t = Mathf.PingPong(Time.time * speed, 1.0f);

        // ���� ������ �� ���� ���̸� t�� ���� �̵�
        transform.position = Vector3.Lerp(startPoint, endPoint, t);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // ĳ������ �θ� ���� �������� ����
            other.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // ĳ������ �θ� null�� �����Ͽ� ������Ŵ
            other.transform.SetParent(null);
        }
    }
}