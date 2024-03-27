using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敌人移动指令
/// </summary>
public class AiMoveCommand : BaseCommand
{
    Enemy enemy;
    _BFS bfs;
    List<_BFS.Point> paths;
    _BFS.Point current;
    int pathIndex;
    ModelBase target;
    public AiMoveCommand(Enemy enemy) : base(enemy)
    {
        this.enemy = enemy;
        bfs = new _BFS(GameApp.MapManager.RowCount,GameApp.MapManager.ColCount);
        paths = new List<_BFS.Point>();
    }

    public override void Do()
    {
        base.Do();

        target = GameApp.FightWorldManager.GetMinDisHero(enemy);//获得最近的英雄

        if(target == null)
        {
            //没有目标了
            IsFinish = true;
        }
        else
        {
            paths = bfs.FindMinPath(this.enemy,this.enemy.Step,target.RowIndex,target.ColIndex);

            if(paths == null)
            {
                //没路 这里可以随机一个点做移动
                IsFinish = true;
            }
            else
            {
                //将当前敌人的位置设置成null 可移动
                GameApp.MapManager.ChangeBlockType(this.enemy.RowIndex,this.enemy.ColIndex,BlockType.Null);
            }
        }
    }

    public override bool Update(float dt)
    {
        if(paths.Count == 0)
        {
            return base.Update(dt);
        }
        else
        {
            current = paths[pathIndex];
            if(model.Move(current.RowIndex,current.ColIndex,dt * 5) == true)
            {
                pathIndex++;
                if(pathIndex > paths.Count - 1)
                {
                    enemy.PlayAni("idle");
                    GameApp.MapManager.ChangeBlockType(enemy.RowIndex,enemy.ColIndex,BlockType.Obstacle);
                    return true;
                }
            }
        }

        model.PlayAni("move");

        return false;
    }
}
