using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public GameObject avatarPrefab;
    public GameObject foodPrefab;


    // Start is called before the first frame update
    void Start()
    {
        KBEngine.Event.registerOut("OnMainAvatarEnterWorld", this, "OnMainAvatarEnterWorld");
        KBEngine.Event.registerOut("OnEnterWorld", this, "OnEnterWorld");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMainAvatarEnterWorld(KBEngine.Entity entity)
    {
        Debug.Log("World:OnMainAvatarEnterWorld");
        var avatarObj = Instantiate(avatarPrefab);
        entity.renderObj = avatarObj;
        avatarObj.GetComponent<AvatarView>().avatar = entity as Avatar;
    }

    public void OnEnterWorld(KBEngine.Entity entity)
    {
        Debug.Log("World:OnEnterWorld");
        var avatarObj = Instantiate(avatarPrefab);
        entity.renderObj = avatarObj;
        avatarObj.GetComponent<AvatarView>().avatar = entity as Avatar;
    }
}
