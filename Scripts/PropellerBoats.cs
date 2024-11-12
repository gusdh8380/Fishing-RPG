using UnityEngine;
using UnityEditor;
#if UNITY_EDITOR
    using UnityEditor.PackageManager;
#endif

public class PropellerBoats : MonoBehaviour
{
    public Transform[] propellers; //프로펠러의 위치와 방향 저장
    public Transform[] rudder;  //러더의 위치와 방향 저장
    private Rigidbody rb; //보트의 물리적 속성 저장
    private LevelUpShip LUB;
    public float engine_rpm { get; private set; }
    float throttle;
    int direction = 1;

    public float propellers_constant; //프로펠러 상수
    public float engine_max_rpm; // 최대 엔진 RPM
    public float acceleration_cst; //가속도 설정
    public float drag; //마찰력

    float angle;

    void Awake() //게임 오브젝트가 활성화 되었을 때, 초기 설정
    {
        rb = GetComponent<Rigidbody>();
        LUB = GetComponent<LevelUpShip>();
        propellers_constant = 50F; //프로펠러 상수
        engine_max_rpm = 800.0F; // 최대 엔진 RPM
        acceleration_cst = 3.0F; //가속도 설정
        drag = 0.01F; //마찰력
    }


    void Update() //프로펠러를 회전시키고, 이 힘을 계산하여 Rigidbody에 적용시킴
    {

        float frame_rpm = engine_rpm * Time.deltaTime; //현재 프레임에서의 RPM 계산
        for (int i = 0; i < propellers.Length; i++)
        { //프로펠러를 회전시키고, 위치에서 힘을 가하는 연산
            propellers[i].localRotation = Quaternion.Euler(propellers[i].localRotation.eulerAngles + new Vector3(0, 0, -frame_rpm));
            rb.AddForceAtPosition(Quaternion.Euler(0, angle, 0) * propellers[i].forward * propellers_constant * engine_rpm, propellers[i].position);
        }
        //드래그를 고려하여 조절판을 감수
        throttle *= (1.0F - drag * 0.001F);
        // 스로틀, 최대 엔진RPM, 방향을 고려하여 엔진 RPM 계산 
        engine_rpm = throttle * engine_max_rpm * direction;

        angle = Mathf.Lerp(angle, 0.0F, 0.02F); //현재 각도를 부드럽게 0으로 변화


        for (int i = 0; i < rudder.Length; i++)
            rudder[i].localRotation = Quaternion.Euler(0, angle, 0);
        if (transform.up.y > 0)
        {
            Quaternion targetRotation = Quaternion.FromToRotation(transform.up, Vector3.up) * rb.rotation;
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, Time.fixedDeltaTime * 2f));
        }
    }

    public void ThrottleUp()//스로틀 값 증가 
    {
        throttle += acceleration_cst * 0.001F;
        if (throttle > 1)
            throttle = 1;
    }

    public void ThrottleDown()
    {
        throttle -= acceleration_cst * 0.001F;
        if (throttle < 0)
            throttle = 0;
    }

    public void Brake()
    {
        throttle *= 0.9F;
    }

    public void Reverse()
    {
        direction *= -1;
    }

    public void RudderRight()
    {
        angle -= 0.9F;
        angle = Mathf.Clamp(angle, -90F, 90F);
    }

    public void RudderLeft()
    {
        angle += 0.9F;
        angle = Mathf.Clamp(angle, -90F, 90F);
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Handles.Label(propellers[0].position, engine_rpm.ToString());
    }
#endif

}