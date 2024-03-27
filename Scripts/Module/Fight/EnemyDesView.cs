using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDesView : BaseView
{
    public override void Open(params object[] args)
    {
        base.Open(args);
        Enemy enemy = args[0] as Enemy;
        Find<Image>("bg/icon").SetIcon(enemy.data["Icon"]);
        Find<Image>("bg/hp/fill").fillAmount = (float)enemy.CurHp / (float)enemy.MaxHp;
        Find<Text>("bg/hp/txt").text = $"{enemy.CurHp}/{enemy.MaxHp}";
        Find<Text>("bg/atkTxt/txt").text = enemy.Attack.ToString();
        Find<Text>("bg/StepTxt/txt").text = enemy.Step.ToString();
    }
}
