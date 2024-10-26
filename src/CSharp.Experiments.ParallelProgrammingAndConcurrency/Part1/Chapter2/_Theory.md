# Part 1: Introduction to Threading in .NET

## Chapter 2: Evolution of Multithreaded Programming in .NET

### Evolution

 - .NET framework 1.0: System.Threading.Thread
 - .NET framework 4.0 (C# 4):
   - Generics, lambda expressions, anonymous methods
   - Thread-safe collections (System.Collections.Concurrent)
   - Parallel.For & Parallel.ForEach
   - PLINQ (AsParallel, WithCancellation, WithDegreeOfParallelism)
 - .NET framework 4.5.x (C# 5 & 6):
   - async & await
   - TPL with Task in System.Threading.Tasks
 - .NET Core 2.0 (C# 7.x):
   - ValueTask & ValueTask<TResult> - is a structure that wraps a Task or IValueTaskSource to improve performance.
   - Discard '_' to replace an intentionally unused variable
   - The 'Main' method is declared as async
 - .NET Core 3.0 (C# 8):
   - Async streams & IAsyncEnumerable
   - 'await foreach'
   - System.IAsyncDisposable & DisposeAsync, 'async using'
 - .NET 6 (C# 10):
   - System.Text.Json can serialize & deserialize an IAsyncEnumerable type

### Managed ThreadPool

The ThreadPool class in the System.Threading namespace provides developers with a pool of worker threads 
that they can leverage to perform tasks in the background.  
ThreadPool threads are background threads that run at the default priority.
When one of these threads completes its task, it is returned to the pool of available threads to await its next task.
The number of active threads is limited by the number that the operating system can allocate to an application, 
based on the processor capacity and other running processes.
