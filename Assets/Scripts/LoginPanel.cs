using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LoginPanel : MonoBehaviour
{
    private string _accountName;
    private string _password;

    public string AccountName
    {
        set
        {
            _accountName = value;
            print("LoginPanel:_accountName=" + _accountName);
        }
    }

    public string Password
    {
        set
        {
            _password = value;
            print("LoginPanel:_password=" + _password);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        KBEngine.Event.registerOut(KBEngine.EventOutTypes.onCreateAccountResult, this, KBEngine.EventOutTypes.onCreateAccountResult);
        KBEngine.Event.registerOut(KBEngine.EventOutTypes.onLoginFailed, this, KBEngine.EventOutTypes.onLoginFailed);
        KBEngine.Event.registerOut("onLoginSuccess", this, "onLoginSuccess");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Login()
    {
        print("LoginPanel:Login " + " _accountName=" + _accountName + " _password=" + _password);
        KBEngine.Event.fireIn(KBEngine.EventInTypes.login, _accountName, _password, new byte[] { });
    }

    public void Register()
    {
        print("LoginPanel:Register " + " _accountName=" + _accountName + " _password=" + _password);
        KBEngine.Event.fireIn(KBEngine.EventInTypes.createAccount, _accountName, _password, new byte[] { });
    }

    public void onCreateAccountResult(UInt16 retcode, byte[] datas)
    {
        print("LoginPanel:onCreateAccountResult " + " retcode=" + retcode + " datas=" + datas);
    }

    public void onLoginFailed(UInt16 retcode)
    {
        print("LoginPanel:onLoginFailed " + " retcode=" + retcode);
    }

    public void onLoginSuccess()
    {
        print("LoginPanel:onLoginSuccess");
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
}
