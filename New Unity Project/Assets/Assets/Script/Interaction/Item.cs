using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactable {

    public string itemName;

    public override void Interact()
    {
        Debug.Log("Interacted with item " + itemName);
    }
}
