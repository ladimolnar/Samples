# Samples
Samples is a collection of personal sample projects.

**Samples\Sources\AsyncIssue**  
A project that demonstrates how a call to CancellationTokenSource.Cancel can be hijacked by the asynchronous task being cancelled. In some cases the caller that calls CancellationTokenSource.Cancel never gets control back.
The scenario is being discussed on stackoverflow [here](https://stackoverflow.com/questions/31495411/a-call-to-cancellationtokensource-cancel-never-returns)

**Samples\Sources\DisplayInformation**  
A project for Win 10 that shows the values in the DisplayInformation for the current window. Used to demonstrate the scaling applied by the OS and the concept of effective vs. physical pixels.

**Samples\Sources\WeakEvents **  
A project that demonstrates the dangers of using the "Weak Event"pattern. The issue is discussed on my blog [here](http://ladimolnar.com/2015/09/14/the-weak-event-pattern-is-dangerous/)
