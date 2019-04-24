using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RWVR_InteractionObject : MonoBehaviour {

    protected Transform cachedTransform;
    [HideInInspector]
    public RWVR_InteractionController currentController;

    /// <summary>
    /// 按下扳机键，将当前控制器赋值给currentController
    /// </summary>
    /// <param name="controller"></param>
    public virtual void OnTriggerWasPressed(RWVR_InteractionController controller)
    {
        currentController = controller;
    }

    /// <summary>
    /// 按住扳机键
    /// </summary>
    /// <param name="controller"></param>
    public virtual void OnTriggerIsBeingPressed(RWVR_InteractionController controller)
    {
    }

    /// <summary>
    /// 松开扳机键，将currentController赋空
    /// </summary>
    /// <param name="controller"></param>
    public virtual void OnTriggerWasReleased(RWVR_InteractionController controller)
    {
        currentController = null;
    }

    /// <summary>
    /// 初始化，校正标签
    /// </summary>
    public virtual void Awake()
    {
        cachedTransform = transform;
        if (!gameObject.CompareTag("InteractionObject")) 
        {
            Debug.LogWarning("This InteractionObject does not have the correct tag, setting it now.", gameObject); 
            gameObject.tag = "InteractionObject"; 
        }
    }


    public bool IsFree()
    {
        return currentController == null;
    }


    public virtual void OnDestroy()
    {
        if (currentController)
        {
            OnTriggerWasReleased(currentController);
        }
    }
}
