using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//进入战斗 需要处理的逻辑
public class FightEnter : FightUnitBase
{
    public override void Init()
    {
        //地图初始化
        GameApp.MapManager.Init();
        //进入战斗
        GameApp.FightWorldManager.EnterFight();
    }
}
