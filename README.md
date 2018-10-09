This project demonstrates what I see as unexpected behavior of the MassTransit IConsumeObserver.

**To run:**
`dotnet run`

**Description of application:**
 - A MassTransit in memory message bus with an in memory scheduler is created.
 - A message handler is created that always throws an exception.
 - A redelivery policy of `Immediate(2)` is configured.
 - A `IConsumeObserver` is connected and configured to write to console on the `PreConsume`, `PostConsume`, and `ConsumeFault` events.
 - When the application runs a single message is published.

**Expected behavior:**
The `IConsumeObserver` will report that `ConsumeFault` was called three times. Once for each consumption that failed.

**Actual behavior:**
The `IConsumeObserver` report that `ConsumeFault` is called only once. When consumption fails but all redeliveries have not been exaused, PostConsume is called instead.

**Output example:**
```
PreConsume
EXCEPTION STACK TRACE
PostConsume
PreConsume
PostConsume
PreConsume
EXCEPTION STACK TRACE
PostConsume
PreConsume
PostConsume
PreConsume
EXCEPTION STACK TRACE
ConsumeFault
```

**Another note:**
The output shows that `PreConsume` and `PostConsume` are called more times that expected. Why is this?