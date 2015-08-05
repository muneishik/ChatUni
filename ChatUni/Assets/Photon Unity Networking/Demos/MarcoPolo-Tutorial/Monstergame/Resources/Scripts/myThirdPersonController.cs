using UnityEngine;
using System.Collections;

public class myThirdPersonController : ThirdPersonController
{
    // This class replaces the JS version of the same name for this tutorial.
    
    // Actually, the ThirdPersonController works (more or less) the same way as it's JS counterpart
    // but it's much easier to integrate being in C# as well (no need to move files around).

    // Extending the ThirdPersonController into "myThirdPersonController" make sure it uses the same name as in Tutorial.
    
    // Please bear with us for this little fake.
	
	public string playerName = string.Empty;
	public Camera mainCamera = null;
	GUIStyle style;
	Vector2 offset;

	public void SetOffset()
	{
		style = new GUIStyle();
		style.normal.textColor = Color.white;
		style.fontSize = Screen.width/38;
		offset = style.CalcSize(new GUIContent(playerName));
	}

	void OnGUI()
	{
		//���[���h���W����X�N���[�����W���擾
		Vector3 screenPos = mainCamera.WorldToScreenPoint(transform.position);

		if (screenPos.z > 0)
		{
			GUI.Label(new Rect(screenPos.x - offset.x / 2 /*���O�̕��̔������炷*/, Screen.height - screenPos.y, 200, 30), playerName, style);
		}
	}
}
