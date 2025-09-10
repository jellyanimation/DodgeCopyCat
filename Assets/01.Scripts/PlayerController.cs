using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // ���� ������ ���� Ÿ�� �ĺ��� (������) -���� ����
    public Rigidbody playerRigidbody; //�̵��� ����� ������ٵ� ������Ʈ
    public float speed = 8f;         //�̵� �ӷ�


    void Start() //����Ƽ���� �����ϴ� �̺�Ʈ �޼���� �����Ҷ� �ѹ�����
    {
        //���� ������Ʈ���� Rigidbody ������Ʈ�� ã�� playerRigidbody�� �Ҵ�
        playerRigidbody = GetComponent<Rigidbody>();
    }


    void Update() //����Ƽ���� �����ϴ� �̺�Ʈ �޼���� �ݺ�����
    {
        //������� �������� �Է°��� �����Ͽ� ����
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        //���� �̵� �ӵ��� �Է°��� �̵� �ӷ��� ���� ����
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        // Vector3 �ӵ��� (xSpeed, 0 , zSpeed);
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        // ������ٵ��� �ӵ��� newVelocity �Ҵ�
        playerRigidbody.linearVelocity = newVelocity; //���� ��
    }

    public void Die()
    {
        //�ڽ��� ���� ������Ʈ�� ��Ȱ��ȭ
        gameObject.SetActive(false);

        //���� �����ϴ� GameManager Ÿ���� ������Ʈ�� ã�Ƽ� ��������
        GameManagers gameManagers = FindFirstObjectByType<GameManagers>();

        //������ GameManager ������Ʈ�� EndGame() �޼��� ����
        gameManagers.EndGame();

    }
}
