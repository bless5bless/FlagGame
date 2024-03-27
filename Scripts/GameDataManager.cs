using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//游戏数据管理器(存储玩家基本的游戏信息)
public class GameDataManager 
{
    public List<int> heros;//英雄集合

    public int Money;//金币？
    public GameDataManager()
    {
        heros = new List<int>();

        //默认三个英雄的id 预先存起来
        heros.Add(10001);
        heros.Add(10002);
        heros.Add(10003);
    }
}
