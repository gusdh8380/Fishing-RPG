using UnityEngine;
using UnityEngine.SceneManagement; // �� ������ ���� �ʿ�

public class Boom : MonoBehaviour
{
    public float mapScale = 3000f; // ���� ������
    public float moveInterval = 30f; // �̵� ���� (30��)
    public bool isEntered = false;
    private float timer = 0f;

    private LevelUpShip Ship;
    private void Start()
    {
        // �ʱ� ��ġ ����
        MoveZone();
        Ship = GetComponent<LevelUpShip>();
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
}