using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NameText : MonoBehaviour 
{
	public Transform playerTransform;
	public Camera mainCamera;

	public RectTransform parentRectTrans;
	[SerializeField] Transform myTransform;
	[SerializeField] RectTransform thisRectTransform;
	[SerializeField] Text nameText;

	public Vector2 offset = Vector2.zero;

	/// <summary>
	/// 初期化は生成時に行う.(RandomMachmaker.cs).
	/// </summary>
	public void Initialize (string name) 
	{
		nameText.text = name;
	}
	
//	void Update () 
//	{
//		if (nameText.text.Length == 0) return;
//		UpdateUiLocalPosFromTargetPos();
//	}
//
//	/// <summary>
//	/// キャラの上に名前を表示.
//	/// </summary>
//	void UpdateUiLocalPosFromTargetPos()
//	{
//		Vector3 screenPos = mainCamera.WorldToScreenPoint(playerTransform.position);
//		Vector2 localPos = Vector2.zero;
//		RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRectTrans, screenPos, mainCamera, out localPos);
//		thisRectTransform.localPosition = localPos + offset;
//	}

	void LateUpdate()
	{
		if (nameText.text.Length == 0) return;
		Vector3 screenPos = mainCamera.WorldToScreenPoint(playerTransform.position);
		myTransform.position = new Vector3 (screenPos.x, screenPos.y, 0);
	}

}
