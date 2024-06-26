﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace PowerThreadPool.Groups
{
    public class Group
    {
        internal string _groupName;
        internal PowerPool _powerPool;
        internal Group(PowerPool powerPool, string groupName)
        {
            _powerPool = powerPool;
            _groupName = groupName;
        }

        /// <summary>
        /// Wait until all the work belonging to the group is done.
        /// </summary>
        public void Wait()
        {
            _powerPool.Wait(_powerPool.GetGroupMemberList(_groupName));
        }

        /// <summary>
        /// Wait until all the work belonging to the group is done.
        /// </summary>
        /// <returns></returns>
        public async Task WaitAsync()
        {
            await Task.Run(() =>
            {
                Wait();
            });
        }

        /// <summary>
        /// Stop all the work belonging to the group.
        /// </summary>
        /// <param name="forceStop">Call Thread.Interrupt() for force stop</param>
        /// <returns>Return false if no thread running</returns>
        public List<string> Stop(bool forceStop = false)
        {
            return _powerPool.Stop(_powerPool.GetGroupMemberList(_groupName), forceStop);
        }

        /// <summary>
        /// Pause all the work belonging to the group.
        /// </summary>
        /// <returns>Return a list of IDs for work that doesn't exist</returns>
        public List<string> Pause()
        {
            return _powerPool.Pause(_powerPool.GetGroupMemberList(_groupName));
        }

        /// <summary>
        /// Resume all the work belonging to the group.
        /// </summary>
        /// <returns>Return a list of IDs for work that doesn't exist</returns>
        public List<string> Resume()
        {
            return _powerPool.Resume(_powerPool.GetGroupMemberList(_groupName));
        }

        /// <summary>
        /// Cancel all the work belonging to the group.
        /// </summary>
        /// <returns>Return a list of IDs for work that doesn't exist</returns>
        public List<string> Cancel()
        {
            return _powerPool.Cancel(_powerPool.GetGroupMemberList(_groupName));
        }
    }
}
