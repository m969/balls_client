using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KBEngine;

public class Avatar : AvatarBase
{
    public override void __init__()
    {
        base.__init__();
        Debug.Log("Avatar:__init__");
        if (isPlayer())
        {
            KBEngine.Event.registerIn("updatePlayer", this, "updatePlayer");
            KBEngine.Event.registerIn("sendChat", this, "sendChat");
        }
    }

    public override void onMoveSpeedChanged(float oldValue)
    {
        base.onMoveSpeedChanged(oldValue);
        KBEngine.Event.fireOut("OnMoveSpeedChanged", this);
    }

    public override void onEnterSpace()
    {
        base.onEnterSpace();
        Debug.Log("Avatar:onEnterSpace");
    }

    public override void onEnterWorld()
    {
        base.onEnterWorld();
        Debug.Log("Avatar:onEnterWorld");
        if (isPlayer())
        {
            KBEngine.Event.fireOut("OnMainAvatarEnterWorld", this);
        }
        else
        {
            KBEngine.Event.fireOut("OnEnterWorld", this);
        }
    }

    public virtual void updatePlayer(float x, float y, float z, float yaw)
    {
        position.x = x;
        position.y = y;
        position.z = z;

        direction.z = yaw;
    }

    public virtual void sendChat(string chatContent)
    {
        Debug.Log("Avatar:sendChat chatContent=" + chatContent);
        baseEntityCall.sendChat(chatContent);
    }

    public override void recieveChat(string arg1)
    {
        Debug.Log("Avatar:recieveChat arg1=" + arg1);
        KBEngine.Event.fireOut("recieveChat", arg1);
    }
}
