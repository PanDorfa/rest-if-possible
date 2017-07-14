using System;
using System.Collections.Generic;
using UnityEngine;
public class Inventory : MonoBehaviour {
    public List<Item> idleItems;
    public List<Item> activeItems;
    public Character_Base parentCharacter;

    public bool AddItem(Item itemToAdd) {
        throw new NotImplementedException();
    }
    public void RemoveItem(Item itemToRemove) {
        throw new NotImplementedException();

    }
    public void ActivateItem(Item itemToActivate) {
        throw new NotImplementedException();

    }

    private void Awake() {
        parentCharacter = GetComponent<Character_Base>();
    }
}
