using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingZone : MonoBehaviour
{
    public float width = 100.0f;
    public float height = 100.0f;
    public float mapScale = 3000f; // ���� ������
    public float moveInterval = 60f; // �̵� ���� (1��)
    public bool isEntered = false; // �谡 ���� �ȿ� �ִ��� ����
    private float timer = 0f; // ��� �ð��� �����ϴ� Ÿ�̸�

    private void Start()
    {
        // �ʱ� ��ġ ����
        MoveZone();
        
    }

    private void Update()
    {
        //30�� �Ŀ� ��ġ �̵� �ڵ� ����
        timer += Time.deltaTime; // ��� �ð��� ����

        // 30�ʰ� ����ߴ��� Ȯ��
        if (timer > moveInterval)
        {
            MoveZone(); // ��ġ �̵�
            timer = 0f; // Ÿ�̸� �ʱ�ȭ
        }
    }

     private void MoveZone()
    {
        // �� ���� ������ ��ġ ���
        float xPosition = Random.Range(-mapScale / 2, mapScale / 2);
        float zPosition = Random.Range(-mapScale / 2, mapScale / 2);
        Vector3 newPosition = new Vector3(xPosition, 0, zPosition);

        // ��ġ �̵�
        transform.position = newPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        // "Ship" �±׸� ���� ������Ʈ�� ���� �ȿ� ���� ���
        if (other.gameObject.tag == "Ship")
        {
            isEntered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // "Ship" �±׸� ���� ������Ʈ�� �������� ���� ���
        if (other.gameObject.tag == "Ship")
        {
            isEntered = false;
        }
    }
}


