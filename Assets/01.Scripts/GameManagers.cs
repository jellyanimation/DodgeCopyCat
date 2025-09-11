using UnityEngine;
using UnityEngine.UI; // UI ���� ���̺귯��
using TMPro; // TextMeshPro ���� ���̺귯��
using UnityEngine.SceneManagement; // �� ���� ���� ���̺귯��

public class GameManagers : MonoBehaviour
{
    public GameObject gameoverText;           // ���� ���� �� Ȱ��ȭ�� �ؽ�Ʈ ���� ������Ʈ
    public TextMeshProUGUI timeText;          // ���� �ð��� ǥ���� �ؽ�Ʈ ������Ʈ
    public TextMeshProUGUI recordText;        // �ְ� ����� ǥ���� �ؽ�Ʈ ������Ʈ

    private float surviveTime;                // ���� �ð�
    private bool isGameover;                  // ���ӿ��� ����

    void Start()
    {
        // ���� �ð��� ���ӿ��� ���� �ʱ�ȭ
        surviveTime = 0;
        isGameover = false;
    }

    void Update()
    {
        if (!isGameover)
        {
            // ���� �ð� ����
            surviveTime += Time.deltaTime;

            // ������ ���� �ð��� timeText �ؽ�Ʈ ������Ʈ�� ���� ǥ��
            timeText.text = "Time: " + (int)surviveTime;
        }
        else
        {
            // ���ӿ��� ���¿��� RŰ�� ������ �� �����
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Kawaii World Scene");
            }
        }
    }

    // ���� ������ ���ӿ��� ���·� �����ϴ� Ŀ���� �޼���
    public void EndGame()
    {
        // ���� ���¸� ���ӿ��� ���·� ��ȯ
        isGameover = true;

        // ���ӿ��� �ؽ�Ʈ ���� ������Ʈ�� Ȱ��ȭ
        gameoverText.SetActive(true);

        // BestTime Ű�� ����� ���������� �ְ� ��� ��������
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        // ���������� �ְ� ��Ϻ��� ���� ���� �ð��� �� ũ�ٸ�
        if (surviveTime > bestTime)
        {
            // �ְ� ��� ���� ���� ���� �ð� ������ ����
            bestTime = surviveTime;

            // ����� �ְ� ����� BestTime Ű�� ����
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        // �ְ� ����� recordText �ؽ�Ʈ ������Ʈ�� ���� ǥ��
        recordText.text = "Best time: " + (int)bestTime;
    }
}