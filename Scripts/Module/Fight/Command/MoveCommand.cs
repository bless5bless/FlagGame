using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//移动指令
public class MoveCommand : BaseCommand
{

    private List<AStarPoint> paths;

    private AStarPoint current;
    private int pathIndex;

    //移动前的行列坐标 撤销用
    private int preRowIndex;
    private int preColIndex;

    public MoveCommand(ModelBase model) : base(model)
    {

    }

    public MoveCommand(ModelBase model,List<AStarPoint> paths) : base(model)
    {
        this.paths = paths;
        pathIndex = 0;
    }

    public override void Do()
    {
        base.Do();
        this.preRowIndex = this.model.RowIndex;
        this.preColIndex = this.model.ColIndex;
        //设置当前所占的格子为null
        GameApp.MapManager.ChangeBlockType(this.model.RowIndex,this.model.ColIndex,BlockType.Null);
    }

    public override bool Update(float dt)
    {
        current = this.paths[pathIndex];
        if(this.model.Move(current.RowIndex,current.ColIndex,dt * 5))
        {
            pathIndex++;
            if(pathIndex > paths.Count - 1)
            {
                //到达目的地
                this.model.PlayAni("idle");

                GameApp.MapManager.ChangeBlockType(this.model.RowIndex, this.model.ColIndex, BlockType.Obstacle);

                //显示选项界面
                GameApp.ViewManager.Open(ViewType.SelectOptionView, this.model.data["Event"], (Vector2)this.model.transform.position);

                return true;
            }
        }

        this.model.PlayAni("move");

        return false;
    }

    public override void UnDo()
    {
        base.UnDo();

        //回到之前的位置
        Vector3 pos = GameApp.MapManager.GetBlockPos(preRowIndex, preColIndex);
        pos.z = this.model.transform.position.z;
        this.model.transform.position = pos;
        GameApp.MapManager.ChangeBlockType(this.model.RowIndex, this.model.ColIndex, BlockType.Null);
        this.model.RowIndex = preRowIndex;
        this.model.ColIndex = preColIndex;
        GameApp.MapManager.ChangeBlockType(this.model.RowIndex, this.model.ColIndex, BlockType.Obstacle);
    }
}
