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
        // t는 0과 1 사이를 왕복
        float t = Mathf.PingPong(Time.time * speed, 1.0f);

        // 시작 지점과 끝 지점 사이를 t에 따라 이동
        transform.position = Vector3.Lerp(startPoint, endPoint, t);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 캐릭터의 부모를 현재 발판으로 설정
            other.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 캐릭터의 부모를 null로 설정하여 독립시킴
            other.transform.SetParent(null);
        }
    }
}