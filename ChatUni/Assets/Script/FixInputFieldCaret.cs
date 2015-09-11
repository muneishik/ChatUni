using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class FixInputFieldCaret : MonoBehaviour, ISelectHandler
{
    public RectTransform caretTransform;

    bool isUpdate = false;
    InputField ipFld;
    GameObject go;

    public void OnSelect(BaseEventData eventData)
    {
        ipFld = gameObject.GetComponent<InputField>();
        if (ipFld != null)
        {
            isUpdate = true;
            Debug.Log(ipFld.caretPosition);
        }
    }

    void Update()
    {
        if (isUpdate && go == null)
        {
            go = GameObject.Find("InputField Input Caret");
        }
        else if(isUpdate && caretTransform == null)
        {
            //caretが表示されない問題の対応.
            Image image = go.AddComponent<Image>();
            caretTransform = go.GetComponent<RectTransform>();
            //if (caretTransform != null)
            //    caretTransform.anchoredPosition = new Vector2(0, -45);  //調整
        }
    }
}