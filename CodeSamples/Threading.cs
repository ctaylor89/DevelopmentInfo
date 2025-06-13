using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;

// ThreadExamples
namespace DevelopmentInfo.CodeSamples
{
    public class Threading
    {
        int[] dataBulk = new int[8000];
        
        public void RunTPLExercises()
        {
            // Some exercises
            // ThreadTaskComparison();
            // HandleTaskExceptionWithTryCatch();
            
            ComputeStuffAsyncWait();
            Console.WriteLine("Returned to calling method");
            
            HandleTaskExceptionWithContinuation();
                                    
            for (int i = 0, s = 0; i < dataBulk.Length; i++, s++)
            {
                s = s >= 20 ? 0 : s;
                dataBulk[i] = s;
            }

            // Does not build. Not sure what I was trying here.
            //Task<Int32> t = new Task<Int32>(n => Sum((Int32)n), 1000);
            //t.Start();
            //t.Wait();

            // Get the result (the Result property internally calls Wait) 
            // Console.WriteLine("The sum is: " + t.Result);   // An Int32 value

            var s1 = Stopwatch.StartNew();
            s1.Stop();
            double duration = s1.Elapsed.TotalMilliseconds;

        }

        public void RunThreadExercises()
        {
            Console.WriteLine("\nStarting method: {0}()", MethodBase.GetCurrentMethod().Name);
            Console.WriteLine("Method thread Id: {0}  Processor/core count: {1}", 
                                Thread.CurrentThread.ManagedThreadId, Environment.ProcessorCount);
            
            // Call an anonymous method
            var thread1 = new Thread(() => {
                            Console.WriteLine("Message from thread1: Hello");
                            Console.WriteLine("Method thread Id: {0}", Thread.CurrentThread.ManagedThreadId);
                        })
            {
                Name = "Thread1",
                Priority = ThreadPriority.Highest
            };
            thread1.Start();

            // Start an annonymous thread, calling a named method and passing in a string param.
            new Thread(() => WriteMessage2("Param in thread start method"))
            {
                Name = "thread2",
                Priority = ThreadPriority.Highest
            }.Start();                            // Param optionaly could be passed here
            
            
            // Start a thread and stop it externally
            var eventStopLoop = new ManualResetEvent(false);

            var thread3 = new Thread(() => WriteMessages(eventStopLoop))
            {
                Name = "Thread3",
                Priority = ThreadPriority.Normal,
                IsBackground = true
            };
            thread3.Start();

            // A way to start an annonymous thread - not tested. You cannot call join on it.
            //(new Thread(() => WriteMessages(eventStopLoop))
            //{
            //    Name = "Thread4000",
            //    Priority = ThreadPriority.Normal,
            //    IsBackground = false
            //}).Start();

            Console.WriteLine("Press enter to stop thread from writing to console");
            Console.ReadLine();

            eventStopLoop.Set(); // Set event to stop thread
            thread3.Join();      // Wait for thread to complete
            Console.WriteLine("Thread has been joined and is complete");
            
            // Using the Threadpool
            // eventStopLoop.Reset();
            // ThreadPool.QueueUserWorkItem((x) => WriteMessages(eventStopLoop));
            // or
            ThreadPool.QueueUserWorkItem((x) =>
                                        {
                                            eventStopLoop.Reset();
                                            WriteMessages(eventStopLoop);
                                        });

            Console.WriteLine("Press enter to stop pooled thread from writing to console");
            Console.ReadLine();

            eventStopLoop.Set();
            Console.WriteLine("Event in the pooled thread has been set");

            // ------------------------------
            // TestAync1();
        }

        public void WriteMessage2(object stateArg)
        {
            var msg = stateArg as string;
            if(msg != null)
                Console.WriteLine("Message from thread2: {0}", msg);
            
            Console.WriteLine("Method thread Id: {0}", Thread.CurrentThread.ManagedThreadId);
        }

        public void WriteMessages(object stateArg)
        {
            var stopLoop = stateArg as ManualResetEvent;

            if (stopLoop != null)
            {
                while (!stopLoop.WaitOne(2000))   // WaitOne() returns true when event is signaled. Waits for time period passed to it in ms.
                {
                    Console.WriteLine("WriteMessages() : Writing message in thread loop");                    
                }

                Console.WriteLine("WriteMessages() : Message thread is stopping");
            }
        }

        public void ThreadTaskComparison()
        {
            Stopwatch watch = new Stopwatch();
            //64 is upper limit for WaitHandle.WaitAll() method
            int maxWaitHandleWaitAllAllowed = 64;
            ManualResetEventSlim[] mres =
              new ManualResetEventSlim[maxWaitHandleWaitAllAllowed];

            for (int i = 0; i < mres.Length; i++)
            {
                mres[i] = new ManualResetEventSlim(false);
            }

            long threadTime = 0;
            long taskTime = 0;
            watch.Start();

            //start a new classic Thread and signal the ManualResetEvent when its done
            //so that we can snapshot time taken, and 

            for (int i = 0; i < mres.Length; i++)
            {
                int idx = i;
                Thread t = new Thread((state) =>
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Console.WriteLine(string.Format("{0}:, outputing {1}",
                            state.ToString(), j.ToString()));
                    }

                    // Signal each event
                    mres[idx].Set();
                });

                t.Start(string.Format("Thread{0}", i.ToString()));
            }

