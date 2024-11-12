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
    public bool isGameover { get; private set; } // 게임 오버 상태
    private float surviveTime;  //생존시간

    public float PlayTime { get { return surviveTime; } } // 외부에서 접근 가능한 PlayTime 프로퍼티
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
            //생존시간 갱신
            surviveTime += Time.deltaTime;
            
        }
    }

    // 레벨을 추가하고 UI 갱신
    public void AddLevel(int newLevel)
    {
        if (!isGameover)
        {
            UIManager.instance.UpdateLevelText(newLevel);
        }
    }

    // 골드를 추가하고 UI 갱신
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
