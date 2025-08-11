using UnityEngine;


public class JumpPlatform : MonoBehaviour
{
    public float bounceForce = 300f;
    public string targetTag = "Player";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                // �ӵ��� 0���� �ʱ�ȭ
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

                rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
            }
        }
    }
}