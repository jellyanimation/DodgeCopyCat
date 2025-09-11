using UnityEngine;
using UnityEngine.UI; // UI 관련

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public float speed = 8f;

    // 에너지바 관련
    public Image energyBarImage;          // Canvas 하위 Image
    public Sprite energyFull;             // 체력 3단계
    public Sprite energyHalf;             // 체력 2단계
    public Sprite energyEmpty;            // 체력 1단계
    private int health = 3;               // 초기 체력 3

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        energyBarImage.sprite = energyFull; // 시작 시 에너지바 Full
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 newVelocity = new Vector3(xInput * speed, 0f, zInput * speed);
        playerRigidbody.linearVelocity = newVelocity;

        // 👇 바닥 아래로 떨어지면 게임 종료
        if (transform.position.y < -5f) // 원하는 높이값(-5f)을 조정 가능
        {
            Die();
        }
    }

    // 총알에 맞았을 때 호출
    public void TakeDamage()
    {
        health--;

        if (health == 2)
        {
            energyBarImage.sprite = energyHalf;   // 2칸 남았을 때 → 절반 아이콘
        }
        else if (health == 1)
        {
            energyBarImage.sprite = energyEmpty;  // 1칸 남았을 때 → 거의 빈 아이콘
        }
        else if (health <= 0)
        {
            energyBarImage.enabled = false;
            // 체력 다 닳으면 → 게임 종료
            Die();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("DeathZone"))
        {
            Die();
        }
    }


    public void Die()
    {
        gameObject.SetActive(false);



        GameManagers gameManagers = FindFirstObjectByType<GameManagers>();
        gameManagers.EndGame();
    }
}
