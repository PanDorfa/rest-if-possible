using System;
using UnityEngine;
[Serializable]
public struct AttributeF {
    [SerializeField]
    float max;
    [SerializeField]
    float current;

    public bool HaveCeiling;
    public float Max {
        get { return max; }
        set { max = value; }
    }
    public float Current {
        get { return current; }
        set {
            current = value;
            if (HaveCeiling && current > max) current = max;
        }
    }
}
