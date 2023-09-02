﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerThreadPool.Option
{

    public class ThreadOption<TResult>
    {
        public ThreadOption()
        {
        }

        /// <summary>
        /// The maximum amount of time the thread is allowed to run before it is terminated.
        /// </summary>
        public TimeoutOption Timeout { get; set; } = null;

        /// <summary>
        /// The callback function that is called when the thread finishes execution.
        /// </summary>
        public Action<ExecuteResult<TResult>> Callback { get; set; } = null;

        /// <summary>
        /// The priority level of the thread. Higher priority threads are executed before lower priority threads.
        /// </summary>
        public int Priority { get; set; } = 0;

        /// <summary>
        /// A set of threads that this thread depends on. This thread will not start until all dependent threads have completed execution.
        /// </summary>
        public HashSet<string> Dependents { get; set; } = null;
    }

    public class ThreadOption : ThreadOption<object>
    {
        public ThreadOption()
        {
        }
    }
}
