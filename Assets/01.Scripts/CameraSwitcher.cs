using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    // Unity �����Ϳ��� �츮�� ���� ī�޶� 2���� ����� ���� �� �ִ� ���� ����(����)�Դϴ�.
    public GameObject topDownCamera;
    public GameObject backViewCamera;

    // ���� ž�ٿ� �䰡 Ȱ��ȭ�Ǿ� �ִ��� ���¸� �����ϴ� �����Դϴ�.
    // true�̸� ž�ٿ�, false�̸� ��並 �ǹ��մϴ�.
    private bool isTopDownView = true;

    // ������ ó�� ���۵� �� �� �� �� ȣ��Ǵ� �Լ��Դϴ�.
    void Start()
    {
        // ���� ������ ž�ٿ� ��� Ȯ���ϰ� �����մϴ�.
        topDownCamera.SetActive(true);
        backViewCamera.SetActive(false);
    }

    // �� �����Ӹ��� ����ؼ� ȣ��Ǵ� �Լ��Դϴ�.
    // ������� �Է��� �����ϱ⿡ ���� ���� ������.
    void Update()
    {
        // ���� ����ڰ� 'Q' Ű�� "������ ��" (��� ������ �ִ� �� �ƴ϶�)
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // ���� ī�޶� ���¸� �ݴ�� �������ϴ�.
            // isTopDownView�� true���ٸ� false��, false���ٸ� true�� �ٲߴϴ�.
            isTopDownView = !isTopDownView;

            // ������ ���¿� ���� �� ī�޶� �Ѱ� ���ϴ�.
            topDownCamera.SetActive(isTopDownView);
            backViewCamera.SetActive(!isTopDownView);
        }
    }
}
