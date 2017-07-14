using System;
using UnityEngine;
[Serializable]
public struct AttributeI {
    [SerializeField]
    int max;
    [SerializeField]
    int current;

    public bool HaveCeiling;
    public int Max {
        get { return max; }
        set { max = value; }
    }
    public int Current {
        get { return current; }
        set {
            current = value;
            if (HaveCeiling && current > max) current = max;
        }
    }
}
