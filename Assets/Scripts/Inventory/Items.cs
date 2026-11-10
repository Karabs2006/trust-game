using UnityEngine;

public abstract class Item : ScriptableObject
{
    //Main class for items
    public string itemName;
    public Sprite icon;
    public int inventorySlots;
    public int itemIndex;
    public string inventoryGroup;
    public string miniInvSubGroup;
    public abstract void Use();
}