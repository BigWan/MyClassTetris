﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region page define
public enum UIType {
	Normal,
	Fixed,
	Popup,
	None
}

public enum UIMode {
	DoNothing,
	HideOther,
	NeedBack,
	NoNeedBack
}
#endregion
public abstract class PageBase : UnitySingleton<PageBase> {

	[Header("UI设置")]
	public UIType type = UIType.Normal;
	public UIMode mode = UIMode.DoNothing;
	public bool FullScreen = false;

	public object data;

	//private bool isAwake = false;
	// 初始化
	// 添加事件监听
	void Awake(){
        //isAwake = true;
        Debug.Log(Name() + " Initialize");
    }

	// 激活
	public virtual void Show(){
		//if(!isAwake) Initialize();
		gameObject.SetActive(true);
		Debug.Log(Name() + " Show");
		Refresh();
		UIManager.Instance.PopNode(this);
	}

	// 关闭
	public virtual void Hide(){
		gameObject.SetActive(false);
		data = null;
		Debug.Log(Name() + " Hide");
	}
	public virtual void Refresh(){
		Debug.Log(Name() + " Refresh");
	}

	public string Name(){
		return gameObject.name ;
	}


    [ContextMenu("命名GameObject")]
    void RenameObject() {
        gameObject.name = this.GetType().ToString();
    }


    private void Reset() {
        RenameObject();
    }
}
