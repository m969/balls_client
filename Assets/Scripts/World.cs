﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public GameObject mainAvatarPrefab;
    public GameObject avatarPrefab;
    public GameObject foodPrefab;


    // Start is called before the first frame update
    void Start()
    {
        KBEngine.Event.registerOut("OnMainAvatarEnterWorld", this, "OnMainAvatarEnterWorld");
        KBEngine.Event.registerOut("OnEnterWorld", this, "OnEnterWorld");
        KBEngine.Event.registerOut("OnLeaveWorld", new System.Action<KBEngine.Entity>(OnLeaveWorld));
        KBEngine.Event.registerOut("OnMoveSpeedChanged", new System.Action<KBEngine.Entity>(OnMoveSpeedChanged));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMainAvatarEnterWorld(KBEngine.Entity entity)
    {
        Debug.Log("World:OnMainAvatarEnterWorld");
        var avatarObj = Instantiate(mainAvatarPrefab);
        entity.renderObj = avatarObj;
        avatarObj.GetComponent<AvatarView>().avatar = entity as Avatar;
        avatarObj.GetComponent<AvatarView>().speed = (entity as Avatar).moveSpeed;
    }

    public void OnEnterWorld(KBEngine.Entity entity)
    {
        Debug.Log("World:OnEnterWorld " + entity.className + " " +  entity.id);
        GameObject entityObj = null;
        if (entity.className == "Avatar")
        {
            entityObj = Instantiate(avatarPrefab);
            entityObj.GetComponent<AvatarView>().avatar = entity as Avatar;
            entityObj.GetComponent<AvatarView>().speed = (entity as Avatar).moveSpeed;
        }
        else
        {
            entityObj = Instantiate(foodPrefab);
            entityObj.transform.position = new Vector3(entity.position.x, entity.position.z, entityObj.transform.position.z);
        }
        entity.renderObj = entityObj;
    }

    public void OnLeaveWorld(KBEngine.Entity entity)
    {
        Debug.Log("World:OnLeaveWorld " + entity.className + " " + entity.id);
        Destroy(entity.renderObj as GameObject);
    }

    public void OnMoveSpeedChanged(KBEngine.Entity entity)
    {
        Debug.Log("World:OnMoveSpeedChanged " + (entity as Avatar).moveSpeed + " " + entity.className + " " + entity.id);
        if (entity.renderObj == null)
            return;
        (entity.renderObj as GameObject).GetComponent<AvatarView>().speed = (entity as Avatar).moveSpeed;
    }
}
