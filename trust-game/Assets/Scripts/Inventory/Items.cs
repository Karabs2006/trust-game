using UnityEngine;

public abstract class Item : ScriptableObject
{
    //Main class for items
    public string itemName;
    public Sprite icon;
    public int inventorySlots;

    public abstract void Use();
}