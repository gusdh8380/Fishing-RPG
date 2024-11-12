using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpShip : MonoBehaviour
{
    public int[] extoLevelup = new int[] { 100, 500, 1000, 2000, 3200 };
    public int currentGold = 0;
    public int currentLevel = 0;
    private PropellerBoats ppb;
    public int ShipLevelUp = 0;
    

    public bool islive = true;
    public bool isclear = false;

    private FishingZone fz;
    private bool isEntered = false; // 배가 영역 안에 있는지 여부

    // 물고기 한 마리당 얻는 골드
    public int baseGoldPerFish = 10;
    public int extraGoldPerLevel = 5;
    public float fishCatchRate = 1.0f;

    void Awake()
    {
        ppb = GetComponent<PropellerBoats>();
        fz = GetComponent<FishingZone>();
    }

    private void Update()
    {
        // 배가 멈추어 있을 때 f키를 눌러 낚시를 합니다.
        if (ppb.engine_rpm == 0 && Input.GetKey(KeyCode.F))
        {
            if (isEntered)
            {
                //낚시 시작
                if (Random.Range(0.0f, 1.0f) < fishCatchRate * Time.deltaTime)
                {
                    // 레벨에 따른 골드 획득량 계산
                    int goldPerFish = baseGoldPerFish + extraGoldPerLevel * (currentLevel);

                    // 골드 획득
                    GainGold(goldPerFish);

                    //잡았다면 콘솔이나 UI에 이벤트 코드 구현
                    Debug.Log("잡았다!!");
                    Debug.Log("현재 골드 : ");
                    Debug.Log(currentGold);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // "Ship" 태그를 가진 오브젝트가 영역 안에 들어온 경우
        if (other.gameObject.tag == "Point")
        {
            isEntered = true;
        }
        // "Boom" 태그를 가진 오브젝트와 충돌한 경우
        if (other.gameObject.tag == "Boom")
        {
            islive = false;
            Die();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        // "Ship" 태그를 가진 오브젝트가 영역에서 나간 경우
        if (other.gameObject.tag == "Point")
        {
            isEntered = false;
        }
    }
    

    public void GainGold(int Gold)
    {
        currentGold += Gold;
        GameManager.instance.AddGold(currentGold);

        if ( currentGold >= extoLevelup[currentLevel])
        {
            ++ShipLevelUp;

            if (ShipLevelUp == 1)
            {
                LevelUp2();
                Debug.Log("레벨 업!");
            }
            else if (ShipLevelUp == 2)
            {
                LevelUp3();
                Debug.Log("레벨 업!");
            }
            else if (ShipLevelUp == 3)
            {
                LevelUp4();
                Debug.Log("레벨 업!");
            }
            else if (ShipLevelUp == 4)
            {
                LevelUp5();
                Debug.Log("레벨 업!");
            }
            else if (ShipLevelUp == 5)
            {
                LevelUp6();
                Debug.Log("레벨 업!");
            }
            else if (ShipLevelUp == 6)
            {
                Debug.Log("게임 종료");
                isclear = true;
                ClearGame();
            }

        }
    }

    public void LevelUp2()
    {
        currentLevel++;
        currentGold -= extoLevelup[currentLevel - 1];
    

        // 성능 향상 코드
        ppb.engine_max_rpm += 100F;
        ppb.acceleration_cst += 2.0F;

        GameManager.instance.AddLevel(currentLevel);
    }

    public void LevelUp3()
    {
        currentLevel++;
        currentGold -= extoLevelup[currentLevel - 1];


        // 성능 향상 코드
        ppb.engine_max_rpm += 300f;

        GameManager.instance.AddLevel(currentLevel);
    }

    public void LevelUp4()
    {
        currentLevel++;
        currentGold -= extoLevelup[currentLevel - 1];
  

        // 성능 향상 코드
        ppb.engine_max_rpm += 400f;
        ppb.acceleration_cst += 2.0F;

        GameManager.instance.AddLevel(currentLevel);
    }

    public void LevelUp5()
    {
        currentLevel++;
        currentGold -= extoLevelup[currentLevel - 1];


        // 성능 향상 코드
        ppb.engine_max_rpm += 400f;
        ppb.acceleration_cst += 3.0F;

        GameManager.instance.AddLevel(currentLevel);
    }
    public void LevelUp6()
    {
        currentLevel++;
        currentGold -= extoLevelup[currentLevel - 1];


        // 성능 향상 코드
        ppb.engine_max_rpm += 400f;
        ppb.acceleration_cst += 3.0F;

        GameManager.instance.AddLevel(currentLevel);
    }

    public bool ClearGame()
    {
        if (isclear == false)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool Die()
    {
        if(islive ==true)
        {
            return true;
        }
        else
        {
            return false;
          
        }
    }
}
