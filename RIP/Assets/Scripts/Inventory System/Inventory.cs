using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public List<Item> idleItems;
    public List<Item> activeItems;
    public Character_Base parentCharacter;

    public void AddItem(Item itemToAdd) {
        if (itemToAdd.stackable)
            for (int i = 0; i < idleItems.Count; i++)
                if (idleItems[i].id == itemToAdd.id) {
                    idleItems[i].count += itemToAdd.count;
                    parentCharacter.weight.Current += itemToAdd.weight * itemToAdd.count;
                    return;
                }

        itemToAdd.parentInventory = this;
        idleItems.Add(itemToAdd);
        parentCharacter.weight.Current += itemToAdd.weight * itemToAdd.count;
    }
    public void RemoveItem(Item itemToRemove) {
        if (--itemToRemove.count <= 0)
            idleItems.Remove(itemToRemove);
    }
    public void RemoveItem(Item itemToRemove, int count) {
        if ((itemToRemove.count-=count) <= 0)
            idleItems.Remove(itemToRemove);
    }

    public void ActivateItem(Item itemToActivate) {
        itemToActivate.OnBegin();

    }
    public void DeactivateItem(Item itemToDeactivate) {
        AddItem(itemToDeactivate);
        activeItems[activeItems.IndexOf(itemToDeactivate)] = ItemDB.db.items[0];
        itemToDeactivate.OnStop();
    }

    private void Awake() {
        parentCharacter = GetComponent<Character_Base>();

        if (idleItems == null) {
            idleItems = new List<Item>();
        }
        if (activeItems == null) {
            activeItems = new List<Item>();
        }
    }
}
