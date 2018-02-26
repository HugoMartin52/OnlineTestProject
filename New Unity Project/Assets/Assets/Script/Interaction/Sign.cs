using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : Interactable {

    public string message = "Towards X";

    public override void Interact()
    {
        Debug.Log(message);
    }

}
