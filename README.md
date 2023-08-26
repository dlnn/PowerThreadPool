# PowerThreadPool
Provides a simple and flexible way to manage concurrent tasks through a configurable thread pool. Supports a variety of task queuing methods with optional parameters and callbacks. 

### Getting started
#### Without callback
```csharp
PowerPool powerPool = new PowerPool(new ThreadPoolOption() { MaxThreads = 3 });
powerPool.QueueWorkItem(() => 
{
    // DO SOMETHING
    return result;
});
```
#### With callback
```csharp
PowerPool powerPool = new PowerPool(new ThreadPoolOption() { MaxThreads = 3 });
powerPool.QueueWorkItem(() => 
{
    // DO SOMETHING
    return result;
}, (res) => 
{
    // this callback of thread
    // running result: res.Result
});
```
#### Stop all threads
```csharp
powerPool.Stop();
```
#### Blocks the calling thread until all of the threads terminates.
```csharp
powerPool.Wait();
```

#### API
```csharp
string QueueWorkItem(Action action, Action<ExcuteResult<object>> callBack = null)
```
```csharp
string QueueWorkItem(Action<object[]> action, object[] param, Action<ExcuteResult<object>> callBack = null)
```
```csharp
string QueueWorkItem<T1>(Action<T1> action, T1 param1, Action<ExcuteResult<object>> callBack = null)
```
```csharp
string QueueWorkItem<T1, T2>(Action<T1, T2> action, T1 param1, T2 param2, Action<ExcuteResult<object>> callBack = null)
```
```csharp
string QueueWorkItem<T1, T2, T3>(Action<T1, T2, T3> action, T1 param1, T2 param2, T3 param3, Action<ExcuteResult<object>> callBack = null)
```
```csharp
string QueueWorkItem<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action, T1 param1, T2 param2, T3 param3, T4 param4, Action<ExcuteResult<object>> callBack = null)
```
```csharp
string QueueWorkItem<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> action, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, Action<ExcuteResult<object>> callBack = null)
```
```csharp
string QueueWorkItem<T1, TResult>(Func<T1, TResult> function, T1 param1, Action<ExcuteResult<TResult>> callBack = null)
```
```csharp
string QueueWorkItem<T1, T2, TResult>(Func<T1, T2, TResult> function, T1 param1, T2 param2, Action<ExcuteResult<TResult>> callBack = null)
```
```csharp
string QueueWorkItem<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> function, T1 param1, T2 param2, T3 param3, Action<ExcuteResult<TResult>> callBack = null)
```
```csharp
string QueueWorkItem<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> function, T1 param1, T2 param2, T3 param3, T4 param4, Action<ExcuteResult<TResult>> callBack = null)
```
```csharp
string QueueWorkItem<T1, T2, T3, T4, T5, TResult>(Func<T1, T2, T3, T4, T5, TResult> function, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, Action<ExcuteResult<TResult>> callBack = null)
```
```csharp
string QueueWorkItem<TResult>(Func<TResult> function, Action<ExcuteResult<TResult>> callBack = null)
```
```csharp
string QueueWorkItem<TResult>(Func<object[], TResult> function, object[] param, Action<ExcuteResult<TResult>> callBack = null)
```
```csharp
void Wait()
```
```csharp
async Task WaitAsync()
```
```csharp
void Stop()
```
```csharp
async Task StopAsync()
```
```csharp
void PauseIfRequested()
```
```csharp
public void Pause()
```
```csharp
void Resume(bool resumeThreadPausedById = false)
```
```csharp
void Pause(string id)
```
```csharp
void Resume(string id)
```