# Samples
Samples is a collection of personal sample projects.

**Sources\AsyncIssue**  
A project that demonstrates how a call to CancellationTokenSource.Cancel can be hijacked by the asynchronous task being cancelled. In some cases the caller that calls CancellationTokenSource.Cancel never gets control back.
The scenario is being discussed on stackoverflow [here](https://stackoverflow.com/questions/31495411/a-call-to-cancellationtokensource-cancel-never-returns).

**Sources\DisplayInformation**  
A project for Win 10 that shows the values stored in class DisplayInformation for the current window. Used to demonstrate the scaling applied by the OS and the concept of effective vs. physical pixels.

**Sources\SurprisesWithMutableStructures**  
Collects scenarios that demonstrate how using mutable structs can give unexpected results. These scenarios are why some people consider mutable structs evil.

**Sources\WeakEvents**  
A project that demonstrates the dangers of using the "Weak Event"pattern. The issue is discussed in my article [The Weak Event Pattern is Dangerous](http://ladimolnar.com/2015/09/14/the-weak-event-pattern-is-dangerous/).

**Sources\CSharp\NewInCSharp6**  
Sample code illustrating what is new in C# 6. [GitHub gist](https://gist.github.com/ladimolnar/d982ae6deb80c78b47496b182d84c3a2)

