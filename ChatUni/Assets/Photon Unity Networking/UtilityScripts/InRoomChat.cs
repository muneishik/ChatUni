using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PhotonView))]
public class InRoomChat : Photon.MonoBehaviour 
{
	//UI.
	[SerializeField] RectTransform chatPanel;
	[SerializeField] InputField inputField;
	[SerializeField] Button button;
	[SerializeField] RectTransform content;
	//Prefab.
	[SerializeField] RectTransform prefab = null;
	public EventSystem eventSystem;
	public Action onChangeInputActive;

	public RandomMatchmaker randomMatchmaker;

    public bool IsVisible = true;
    public List<string> messages = new List<string>();
    private string inputLine = "";
    private Vector2 scrollPos = Vector2.zero;
	private bool isOnce = false;
	private bool isActiveInputField = false;

    public static readonly string ChatRPC = "Chat";
	DateTime dateTime;

    public void Start()
    {
		OnJoinedChatRoom(false);
    }		
	public void Update()
	{
		if ( !this.IsVisible || PhotonNetwork.connectionStateDetailed != PeerState.Joined )
		{
			return;
		}

		if (!isOnce) 
		{
			OnJoinedChatRoom(true);
			isOnce = true; 
		}

		if (Input.GetKey (KeyCode.Return)) 
		{
			OnClickSendButton();
		}
		this.inputLine = inputField.text;

		if (eventSystem.currentSelectedGameObject == null )
		{
			randomMatchmaker.charaController.isControllable = true;
			//isActiveInputField = false;
			return;
		}

		//TODO:毎フレームの文字列比較を避けたい.
		if( /*isActiveInputField == false &&*/ eventSystem.currentSelectedGameObject.tag == "InputFieldUI")
		{
			randomMatchmaker.charaController.isControllable = false;
			//isActiveInputField = true;
		}
		else
		{
			randomMatchmaker.charaController.isControllable = true;
			//isActiveInputField = false;
		}
			
	}

	void OnJoinedChatRoom(bool isActive)
	{
		chatPanel.gameObject.SetActive (isActive);
	}

    [PunRPC]
    public void Chat(string newLine, PhotonMessageInfo mi)
    {
        string senderName = "anonymous";

        if (mi != null && mi.sender != null)
        {
            if (!string.IsNullOrEmpty(mi.sender.name))
            {
                senderName = mi.sender.name;
            }
            else
            {
				dateTime = DateTime.Now;
				senderName = dateTime.ToString("HH:mm") + " [ID:" + mi.sender.ID + "] " + GameController.Instance.playerName;
            }
        }

        this.messages.Add(senderName +": " + newLine);
    }

    public void AddLine(string newLine)
    {
        this.messages.Add(newLine);
    }

	public void OnClickSendButton()
	{
		//改行文字対策.
		this.inputLine = this.inputLine.Replace("\r", "").Replace("\n", "");
		if (this.inputLine.Length == 0) 
		{
			this.inputLine = "";
			inputField.text = inputField.text.Replace("\r", "").Replace("\n", "");
			return;
		}

		//メッセージを送信.
		this.inputLine = inputField.text;
		this.photonView.RPC("Chat", PhotonTargets.All, this.inputLine);

		//送信したメッセージを画面上に表示.
		var item = GameObject.Instantiate(prefab) as RectTransform;
		item.GetChild(0).GetComponent<Text>().text = this.messages[this.messages.Count-1];
		item.SetParent(content.transform, false);

		this.inputLine = "";
		inputField.text = "";
	}
}
