using UnityEngine;
using System.Collections;
/// <summary>
/// Singleton mono behaviour.
/// </summary>
/// <remarks>
/// このジェネリッククラスを継承するとシングルトンになる。
/// Managerクラスのようなインスタンスを一つしか存在させない場合に使う。
/// 参考URL : 
/// http://naichilab.blogspot.jp/2013/11/unitymanager.html
/// </remarks>
public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
	/// <summary>
	/// インスタンス変数 (Singleton)
	/// </summary>
	/// <remarks>
	/// 継承クラスのインスタンスになる。
	/// </remarks>
	private static T instance;

	/// <summary>
	/// DontDestroyフラグ
	/// </summary>
	/// <remarks>
	/// スクリプトをアタッチしたGameObjectをDontDestroy状態にするかのフラグ
	/// </remarks>
	[SerializeField]
	bool dontDestroyOnLoad;

	/// <summary>
	/// Instanceプロパティ
	/// </summary>
	/// <remarks>
	/// 型を確認し、インスタンス変数を返す。
	/// </remarks>
	public static T Instance
	{
		get
		{
			if (instance == null)
			{
				instance = (T)FindObjectOfType(typeof(T));
				if (instance == null)
				{
					Debug.Log(typeof(T) + "is noting");
				}
			}
			return instance;
		}
	}

	/// <summary>
	/// Awakeの仮想関数
	/// 継承先ではオーバーライドして使う。
	/// </summary>
	/// <remarks>
	/// override void Awake()
	/// {
	/// 	処理
	/// }
	/// </remarks>
	protected virtual void Awake()
	{
		CheckInstance();
	}

	/// <summary>
	/// インスタンスされているか確認。
	/// DontDestroyフラグを付けるとここで処理される。
	/// </summary>
	/// <returns>bool値(成功→true,失敗→false)</returns>
	/// <remarks>
	/// (this).CheckInstance();
	/// </remarks>
	protected virtual bool CheckInstance()
	{
		if (this == Instance)
		{
			if (dontDestroyOnLoad) DontDestroyOnLoad(this.gameObject);
			return true;
		}
		Destroy(this.gameObject);
		return false;
	}
}