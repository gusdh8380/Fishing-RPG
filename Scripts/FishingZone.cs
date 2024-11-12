using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingZone : MonoBehaviour
{
    public float width = 100.0f;
    public float height = 100.0f;
    public float mapScale = 3000f; // 맵의 스케일
    public float moveInterval = 60f; // 이동 간격 (1분)
    public bool isEntered = false; // 배가 영역 안에 있는지 여부
    private float timer = 0f; // 경과 시간을 추적하는 타이머

    private void Start()
    {
        // 초기 위치 설정
        MoveZone();
        
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

    private void OnTriggerEnter(Collider other)
    {
        // "Ship" 태그를 가진 오브젝트가 영역 안에 들어온 경우
        if (other.gameObject.tag == "Ship")
        {
            isEntered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // "Ship" 태그를 가진 오브젝트가 영역에서 나간 경우
        if (other.gameObject.tag == "Ship")
        {
            isEntered = false;
        }
    }
}


