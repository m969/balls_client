using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatPanel : MonoBehaviour
{
    public Text chatText;
    private string _chatContent;

    public string chatContent
    {
        set
        {
            _chatContent = value;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        KBEngine.Event.registerOut("recieveChat", new System.Action<string>(RecieveChat));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendChat()
    {
        print("SendChat:_chatContent=" + _chatContent);
        KBEngine.Event.fireIn("sendChat", _chatContent);
    }

    public void RecieveChat(string chatContent)
    {
        print("RecieveChat:chatContent=" + chatContent);
        chatText.text += "\n" + chatContent;
    }
}
