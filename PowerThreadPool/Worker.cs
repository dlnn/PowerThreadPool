﻿using System.Threading;
using System;
using PowerThreadPool;
using PowerThreadPool.Option;

public class Worker
{
    private Thread thread;

    private string id;
    public string Id { get => id; set => id = value; }

    private AutoResetEvent runSignal = new AutoResetEvent(false);
    private AutoResetEvent waitSignal = new AutoResetEvent(false);
    private string workID;
    private WorkBase work;
    private bool killFlag = false;

    internal Worker(PowerPool powerPool)
    {
        this.Id = Guid.NewGuid().ToString();
        thread = new Thread(() =>
        {
            while (true)
            {
                runSignal.WaitOne();

                if (killFlag)
                {
                    return;
                }

                thread.Name = work.ID;

                ExecuteResultBase executeResult;
                try
                {
                    object result = work.Execute();
                    executeResult = work.SetExecuteResult(result, null, Status.Succeed);
                }
                catch (ThreadInterruptedException ex)
                { 
                    executeResult = work.SetExecuteResult(null, ex, Status.Failed);
                    Kill();
                }
                catch (Exception ex)
                {
                    executeResult = work.SetExecuteResult(null, ex, Status.Failed);
                }
                executeResult.ID = work.ID;

                powerPool.OneThreadEnd(executeResult);
                work.InvokeCallback(executeResult, powerPool.ThreadPoolOption);

                powerPool.WorkEnd(workID);

                waitSignal.Set();
            }
        });
        thread.Start();
    }

    public void Wait()
    {
        waitSignal.WaitOne();
    }

    public void ForceStop()
    {
        thread.Interrupt();
        thread.Join();
    }

    internal void AssignTask(WorkBase work)
    {
        this.work = work;
        this.workID = work.ID;
        runSignal.Set();
    }

    internal void Kill()
    {
        killFlag = true;
        runSignal.Set();
    }
}