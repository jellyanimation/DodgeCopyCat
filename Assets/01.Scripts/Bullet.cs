using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;               // ź�� �̵� �ӷ�
    private Rigidbody bulletRigidbody;     // �̵��� ����� ������ٵ� ������Ʈ

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // ���� ������Ʈ���� Rigidbody ������Ʈ�� ã�� bulletRigidbody�� �Ҵ�
        bulletRigidbody = GetComponent<Rigidbody>();

        // ������ٵ��� �ӵ� = �ڽ��� ���� ���� * �̵� �ӷ�
        bulletRigidbody.linearVelocity = transform.forward * speed;

        // 3�� �ڿ� �ڽ��� ���� ������Ʈ �ı�
        Destroy(gameObject, 3f);
    }

    // Ʈ���� �浹 �� �ڵ����� ����Ǵ� �޼���
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // ���� ���� ������Ʈ���� PlayerController ������Ʈ ��������
            PlayerController playerController = other.GetComponent<PlayerController>();

            // �������κ��� PlayerController ������Ʈ�� �������� �� �����ߴٸ�
            if (playerController != null)
            {
                playerController.TakeDamage(); // ü�� ���� & �������� ����
            }
        }
    }
}
