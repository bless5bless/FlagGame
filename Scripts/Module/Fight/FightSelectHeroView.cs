using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//选择英雄面板
public class FightSelectHeroView : BaseView
{
    protected override void OnAwake()
    {
        base.OnAwake();
        Find<Button>("bottom/startBtn").onClick.AddListener(OnFightBtn);
    }

    //选完英雄开始进入到玩家回合
    private void OnFightBtn()
    {
        //如果一个英雄都没选 要提示玩家 选择 这里没有对应的提示界面 自己拓展
        if(GameApp.FightWorldManager.heros.Count == 0)
        {
            Debug.Log("没有选择英雄");
        }
        else
        {
            GameApp.ViewManager.Close(ViewId);//关闭当前选英雄界面

            //  切换到玩家回合
            GameApp.FightWorldManager.ChangeState(GameState.Player);
        }
    }

    public override void Open(params object[] args)
    {
        base.Open(args);

        GameObject prefabObj = Find("bottom/grid/item");

        Transform gridTf = Find("bottom/grid").transform;

        for (int i = 0; i < GameApp.GameDataManager.heros.Count; i++)
        {
            Dictionary<string,string> data = GameApp.ConfigManager.GetConfigData("player").GetDataById(GameApp.GameDataManager.heros[i]);
            
            GameObject obj = Object.Instantiate(prefabObj,gridTf);

            obj.SetActive(true);

            HeroItem item = obj.AddComponent<HeroItem>();
            item.Init(data);
        }
    }
}
