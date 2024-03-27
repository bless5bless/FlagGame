using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 技能帮助类
/// </summary>
public static class SkillHelper
{
    /// <summary>
    /// 目标是否在技能的区域范围内
    /// </summary>
    /// <param name="skill"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static bool IsModelInSkillArea(this ISkill skill,ModelBase target)
    {
        ModelBase current = (ModelBase)skill;
        if(current.GetDis(target) <= skill.skillPro.AttackRange)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// 获得技能的作用目标
    /// </summary>
    /// <param name="skill"></param>
    /// <returns></returns>
    public static List<ModelBase> GetTarget(this ISkill skill)
    {
        //0.以鼠标指向的目标为目标
        //1.在攻击范围内的所有目标
        //2.在攻击范围内的英雄的目标
        switch (skill.skillPro.Target)
        {
            case 0:
                return GetTarget_0(skill);
            case 1:
                return GetTarget_1(skill);
            case 2:
                return GetTarget_2(skill);
        }
        return null;
    }

    //0.以鼠标指向的目标为目标
    public static List<ModelBase> GetTarget_0(ISkill skill)
    {
        List<ModelBase> results = new List<ModelBase>();
        Collider2D col = Tools.ScreenPointToRay2D(Camera.main, Input.mousePosition);
        if(col != null)
        {
            ModelBase target = col.GetComponent<ModelBase>();
            if (target != null)
            {
                //技能的目标类型 跟 技能指向的目标类型要跟配置表一致
                if(skill.skillPro.TargetType == target.Type)
                {
                    results.Add(target);
                }
            }
        }

        return results;
    }

    //1.在攻击范围内的所有目标
    public static List<ModelBase> GetTarget_1(ISkill skill)
    {
        List<ModelBase> results = new List<ModelBase>();
        for (int i = 0; i < GameApp.FightWorldManager.heros.Count; i++)
        {
            //找到在技能范围内的目标
            if (skill.IsModelInSkillArea(GameApp.FightWorldManager.heros[i]))
            {
                results.Add(GameApp.FightWorldManager.heros[i]);
            }
        }
        for (int i = 0; i < GameApp.FightWorldManager.enemys.Count; i++)
        {
            //找到在技能范围内的目标
            if (skill.IsModelInSkillArea(GameApp.FightWorldManager.enemys[i]))
            {
                results.Add(GameApp.FightWorldManager.enemys[i]);
            }
        }

        return results;
    }

    //2.在攻击范围内的英雄的目标
    public static List<ModelBase> GetTarget_2(ISkill skill)
    {
        List<ModelBase> results = new List<ModelBase>();
        for (int i = 0; i < GameApp.FightWorldManager.heros.Count; i++)
        {
            //找到在技能范围内的目标
            if (skill.IsModelInSkillArea(GameApp.FightWorldManager.heros[i]))
            {
                results.Add(GameApp.FightWorldManager.heros[i]);
            }
        }

        return results;
    }
}
