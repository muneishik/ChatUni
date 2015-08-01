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

    public bool IsVisible = true;
    public List<string> messages = new List<string>();
    private string inputLine = "";
    private Vector2 scrollPos = Vector2.zero;
	private bool isOnce = false;

    public static readonly string ChatRPC = "Chat";

    public void Start()
    {
		OnJoinedChatRoom(false);
    }		
	public void Update()
	{
		if (!this.IsVisible || PhotonNetwork.connectionStateDetailed != PeerState.Joined)
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
                senderName = GameController.Instance.playerName /*+ " [ID:" + mi.sender.ID + "]"*/;
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
		this.inputLine = this.inputLine.Replace("\r", "").Replace("\n", "");
		if (this.inputLine.Length == 0) 
		{
			this.inputLine = "";
			inputField.text = inputField.text.Replace("\r", "").Replace("\n", "");
			return;
		}
		this.inputLine = inputField.text;
		this.photonView.RPC("Chat", PhotonTargets.All, this.inputLine);

		var item = GameObject.Instantiate(prefab) as RectTransform;
		item.GetChild(0).GetComponent<Text>().text = this.messages[this.messages.Count-1];
		item.SetParent(content.transform, false);

		this.inputLine = "";
		inputField.text = "";
	}
}
