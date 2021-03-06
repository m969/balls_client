﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KBEngine;

public class Food : FoodBase
{
    public override void __init__()
    {
        base.__init__();
        Debug.Log("Food:__init__");
    }

    public override void onEnterWorld()
    {
        base.onEnterWorld();
        KBEngine.Event.fireOut("OnEnterWorld", this);
    }

    public override void onLeaveWorld()
    {
        base.onLeaveWorld();
        KBEngine.Event.fireOut("OnLeaveWorld", this);
    }

    public override void onDestroy()
    {
        base.onDestroy();
    }
}
