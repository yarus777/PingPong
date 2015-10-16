using UnityEngine;

public enum WhatText
{
    LanguageValue,
	PointsText,
	MusicText,
	SoundText,
	CurrentScoreTitle,
	BestScoreTitle
	
}

public enum Language {
	English,
	Russian
}

public static class Texts
{
	private static string[,] value = {
        {"English","Русский"},
		{"Points","Очки"},
		{"Music","Музыка"},
		{"Sounds","Звуки"},
		{"Score","Счет"},
		{"Best","Лучший"},
	};

	public static string GetText (WhatText what)
	{
		return value [(int)what, (int)LangItem.language];
	}
}

public class LangItem : MonoBehaviour {
	public WhatText whatIsThis;
	public string textBefore, textAfter;
	public UnityEngine.UI.Text textUI;
	public static Language language {
		get {
			switch (Application.systemLanguage) {
			case SystemLanguage.Russian:
				return Language.Russian;
			default:
				return Language.English;
			}
		}
	}
	private static System.Collections.Generic.List<LangItem> all;
	public static void UpdateAll () {
		if (all != null) {
			foreach (LangItem item in all) {
				item.Change ();
			}
		}
	}
	private static void AddToAll (LangItem item) {
		if (all == null) {
			all = new System.Collections.Generic.List<LangItem> ();
		}
		all.Add (item);
	}
	private static void RemoveFromAll (LangItem item) {
		if (all != null) {
			all.Remove (item);
		}
	}

	public void SetText (WhatText what) {
		whatIsThis = what;
		Change ();
	}

	void Change () {
		if (textUI == null) {
			textUI = this.GetComponent<UnityEngine.UI.Text> ();
		}
		textUI.text = textBefore+Texts.GetText(whatIsThis)+textAfter;
	}

	void OnEnable ()
	{
		AddToAll (this);
		Change ();
	}
	void OnDisable () {
		RemoveFromAll (this);
	}
}