            // WaitHandle.WaitAll((from x in mres select x.WaitHandle).ToArray());
            WaitHandle.WaitAll((mres.Select((x) => x.WaitHandle).ToArray()));

            threadTime = watch.ElapsedMilliseconds;
            watch.Reset();

            for (int i = 0; i < mres.Length; i++)
            {
                mres[i].Reset();
            }

            watch.Start();

            for (int i = 0; i < mres.Length; i++)
            {
                int idx = i;

                // Notice the two args passed to StartNew()
                Task task = Task.Factory.StartNew((state) =>
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Console.WriteLine(string.Format("{0}:, outputing {1}",
                            state.ToString(), j.ToString()));
                    }
                    mres[idx].Set();
                }, string.Format("Task{0}", i.ToString()));
            }

            WaitHandle.WaitAll((from x in mres select x.WaitHandle).ToArray());
            
            taskTime = watch.ElapsedMilliseconds;
            Console.WriteLine("Thread Time waited : {0}ms", threadTime);
            Console.WriteLine("Task Time waited : {0}ms", taskTime);

            for (int i = 0; i < mres.Length; i++)
            {
                mres[i].Dispose();
            }

            Console.WriteLine("All done, press Enter to Quit");
            Console.ReadLine();
        }

        /// <summary>
        /// Handles an exception by putting a try-catch around a trigger method
        /// </summary>
        public void HandleTaskExceptionWithTryCatch()
        {
            // Notice the two args passed to StartNew()
            Task<List<int>> getIntCollectionTask = Task.Factory.StartNew((stateObj) => 
            {
                var intCollection = new List<int>();
                const int maxNumberOfInts = 100;

                for(int i = 0; i < (int)stateObj; i++)
                {
                    intCollection.Add(i);

                    if(i > maxNumberOfInts)
                    { 
                        var ex = new InvalidOperationException("Input value > max allowed");
                        ex.Source = "HandleTaskExceptionWithTryCatch";
                        throw ex;

                        // This is unreachable code. You can only get a collection of exceptions if multiple tasks are called from a task
                        // and each throws an exception.
                        var ex2 = new InvalidOperationException("Code has bug");
                        ex2.Source = "HandleTaskExceptionWithTryCatch";
                        throw ex2;
                    }
                }
                
                return intCollection;
            }, 105);

            // Build a try-catch around the wait call
            try
            {
                getIntCollectionTask.Wait();  // This trigger method is needed in order to observe the exception
            }
            catch (AggregateException aggEx)
            {
                // This will report only the first exception that occurs.  
                // Console.WriteLine("HandleTaskExceptionWithTryCatch(): Caught Exception: {0}", aggEx.InnerException.Message);

                foreach (Exception ex in aggEx.InnerExceptions)
                {
                    Console.WriteLine("HandleTaskExceptionWithTryCatch(): Caught Exception: {0}", ex.Message);  
                }
            }
            finally
            {
                getIntCollectionTask.Dispose();
            }

            Console.WriteLine("HandleTaskException() Ended"); 
        }

        /// <summary>
        /// Example using async and await. Async marks this method as a method that will return control to the 
        /// caller at the point of the await keyword, and continue running asynchronously.
        /// Note: An async method will be run synchronously if it does not contain the await keyword.
        /// </summary>
        private async void ComputeStuffAsyncWait()
        {
            var sum = 0.0;
            
            Console.WriteLine("ComputeStuffAsyncWait() started");

            for (int t = 0; t < 3; t++)
            {
                Console.WriteLine("Computing now... {0}", t);
                Thread.Sleep(3000);
                
                // Control is returned to calling method when await is called
                await Task.Run(() =>
                {
                    for (int i = 0; i < 900000000; i++)
                    {
                        if (i % 500 == 0)
                            sum += 1.2;
                    }
                });
            }

            Console.WriteLine("The task is finished running: Sum1 = {0}", sum);
        }

        /// <summary>
        /// Handles an exception using a continuation
        /// </summary>
        public void HandleTaskExceptionWithContinuation()
        {
            Console.WriteLine("Started HandleTaskExceptionWithContinuation()");
            var input = "The season of the sun is assumed to be serious in Seattle but not in Texas";

            Task<List<string>> stringsWithS = Task.Factory.StartNew<List<string>>(() =>
                    {
                        string[] words = input.Split(' ');
                        var results = new List<string>();
                        
                        words.ForEach((w) =>
                            {
                                if (w.ToUpper().Contains('S'))
                                    results.Add(w);
                            });

                        //throw AggregateException()
                        return results;
                    });

            stringsWithS.ContinueWith((s) =>
                {
                    Console.WriteLine("Words that have an 'S' in them:");

                    s.Result.ForEach((w) =>
                        {
                            Console.WriteLine("   {0}", w);
                        });
                },TaskContinuationOptions.OnlyOnRanToCompletion);

            stringsWithS.ContinueWith((s) =>
                {
                    Console.WriteLine("stringsWithS Error: {0}", s.Exception.Message);
                }, TaskContinuationOptions.OnlyOnFaulted);
        }

        // Causing build errors
        //public async void TestAync1()
        //{
        //    Task<string> statement = GetString(); 
        //    string result = await statement;
        //    Console.WriteLine("TestAync1() result is: {0}", result);
        //}

        //private Task<string> GetString()
        //{
        //    return new Task<string>("Return string from Task");
        //}
    }
}
