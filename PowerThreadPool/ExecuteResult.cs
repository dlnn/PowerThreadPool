﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerThreadPool
{
    public enum Status { Succeed, Failed }

    public abstract class ExecuteResultBase
    {
        private string id;
        public string ID { get => id; set => id = value; }

        private Status status;
        public Status Status { get => status; internal set => status = value; }

        private Exception exception;
        public Exception Exception { get => exception; internal set => exception = value; }
        internal abstract void SetExecuteResult(object result, Exception exception, Status status);
        internal abstract object GetResult();
        internal abstract ExecuteResult<object> ToObjResult();
    }
    public class ExecuteResult<TResult> : ExecuteResultBase
    {
        private TResult result;
        public TResult Result { get => result; internal set => result = value; }

        internal ExecuteResult()
        { 
        
        }

        internal override void SetExecuteResult(object result, Exception exception, Status status)
        {
            this.result = (TResult)result;
            this.Exception = exception;
            this.Status = status;
        }

        internal override object GetResult()
        {
            return result;
        }

        internal override ExecuteResult<object> ToObjResult()
        {
            return new ExecuteResult<object>() { Exception = this.Exception, Result = this.Result, ID = this.ID };
        }
    }
}
