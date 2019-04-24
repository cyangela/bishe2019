using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RWVR_ControllerManager : MonoBehaviour {

    public static RWVR_ControllerManager Instance;

    public RWVR_InteractionController leftController;
    public RWVR_InteractionController rightController;

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// 用于判断是否某只手柄中正在抓着一个组件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public bool AnyControllerIsInteractingWith<T>()
    {
        if (leftController.InteractionObject && leftController.InteractionObject.GetComponent<T>() != null)
        {
            return true;
        }

        if (rightController.InteractionObject && rightController.InteractionObject.GetComponent<T>() != null)
        {
            return true;
        }

        return false;
    }
}
