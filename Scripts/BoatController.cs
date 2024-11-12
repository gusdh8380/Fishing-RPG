using UnityEngine;
using System.Collections;

public class BoatController : MonoBehaviour
{
    public PropellerBoats ship;
    bool forward = true;

    void Update()
    {

        if (Input.GetKey(KeyCode.A))
            ship.RudderLeft();
        if (Input.GetKey(KeyCode.D))
            ship.RudderRight();

        if (forward)// forward가 true일 경우 아래 조건문으로, 즉 앞으로 갈때
        {
            if (Input.GetKey(KeyCode.Space)) //스페이스 바가 눌리면
                ship.ThrottleUp(); //스토틀 값 증가
            else if (Input.GetKey(KeyCode.S))
            {
                ship.ThrottleDown();
                ship.Brake();
            }
        }
        else //뒤로 이동 중
        {
            if (Input.GetKey(KeyCode.S))
                ship.ThrottleUp();
            else if (Input.GetKey(KeyCode.Space))
            {
                ship.ThrottleDown();
                ship.Brake();
            }
        }
        //아무것도 안 눌렸을 때
        if (!Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.S))
            ship.ThrottleDown();

        if (ship.engine_rpm == 0 && Input.GetKeyDown(KeyCode.S) && forward)
        {
            forward = false;
            ship.Reverse();
        }
        else if (ship.engine_rpm == 0 && Input.GetKeyDown(KeyCode.Space) && !forward)
        {
            forward = true;
            ship.Reverse();
        }
    }

}