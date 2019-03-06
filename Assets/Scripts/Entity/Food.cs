using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KBEngine;

public class Food : Entity
{
    public override void __init__()
    {
        base.__init__();
        Debug.Log("Food:__init__");
    }
}
