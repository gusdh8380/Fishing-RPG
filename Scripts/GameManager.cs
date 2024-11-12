using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<GameManager>();
            }

            return m_instance;
        }
    }

    private static GameManager m_instance;

    private LevelUpShip ship;
    public bool isGameover { get; private set; } // ���� ���� ����
    private float surviveTime;  //�����ð�

    public float PlayTime { get { return surviveTime; } } // �ܺο��� ���� ������ PlayTime ������Ƽ
    private void Awake()
    {
        if (instance != this)
        {
            Destroy(gameObject);
        }
        ship = FindObjectOfType<LevelUpShip>();
    }

    private void Update()
    {
        if (!ship.Die())
        {
            EndGame();
        }
        if (ship.ClearGame())
        {
            UIManager.instance.SetActiveGameClearUI(true);
        }
        if (!isGameover)
        {
            //�����ð� ����
            surviveTime += Time.deltaTime;
            
        }
    }

    // ������ �߰��ϰ� UI ����
    public void AddLevel(int newLevel)
    {
        if (!isGameover)
        {
            UIManager.instance.UpdateLevelText(newLevel);
        }
    }

    // ��带 �߰��ϰ� UI ����
    public void AddGold(int newGold)
    {
        if (!isGameover)
        {
            UIManager.instance.UpdateGoldText(newGold);
        }
    }

    public void EndGame()
    {
        isGameover = true;
        UIManager.instance.SetActiveGameoverUI(true);
    }
}
