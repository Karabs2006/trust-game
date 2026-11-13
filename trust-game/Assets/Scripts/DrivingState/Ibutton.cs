using UnityEngine;

public class Ibutton : MonoBehaviour
{
    public GameObject inventory;
    public RectTransform inventoryTransform;
    public Vector2 rightSidePosition;
    private bool IisActive;

    public void ShowInventory()
    {
        if (!IisActive)
        {
          inventory.SetActive(true);
        inventoryTransform.anchoredPosition = rightSidePosition;
        IisActive = true;  
        }
        else if (IisActive)
        {
            inventory.SetActive(false);
            IisActive = false;  
        }
        
    }
}
