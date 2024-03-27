using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPoint : MonoBehaviour
{
    public int LevelId;//设置关卡Id

    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameApp.MsgCenter.PostEvent(Defines.ShowLevelDesEvent, LevelId);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameApp.MsgCenter.PostEvent(Defines.HideLevelDesEvent);
    }
}
