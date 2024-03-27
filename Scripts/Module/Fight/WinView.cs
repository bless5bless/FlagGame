using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinView : BaseView
{
    protected override void OnStart()
    {
        base.OnStart();
        Find<Button>("bg/okBtn").onClick.AddListener(delegate ()
        {
            //卸载战斗中的资源
            GameApp.FightWorldManager.ReLoadRes();
            GameApp.ViewManager.CloseAll();

            //切换场景
            LoadingModel load = new LoadingModel();
            load.SceneName = "map";
            load.callback = delegate ()
            {
                GameApp.SoundManager.PlayBGM("mapbgm");
                GameApp.ViewManager.Open(ViewType.SelectLevelView);
            };
            Controller.ApplyControllerFunc(ControllerType.Loading,Defines.LoadingScene,load);
        });
    }
}
