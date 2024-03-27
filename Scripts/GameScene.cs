using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//继承MonoBehaviour的脚本 需要挂载游戏物体 跳转场景后当前脚本物体不删除
public class GameScene : MonoBehaviour
{
    public Texture2D mouseTxt;//鼠标图片
    float dt;
    private static bool isLoaded = false;
    private void Awake()
    {
        if(isLoaded == true)
        {
            Destroy(gameObject);
        }
        else
        {
            isLoaded = true;
            DontDestroyOnLoad(gameObject);
            GameApp.Instance.Init();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //设置鼠标样式
        Cursor.SetCursor(mouseTxt, Vector2.zero, CursorMode.Auto);

        //注册配置表
        RegisterConfigs();

        //加载配置表
        GameApp.ConfigManager.LoadAllConfigs();

        //测试配置表
        ConfigData tempData =  GameApp.ConfigManager.GetConfigData("enemy");
        string name = tempData.GetDataById(10001)["Name"];
        Debug.Log(name);

        //播放背景音乐
        GameApp.SoundManager.PlayBGM("login");

        RegisterModule();//注册游戏中的控制器

        InitModule();
    }

    //注册控制器
    void RegisterModule()
    {
        GameApp.ControllerManager.Register(ControllerType.GameUI,new GameUIController());
        GameApp.ControllerManager.Register(ControllerType.Game,new GameController());
        GameApp.ControllerManager.Register(ControllerType.Loading,new LoadingController());
        GameApp.ControllerManager.Register(ControllerType.Level,new LevelController());
        GameApp.ControllerManager.Register(ControllerType.Fight,new FightController());
    }

    //执行所有控制器初始化
    void InitModule()
    {
        GameApp.ControllerManager.InitAllModule();
    }

    //注册配置表
    void RegisterConfigs()
    {
        GameApp.ConfigManager.Register("enemy", new ConfigData("enemy"));
        GameApp.ConfigManager.Register("level", new ConfigData("level"));
        GameApp.ConfigManager.Register("option", new ConfigData("option"));
        GameApp.ConfigManager.Register("player", new ConfigData("player"));
        GameApp.ConfigManager.Register("role", new ConfigData("role"));
        GameApp.ConfigManager.Register("skill", new ConfigData("skill"));

    }

    // Update is called once per frame
    void Update()
    {
        dt = Time.deltaTime;
        GameApp.Instance.Update(dt);
    }
}
