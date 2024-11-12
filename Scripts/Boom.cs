using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관리를 위해 필요

public class Boom : MonoBehaviour
{
    public float mapScale = 3000f; // 맵의 스케일
    public float moveInterval = 30f; // 이동 간격 (30초)
    public bool isEntered = false;
    private float timer = 0f;

    private LevelUpShip Ship;
    private void Start()
    {
        // 초기 위치 설정
        MoveZone();
        Ship = GetComponent<LevelUpShip>();
    }

    private void Update()
    {
        //30초 후에 위치 이동 코드 구현
        timer += Time.deltaTime; // 경과 시간을 더함

        // 30초가 경과했는지 확인
        if (timer > moveInterval)
        {
            MoveZone(); // 위치 이동
            timer = 0f; // 타이머 초기화
        }
    }

    private void MoveZone()
    {
        // 맵 내의 무작위 위치 계산
        float xPosition = Random.Range(-mapScale / 2, mapScale / 2);
        float zPosition = Random.Range(-mapScale / 2, mapScale / 2);
        Vector3 newPosition = new Vector3(xPosition, 0, zPosition);

        // 위치 이동
        transform.position = newPosition;
    }
}