﻿using System;
using System.Threading;
using PowerThreadPool.Collections;
using PowerThreadPool.Options;
using PowerThreadPool.Results;

namespace PowerThreadPool.Works
{
    internal abstract class WorkBase
    {
        internal string ID { get; set; }
        internal Worker Worker { get; set; }
        internal int _executeCount;
        internal int ExecuteCount
        {
            get => _executeCount;
            set => _executeCount = value;
        }
        internal Status Status { get; set; }
        internal AutoResetEvent WaitSignal { get; set; }
        internal bool ShouldStop { get; set; }
        internal ManualResetEvent PauseSignal { get; set; }
        internal bool IsPausing { get; set; }
        internal DateTime QueueDateTime { get; set; }
        internal abstract object Execute();
        internal abstract bool Stop(bool forceStop);
        internal abstract bool Wait();
        internal abstract bool Pause();
        internal abstract bool Resume();
        internal abstract bool Cancel(bool lockWorker);

        /// <summary>
        /// Prevent work theft by other threads after acquiring a Worker.
        /// Prevent the forced termination of works that should not end, caused by the target work ending right after acquiring a Worker.
        /// </summary>
        /// <returns></returns>

        internal abstract void InvokeCallback(PowerPool powerPool, ExecuteResultBase executeResult, PowerPoolOption powerPoolOption);
        internal abstract ExecuteResultBase SetExecuteResult(object result, Exception exception, Status status);
        internal abstract bool ShouldRetry(ExecuteResultBase executeResult);
        internal abstract bool ShouldImmediateRetry(ExecuteResultBase executeResult);
        internal abstract bool ShouldRequeue(ExecuteResultBase executeResult);
        internal abstract string Group { get; }
        internal abstract ThreadPriority ThreadPriority { get; }
        internal abstract bool IsBackground { get; }
        internal abstract int WorkPriority { get; }
        internal abstract TimeoutOption WorkTimeoutOption { get; }
        internal abstract RetryOption RetryOption { get; }
        internal abstract bool LongRunning { get; }
        internal abstract ConcurrentSet<string> Dependents { get; }
    }
}
