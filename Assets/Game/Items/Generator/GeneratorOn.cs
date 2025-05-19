using UnityEngine;

public class GeneratorOn : MonoBehaviour
{
    private bool ThePlayerIsNearby;

    void Start()
    {
        ThePlayerIsNearby = false;
        InventoryManager.slotChanged += OnSlotChanged;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Pistol Idle")
        {
            ThePlayerIsNearby = true;
            Debug.Log("����� ����� �����, ������ ���������� ��������");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Pistol Idle")
        {
            ThePlayerIsNearby = false;
            Debug.Log("����� ����� �� ���� ����������");
        }
    }
    void OnSlotChanged(InventorySlot slot)
    {
        if (ThePlayerIsNearby)
        {
            GameObject Child = transform.Find("battery (1)").gameObject;
            if (Child != null)
            {
                Debug.Log("����� ������");
                slot.OnRemoveButton();
            }
            else
            {
                Debug.Log("�� ����� ������");
            }
            Child.SetActive(true);
            InventoryManager.OnTasksGeneratorEvent();
        }
        else
        {
            Debug.Log("����� �� ����� � �����������");
        }
    }
}
