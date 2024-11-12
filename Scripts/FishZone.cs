using UnityEngine;

public class FishZone : MonoBehaviour
{
    public bool isEntered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ship")  // "Ship" �±״� �� ������Ʈ�� �������ּ���.
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
