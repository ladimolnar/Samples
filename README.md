# Samples
Samples is a collection of personal sample projects.

**Sources\AsyncIssue**
A sample project that demonstrates how a call to CancellationTokenSource.Cancel can be hijacked by the asynchronous task being cancelled. In some cases the caller that calls CancellationTokenSource.Cancel never gets control back.
The scenario is being discussed on stackoverflow [here](https://stackoverflow.com/questions/31495411/a-call-to-cancellationtokensource-cancel-never-returns)

