using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 접근 한정자 담은 타입 식별자 (변수명) -변수 선언
    public Rigidbody playerRigidbody; //이동에 사용할 리지드바디 컴포넌트
    public float speed = 8f;         //이동 속력


    void Start() //유니티에서 제공하는 이벤트 메서드로 시작할때 한번실행
    {
        //게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 playerRigidbody에 할당
        playerRigidbody = GetComponent<Rigidbody>();
    }


    void Update() //유니티에서 제공하는 이벤트 메서드로 반복실행
    {
        //수평축과 수직축의 입력값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        //실제 이동 속도를 입력값과 이동 속력을 통해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        // Vector3 속도를 (xSpeed, 0 , zSpeed);
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        // 리지드바디의 속도에 newVelocity 할당
        playerRigidbody.linearVelocity = newVelocity; //동작 ★
    }

    public void Die()
    {
        //자신의 게임 오브젝트를 비활성화
        gameObject.SetActive(false);

        //씬에 존재하는 GameManager 타입의 오브젝트를 찾아서 가져오기
        GameManagers gameManagers = FindFirstObjectByType<GameManagers>();

        //가져온 GameManager 오브젝트의 EndGame() 메서드 실행
        gameManagers.EndGame();

    }
}
