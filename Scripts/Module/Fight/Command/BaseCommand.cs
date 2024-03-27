using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//命令基类
public class BaseCommand 
{
    public ModelBase model;//命令的对象
    protected bool IsFinish;//是否做完标记

    public BaseCommand()
    {

    }

    public BaseCommand(ModelBase model)
    {
        this.model = model;
        IsFinish = false;
    }

    public virtual bool Update(float dt)
    {
        return IsFinish;
    }

    //执行命令
    public virtual void Do()
    {

    }

    //撤销
    public virtual void UnDo()
    {

    }
}
