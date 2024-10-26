# Part 1: Introduction to Threading in .NET

## Chapter 1: Managed Threading Concepts

### Topics:

 * .NET threading basics
 * Creating and destroying threads
 * Handling threading exceptions
 * Synchronizing data across threads
 * Scheduling and canceling work

### .NET threading basics

A **process** is an instance of a running application, which includes the program code, data, and system resources.  

A **thread** represents a single unit of execution within a process. 
By default, a .NET application will execute all its logic on a single thread (that is, the primary or main thread).  

**Foreground threads** are threads that will prevent the managed process from terminating if they are running. 
If an application is terminated, any running **background threads** will be stopped so that the process can shut down.  
