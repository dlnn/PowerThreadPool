﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerThreadPool.Option
{

    public class ThreadPoolOption
    {
        public ThreadPoolOption()
        {
        }

        /// <summary>
        /// The maximum number of threads that the thread pool can support.
        /// </summary>
        public int MaxThreads { get; set; } = Environment.ProcessorCount * 2;

        /// <summary>
        /// The option for destroying threads in the thread pool.
        /// </summary>
        public DestroyThreadOption DestroyThreadOption { get; set; } = null;

        /// <summary>
        /// The total maximum amount of time that all threads in the thread pool are permitted to run collectively before they are terminated.
        /// </summary>
        public TimeoutOption Timeout { get; set; } = null;

        /// <summary>
        /// The default maximum amount of time a thread in the pool is allowed to run before it is terminated.
        /// </summary>
        public TimeoutOption DefaultThreadTimeout { get; set; } = null;

        /// <summary>
        /// The default callback function that is called when a thread finishes execution.
        /// </summary>
        public Action<ExecuteResult<object>> DefaultCallback { get; set; } = null;
    }
}
