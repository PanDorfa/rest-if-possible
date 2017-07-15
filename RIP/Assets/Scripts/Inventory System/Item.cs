using System;
using UnityEngine;

[Serializable]
public class Item {
    public Inventory parentInventory;

    public Slot slot;

    public string name, description;
    public int weight, value, id;
    public int count = 1;
    public bool stackable;

    public Sprite sprite;

    public Type effectType;
    public Component effect;

    public object[] Data {
        get {

            return new object[] { name, description, weight, count, value, sprite, id, effectType, effect, stackable};
        }
        set {
            name=(string)value[0];
            description =(string)value[1];
            weight =(int)value[2];
            count =(int)value[3];
            this.value =(int)value[4];
            sprite =(Sprite)value[5];
            id = (int)value[6];
            effectType =(Type)value[7];
            effect = (Component)value[8];
            stackable = (bool)value[9];
        }
    }

    public void OnBegin() { // OnActivate
        if (slot == Slot.Consumable) { // remove from inventory and add effect
            parentInventory.RemoveItem(this);
        }
        else if (slot == Slot.None) { // skip if unusable
            return; 
        }
        else if (parentInventory.activeItems[(int)slot].id == -1) { // equip to slot and add effect
            parentInventory.activeItems[(int)slot] = this;
            parentInventory.RemoveItem(this);
        }
        else { // switch equip in slot and add effect
            parentInventory.DeactivateItem(parentInventory.activeItems[(int)slot]);
            parentInventory.activeItems[(int)slot] = this;
        }

        if (effectType != null) // if effect exists, add it
            effect = parentInventory.parentCharacter.transform.GetChild(0).gameObject.AddComponent(effectType);
    }

    public void OnStop() { // OnDestroy
        UnityEngine.Object.Destroy(effect);
    }

    public enum Slot : int { // enum Slot
        None = -1, // unusable
        Consumable = -2, // consumable
        Armor = 0 // WIP

    }
}

public class effect1 : MonoBehaviour {

}