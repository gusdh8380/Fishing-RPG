using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관리자 관련 코드
using UnityEngine.UI; // UI 관련 코드

// 필요한 UI에 즉시 접근하고 변경할 수 있도록 허용하는 UI 매니저
public class UIManager : MonoBehaviour {
    // 싱글톤 접근용 프로퍼티
    public static UIManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<UIManager>();
            }

            return m_instance;
        }
    }

    private static UIManager m_instance; // 싱글톤이 할당될 변수


    public Text LevelText; //레벨 텍스트
    public Text GoldText; // 골드량 텍스트
    public GameObject gameoverUI; // 게임 오버시 활성화할 UI 
    public GameObject gameclearUI;

    public Text playTimeText; // 플레이 시간 텍스트
    private float playTime; // 플레이 시간


    private void Update()
    {
        // GameManager로부터 게임 시간 받아와서 UI 갱신
        float playTime = GameManager.instance.PlayTime;
        playTimeText.text = "Play Time: " + Mathf.Floor(playTime) + " seconds";
    }

    // 점수 텍스트 갱신
    public void UpdateLevelText(int Level) {
        LevelText.text = "Level " + Level;
    }

    // 적 웨이브 텍스트 갱신
    public void UpdateGoldText(int Gold) {
        GoldText.text = "Gold " + Gold;
    }

    // 게임 오버 UI 활성화
    public void SetActiveGameoverUI(bool active) {
        gameoverUI.SetActive(active);
        // 게임 오버시 플레이한 시간 표시
        if (active)
        {
            playTimeText.text = "Play Time: " + Mathf.Floor(playTime) + " seconds";
        }
    }
    public void SetActiveGameClearUI(bool active)
    {
        gameclearUI.SetActive(active);
        // 게임 클리어시 플레이한 시간 표시
        if (active)
        {
            playTimeText.text = "Play Time: " + Mathf.Floor(playTime) + " seconds";
        }
    }

    // 게임 재시작
    public void GameRestart() {
        SceneManager.LoadScene("Fishing RPG");
    }
}