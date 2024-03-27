using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 命令管理器
/// </summary>
public class CommandManager 
{
    private Queue<BaseCommand> willDoCommandsQueue;//将要执行的命令队列
    private Stack<BaseCommand> unDoStack;//撤销的命令 栈
    private BaseCommand current;//当前所执行的命令

    public CommandManager()
    {
        willDoCommandsQueue = new Queue<BaseCommand>();
        unDoStack = new Stack<BaseCommand>();
    }

    //是否在执行命令
    public bool IsRunningCommand
    {
        get
        {
            return current != null;
        }
    }

    public void AddCommand(BaseCommand cmd)
    {
        willDoCommandsQueue.Enqueue(cmd);//添加到命令队列
        unDoStack.Push(cmd);//添加到撤销栈
    }

    public void Update(float dt)
    {
        if(current ==  null)
        {
            if(willDoCommandsQueue.Count > 0)
            {
                current = willDoCommandsQueue.Dequeue();
                current.Do();
            }
        }
        else
        {
            if(current.Update(dt) == true)
            {
                current = null;
            }
        }
    }

    public void Clear()
    {
        willDoCommandsQueue.Clear();
        unDoStack.Clear();
        current = null;
    }

    //撤销上一个命令
    public void Undo()
    {
        if(unDoStack.Count > 0)
        {
            unDoStack.Pop().UnDo();
        }
    }
}
