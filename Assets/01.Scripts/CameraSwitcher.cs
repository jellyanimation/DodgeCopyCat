using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    // Unity 에디터에서 우리가 만든 카메라 2개를 끌어다 놓을 수 있는 공개 변수(슬롯)입니다.
    public GameObject topDownCamera;
    public GameObject backViewCamera;

    // 현재 탑다운 뷰가 활성화되어 있는지 상태를 저장하는 변수입니다.
    // true이면 탑다운, false이면 백뷰를 의미합니다.
    private bool isTopDownView = true;

    // 게임이 처음 시작될 때 딱 한 번 호출되는 함수입니다.
    void Start()
    {
        // 시작 시점을 탑다운 뷰로 확실하게 설정합니다.
        topDownCamera.SetActive(true);
        backViewCamera.SetActive(false);
    }

    // 매 프레임마다 계속해서 호출되는 함수입니다.
    // 사용자의 입력을 감지하기에 가장 좋은 곳이죠.
    void Update()
    {
        // 만약 사용자가 'Q' 키를 "눌렀을 때" (계속 누르고 있는 게 아니라)
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // 현재 카메라 상태를 반대로 뒤집습니다.
            // isTopDownView가 true였다면 false로, false였다면 true로 바꿉니다.
            isTopDownView = !isTopDownView;

            // 뒤집힌 상태에 따라 각 카메라를 켜고 끕니다.
            topDownCamera.SetActive(isTopDownView);
            backViewCamera.SetActive(!isTopDownView);
        }
    }
}
