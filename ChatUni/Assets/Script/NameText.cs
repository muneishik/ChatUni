using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NameText : MonoBehaviour 
{
	public Transform playerTransform;
	public Camera mainCamera;

	public RectTransform parentRectTrans;
	[SerializeField] RectTransform thisRectTransform;
	
	[SerializeField] Text nameText;

	public Vector3 offset = Vector3.zero;
	
	public string nameStr = string.Empty;

	// Use this for initialization
	public void Initialize (string name) 
	{
		nameText.text = name;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (nameText.text.Length == 0) return;
		UpdateUiLocalPosFromTargetPos();
	}

	void UpdateUiLocalPosFromTargetPos()
	{
		var screenPos = mainCamera.WorldToScreenPoint(playerTransform.position + offset);
		var localPos = Vector2.zero;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRectTrans, screenPos, mainCamera, out localPos);
		thisRectTransform.localPosition = localPos;
	}
}
