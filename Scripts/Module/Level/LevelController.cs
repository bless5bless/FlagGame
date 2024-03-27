using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//关卡控制器
public class LevelController : BaseController
{
    public LevelController():base()
    {
        SetModel(new LevelModel());
        GameApp.ViewManager.Register(ViewType.SelectLevelView, new ViewInfo()
        {
            PrefabName = "SelectLevelView",
            controller = this,
            parentTf = GameApp.ViewManager.canvasTf
        });

        InitModuleEvent();
        InitGlobalEvent();
    }

    public override void Init()
    {
        model.Init();//初始化数据
    }

    public override void InitModuleEvent()
    {
        RegisterFunc(Defines.OpenSelectLevelView, onOpenSelectLevelView);
    }

    //注册全局事件
    public override void InitGlobalEvent()
    {
        GameApp.MsgCenter.AddEvent(Defines.ShowLevelDesEvent, onShowLevelDesCallBack);
        GameApp.MsgCenter.AddEvent(Defines.HideLevelDesEvent, onHideLevelDesCallBack);
    }

    //移除全局事件
    public override void RemoveModuleEvent()
    {
        GameApp.MsgCenter.RemoveEvent(Defines.ShowLevelDesEvent, onShowLevelDesCallBack);
        GameApp.MsgCenter.RemoveEvent(Defines.HideLevelDesEvent, onHideLevelDesCallBack);
    }

    private void onShowLevelDesCallBack(System.Object arg)
    {
        Debug.Log("levelId:" + arg.ToString());

        LevelModel levelModel = GetModel<LevelModel>();
        levelModel.current = levelModel.GetLevel(int.Parse(arg.ToString()));

        GameApp.ViewManager.GetView<SelectLevelView>((int)ViewType.SelectLevelView).ShowLevelDes();
    }

    private void onHideLevelDesCallBack(System.Object arg)
    {
        GameApp.ViewManager.GetView<SelectLevelView>((int)ViewType.SelectLevelView).HideLevelDes();
    }

    private void onOpenSelectLevelView(System.Object[] arg)
    {
        GameApp.ViewManager.Open(ViewType.SelectLevelView, arg);
    }
}
