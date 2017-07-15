using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

[RequireComponent(typeof(Inventory), typeof(Rigidbody2D))]
public class Character_Base : MonoBehaviour {
    public Inventory inventory;

    public AttributeF speed;
    public AttributeI health;

    public AttributeF hunger;
    public AttributeF thirst;
    public AttributeI weight;
    public AttributeI temperature;

    [SerializeField] bool mortal;

    #region Unity
    new public Rigidbody2D rigidbody;

    private void Update() { // testing purposes
        Vector2 dest = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        if (dest!=Vector2.zero)
        Move = (Vector2)transform.position + dest;

        if (Input.GetMouseButtonDown(0)) {
            
            Move = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    IEnumerator moveCoroutine;
    bool moveCoroutineRunning = false;
    public Vector2 Move {
        set {
            if (moveCoroutineRunning) StopCoroutine(moveCoroutine);
            moveCoroutine = UpdatePosition(value);
            StartCoroutine(moveCoroutine);
        }
    }

    IEnumerator UpdatePosition(Vector2 destination) {
        moveCoroutineRunning = true;
        while ((Vector2)transform.position != destination) {
            rigidbody.MovePosition(Vector2.MoveTowards(transform.position, destination, speed.Current * Time.fixedDeltaTime));
            yield return new WaitForFixedUpdate();
        }
        moveCoroutineRunning = false;
        yield break;
    }
    
    #endregion

    private void Awake() {
        inventory = GetComponent<Inventory>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

}
