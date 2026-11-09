using UnityEngine;
using System.Collections.Generic;

public static class ItemLists 
{
    public static List<Item> staticTrunkItems = new List<Item>();
    public static List<Item> staticMiniItems = new List<Item>();
    
    public static void AddMini(Item item)
    {
        staticMiniItems.Add(item);
    }

    public static void AddTrunk(Item item)
    {
        staticTrunkItems.Add(item);
    }
}
