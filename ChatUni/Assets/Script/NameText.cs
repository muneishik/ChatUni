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
	Vector2 localPos = Vector2.zero;

	/// <summary>
	/// 初期化は生成時に行う.(RandomMachmaker.cs).
	/// </summary>
	public void Initialize (string name) 
	{
		nameText.text = name;
	}

	//void LateUpdate()
	//{
	//	if (nameText.text.Length == 0) return;
	//	UpdateUiLocalPosFromTargetPos();
	//}

	///// <summary>
	///// キャラの上に名前を表示.
	///// </summary>
	//void UpdateUiLocalPosFromTargetPos()
	//{
	//	Vector3 screenPos = mainCamera.WorldToScreenPoint(playerTransform.position);
	//	screenPos = new Vector3(screenPos.x + Screen.width / 2, screenPos.y + Screen.height / 2, 0);
	//	if (screenPos.x < 0 || screenPos.x >= Screen.width || screenPos.y < 0 || screenPos.y > Screen.height)
	//	{
	//		Debug.Log("out:" + screenPos.x + "," + screenPos.y);
	//		return;
	//	}

	//	Debug.Log("in");
	//	RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRectTrans, screenPos, mainCamera, out localPos);
	//	thisRectTransform.localPosition = localPos + offset;
	//}

	//void LateUpdate()
	//{
	//	if (nameText.text.Length == 0) return;
	//	Vector3 screenPos = mainCamera.WorldToScreenPoint(playerTransform.position);
	//	myTransform.localPosition = new Vector3(screenPos.x - Screen.width / 2, screenPos.y - Screen.height / 2, 0);
	//}

}
