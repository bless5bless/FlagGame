using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingModel : BaseModel
{
    public string SceneName;//加载场景名称
    public System.Action callback;//加载完成后回调

    public LoadingModel()
    {

    }
}
