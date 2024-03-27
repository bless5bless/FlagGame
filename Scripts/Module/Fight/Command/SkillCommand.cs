using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

/// <summary>
/// 技能指令
/// </summary>
public class SkillCommand : BaseCommand
{
    ISkill skill;
    public SkillCommand(ModelBase model) : base(model)
    {
        skill = model as ISkill;
    }

    public override void Do()
    {
        base.Do();
        List<ModelBase> results = skill.GetTarget();
        if(results.Count > 0 )
        {
            //有目标
            GameApp.SkillManager.AddSkill(skill,results);//将技能添加到技能管理器
        }
    }

    public override bool Update(float dt)
    {
        if(GameApp.SkillManager.IsRunningSkill() == false )
        {
            model.IsStop = true;
            return true;
        }
        else
        {
            return false;
        }
    }
}
