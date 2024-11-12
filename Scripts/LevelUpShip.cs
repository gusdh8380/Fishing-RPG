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
    private bool isEntered = false; // �谡 ���� �ȿ� �ִ��� ����

    // ����� �� ������ ��� ���
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
        // �谡 ���߾� ���� �� fŰ�� ���� ���ø� �մϴ�.
        if (ppb.engine_rpm == 0 && Input.GetKey(KeyCode.F))
        {
            if (isEntered)
            {
                //���� ����
                if (Random.Range(0.0f, 1.0f) < fishCatchRate * Time.deltaTime)
                {
                    // ������ ���� ��� ȹ�淮 ���
                    int goldPerFish = baseGoldPerFish + extraGoldPerLevel * (currentLevel);

                    // ��� ȹ��
                    GainGold(goldPerFish);

                    //��Ҵٸ� �ܼ��̳� UI�� �̺�Ʈ �ڵ� ����
                    Debug.Log("��Ҵ�!!");
                    Debug.Log("���� ��� : ");
                    Debug.Log(currentGold);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // "Ship" �±׸� ���� ������Ʈ�� ���� �ȿ� ���� ���
        if (other.gameObject.tag == "Point")
        {
            isEntered = true;
        }
        // "Boom" �±׸� ���� ������Ʈ�� �浹�� ���
        if (other.gameObject.tag == "Boom")
        {
            islive = false;
            Die();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        // "Ship" �±׸� ���� ������Ʈ�� �������� ���� ���
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
                Debug.Log("���� ��!");
            }
            else if (ShipLevelUp == 2)
            {
                LevelUp3();
                Debug.Log("���� ��!");
            }
            else if (ShipLevelUp == 3)
            {
                LevelUp4();
                Debug.Log("���� ��!");
            }
            else if (ShipLevelUp == 4)
            {
                LevelUp5();
                Debug.Log("���� ��!");
            }
            else if (ShipLevelUp == 5)
            {
                LevelUp6();
                Debug.Log("���� ��!");
            }
            else if (ShipLevelUp == 6)
            {
                Debug.Log("���� ����");
                isclear = true;
                ClearGame();
            }

        }
    }

    public void LevelUp2()
    {
        currentLevel++;
        currentGold -= extoLevelup[currentLevel - 1];
    

        // ���� ��� �ڵ�
        ppb.engine_max_rpm += 100F;
        ppb.acceleration_cst += 2.0F;

        GameManager.instance.AddLevel(currentLevel);
    }

    public void LevelUp3()
    {
        currentLevel++;
        currentGold -= extoLevelup[currentLevel - 1];


        // ���� ��� �ڵ�
        ppb.engine_max_rpm += 300f;

        GameManager.instance.AddLevel(currentLevel);
    }

    public void LevelUp4()
    {
        currentLevel++;
        currentGold -= extoLevelup[currentLevel - 1];
  

        // ���� ��� �ڵ�
        ppb.engine_max_rpm += 400f;
        ppb.acceleration_cst += 2.0F;

        GameManager.instance.AddLevel(currentLevel);
    }

    public void LevelUp5()
    {
        currentLevel++;
        currentGold -= extoLevelup[currentLevel - 1];


        // ���� ��� �ڵ�
        ppb.engine_max_rpm += 400f;
        ppb.acceleration_cst += 3.0F;

        GameManager.instance.AddLevel(currentLevel);
    }
    public void LevelUp6()
    {
        currentLevel++;
        currentGold -= extoLevelup[currentLevel - 1];


        // ���� ��� �ڵ�
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
