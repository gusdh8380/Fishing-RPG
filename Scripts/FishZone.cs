using UnityEngine;

public class FishZone : MonoBehaviour
{
    public bool isEntered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ship")  // "Ship" 태그는 배 오브젝트에 설정해주세요.
        {
            isEntered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ship")
        {
            isEntered = false;
        }
    }
}
