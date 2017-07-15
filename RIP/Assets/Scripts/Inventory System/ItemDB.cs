using System.Collections.Generic;
using System;
using UnityEngine;

public class ItemDB : MonoBehaviour {
    private void Awake() {
        if (db == null)
            db = this;
    }

    public static ItemDB db;
    public List<Item> items = new List<Item> {
        new Item() { id = -1}
    };

    public Item FetchItemByID(int id) {
        for (int i = 0; i < items.Count; i++) {
            if (items[i].id == id)
                return new Item() { Data = items[i].Data };
        }
        return null;
    }
}
