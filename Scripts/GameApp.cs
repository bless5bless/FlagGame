using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 统一定义游戏中的管理器，在此进行初始化
/// </summary>
public class GameApp : Singleton<GameApp>
{
    //音频管理器
    public static SoundManager SoundManager;
    //控制器管理器
    public static ControllerManager ControllerManager;
    //视图管理器
    public static ViewManager ViewManager;
    //配置表管理器
    public static ConfigManager ConfigManager;
    //摄像机管理器
    public static CameraManager CameraManager;
    //消息监听
    public static MessageCenter MsgCenter;
    //时间管理器
    public static TimerManager TimerManager;
    //战斗管理器
    public static FightWorldManager FightWorldManager;
    //地图管理器
    public static MapManager MapManager;
    //游戏数据管理器
    public static GameDataManager GameDataManager;
    //用户输入管理器
    public static UserInputManager UserInputManager;
    //命令管理器
    public static CommandManager CommandManager;
    //技能管理器
    public static SkillManager SkillManager;

    public override void Init()
    {
        UserInputManager = new UserInputManager();
        TimerManager = new TimerManager();
        MsgCenter = new MessageCenter();
        CameraManager = new CameraManager();
        SoundManager = new SoundManager();
        ConfigManager = new ConfigManager();
        ControllerManager = new ControllerManager();
        FightWorldManager = new FightWorldManager();
        MapManager = new MapManager();
        ViewManager = new ViewManager();
        CommandManager = new CommandManager();
        GameDataManager = new GameDataManager();
        SkillManager = new SkillManager();
    }

    public override void Update(float dt)
    {
        UserInputManager.Update();
        TimerManager.OnUpdate(dt);
        FightWorldManager.Update(dt);
        CommandManager.Update(dt);
        SkillManager.Update(dt);
    }
}
