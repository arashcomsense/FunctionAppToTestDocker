# How to run the application in docker?

1) Clone this repo
2) Open the folder where `docker-compose.yml` file resides in by VS Code
3) Ensure that the latest version of docker is installed on your machine and woeking
4) Run `docker compose build` command to have the function app built
5) Run `docker compose up` command to get the container run in docker
6) Navigate to `http://localhost:9180/api/mongotest` to seed the mongo db database within the container. Unfortunately, the function raises error 500 due to inability to communicate
with the mongodb instance within the container. The failure details is per below:

>mongodbtest.functionapp_1     | info: Function.func[1]
>mongodbtest.functionapp_1     |       Executing 'func' (Reason='This function was programmatically called via the host APIs.', Id=96f4668d-710d-4b49-abbb-180b856f9b3b)
mongodbtest.functionapp_1     | info: Function.func.User[0]
mongodbtest.functionapp_1     |       Testing seeding database from inside the container.
mongodbtest.functionapp_1     | fail: Function.func[3]
mongodbtest.functionapp_1     |       Executed 'func' (Failed, Id=96f4668d-710d-4b49-abbb-180b856f9b3b, Duration=33685ms)
mongodbtest.functionapp_1     | Microsoft.Azure.WebJobs.Host.FunctionInvocationException: Exception while executing function: func
mongodbtest.functionapp_1     |  ---> System.TimeoutException: A timeout occurred after 30000ms selecting a server using CompositeServerSelector{ Selectors = MongoDB.Driver.MongoClient+AreSessionsSupportedServerSelector, LatencyLimitingServerSelector{ AllowedLatencyRange = 00:00:00.0150000 } }. Client view of cluster state is { ClusterId : "1", Type : "Unknown", State : "Disconnected", Servers : [{ ServerId: "{ ClusterId : 1, EndPoint : "Unspecified/localhost:27017" }", EndPoint: "Unspecified/localhost:27017", ReasonChanged: "Heartbeat", State: "Disconnected", ServerVersion: , TopologyVersion: , Type: "Unknown", HeartbeatException: "MongoDB.Driver.MongoConnectionException: An exception occurred while opening a connection to the server.
mongodbtest.functionapp_1     |  ---> System.Net.Sockets.SocketException (99): Cannot assign requested address
mongodbtest.functionapp_1     |    at System.Net.Sockets.Socket.BeginConnectEx(EndPoint remoteEP, Boolean flowContext, AsyncCallback callback, Object state)
mongodbtest.functionapp_1     |    at System.Net.Sockets.Socket.UnsafeBeginConnect(EndPoint remoteEP, AsyncCallback callback, Object state, Boolean flowContext)
mongodbtest.functionapp_1     |    at System.Net.Sockets.Socket.BeginConnect(EndPoint remoteEP, AsyncCallback callback, Object state)
mongodbtest.functionapp_1     |    at System.Net.Sockets.Socket.ConnectAsync(EndPoint remoteEP)
mongodbtest.functionapp_1     |    at MongoDB.Driver.Core.Connections.TcpStreamFactory.ConnectAsync(Socket socket, EndPoint endPoint, CancellationToken cancellationToken)
mongodbtest.functionapp_1     |    at MongoDB.Driver.Core.Connections.TcpStreamFactory.CreateStreamAsync(EndPoint endPoint, CancellationToken cancellationToken)
mongodbtest.functionapp_1     |    at MongoDB.Driver.Core.Connections.BinaryConnection.OpenHelperAsync(CancellationToken cancellationToken)
mongodbtest.functionapp_1     |    --- End of inner exception stack trace ---
mongodbtest.functionapp_1     |    at MongoDB.Driver.Core.Connections.BinaryConnection.OpenHelperAsync(CancellationToken cancellationToken)
mongodbtest.functionapp_1     |    at MongoDB.Driver.Core.Servers.ServerMonitor.InitializeConnectionAsync(CancellationToken cancellationToken)
mongodbtest.functionapp_1     |    at MongoDB.Driver.Core.Servers.ServerMonitor.HeartbeatAsync(CancellationToken cancellationToken)", LastHeartbeatTimestamp: "2021-07-06T18:25:12.0892043Z", LastUpdateTimestamp: "2021-07-06T18:25:12.0892045Z" }] }.
mongodbtest.functionapp_1     |    at MongoDB.Driver.Core.Clusters.Cluster.ThrowTimeoutException(IServerSelector selector, ClusterDescription description)
mongodbtest.functionapp_1     |    at MongoDB.Driver.Core.Clusters.Cluster.WaitForDescriptionChangedHelper.HandleCompletedTask(Task completedTask)
mongodbtest.functionapp_1     |    at MongoDB.Driver.Core.Clusters.Cluster.WaitForDescriptionChangedAsync(IServerSelector selector, ClusterDescription description, Task descriptionChangedTask, TimeSpan timeout, CancellationToken cancellationToken)
mongodbtest.functionapp_1     |    at MongoDB.Driver.Core.Clusters.Cluster.SelectServerAsync(IServerSelector selector, CancellationToken cancellationToken)
mongodbtest.functionapp_1     |    at MongoDB.Driver.MongoClient.AreSessionsSupportedAfterSeverSelctionAsync(CancellationToken cancellationToken)
mongodbtest.functionapp_1     |    at MongoDB.Driver.MongoClient.AreSessionsSupportedAsync(CancellationToken cancellationToken)
mongodbtest.functionapp_1     |    at MongoDB.Driver.MongoClient.StartImplicitSessionAsync(CancellationToken cancellationToken)
mongodbtest.functionapp_1     |    at MongoDB.Driver.MongoClient.UsingImplicitSessionAsync(Func`2 funcAsync, CancellationToken cancellationToken)
mongodbtest.functionapp_1     |    at FunctionAppToTestDocker.Function1.Run(HttpRequest req, ILogger log) in /src/FunctionAppToTestDocker/Function1.cs:line 38
mongodbtest.functionapp_1     |    at Microsoft.Azure.WebJobs.Host.Executors.FunctionInvoker`2.InvokeAsync(Object instance, Object[] arguments) in C:\projects\azure-webjobs-sdk-rqm4t\src\Microsoft.Azure.WebJobs.Host\Executors\FunctionInvoker.cs:line 52
mongodbtest.functionapp_1     |    at Microsoft.Azure.WebJobs.Host.Executors.FunctionExecutor.InvokeWithTimeoutAsync(IFunctionInvoker invoker, ParameterHelper parameterHelper, CancellationTokenSource timeoutTokenSource, CancellationTokenSource functionCancellationTokenSource, Boolean throwOnTimeout, TimeSpan timerInterval, IFunctionInstance instance) in C:\projects\azure-webjobs-sdk-rqm4t\src\Microsoft.Azure.WebJobs.Host\Executors\FunctionExecutor.cs:line 555
mongodbtest.functionapp_1     |    at Microsoft.Azure.WebJobs.Host.Executors.FunctionExecutor.ExecuteWithWatchersAsync(IFunctionInstanceEx instance, ParameterHelper parameterHelper, ILogger logger, CancellationTokenSource functionCancellationTokenSource) in C:\projects\azure-webjobs-sdk-rqm4t\src\Microsoft.Azure.WebJobs.Host\Executors\FunctionExecutor.cs:line 503
mongodbtest.functionapp_1     |    at Microsoft.Azure.WebJobs.Host.Executors.FunctionExecutor.ExecuteWithLoggingAsync(IFunctionInstanceEx instance, FunctionStartedMessage message, FunctionInstanceLogEntry instanceLogEntry, 
ParameterHelper parameterHelper, ILogger logger, CancellationToken cancellationToken) in C:\projects\azure-webjobs-sdk-rqm4t\src\Microsoft.Azure.WebJobs.Host\Executors\FunctionExecutor.cs:line 281
mongodbtest.functionapp_1     |    --- End of inner exception stack trace ---
mongodbtest.functionapp_1     |    at Microsoft.Azure.WebJobs.Host.Executors.FunctionExecutor.ExecuteWithLoggingAsync(IFunctionInstanceEx instance, FunctionStartedMessage message, FunctionInstanceLogEntry instanceLogEntry, 
ParameterHelper parameterHelper, ILogger logger, CancellationToken cancellationToken) in C:\projects\azure-webjobs-sdk-rqm4t\src\Microsoft.Azure.WebJobs.Host\Executors\FunctionExecutor.cs:line 328
mongodbtest.functionapp_1     |    at Microsoft.Azure.WebJobs.Host.Executors.FunctionExecutor.TryExecuteAsync(IFunctionInstance functionInstance, CancellationToken cancellationToken) in C:\projects\azure-webjobs-sdk-rqm4t\src\Microsoft.Azure.WebJobs.Host\Executors\FunctionExecutor.cs:line 94
mongodbtest.functionapp_1     | fail: Host.Results[0]
mongodbtest.functionapp_1     | Microsoft.Azure.WebJobs.Host.FunctionInvocationException: Exception while executing function: func
mongodbtest.functionapp_1     |  ---> System.TimeoutException: A timeout occurred after 30000ms selecting a server using CompositeServerSelector{ Selectors = MongoDB.Driver.MongoClient+AreSessionsSupportedServerSelector, LatencyLimitingServerSelector{ AllowedLatencyRange = 00:00:00.0150000 } }. Client view of cluster state is { ClusterId : "1", Type : "Unknown", State : "Disconnected", Servers : [{ ServerId: "{ ClusterId : 1, EndPoint : "Unspecified/localhost:27017" }", EndPoint: "Unspecified/localhost:27017", ReasonChanged: "Heartbeat", State: "Disconnected", ServerVersion: , TopologyVersion: , Type: "Unknown", HeartbeatException: "MongoDB.Driver.MongoConnectionException: An exception occurred while opening a connection to the server.
mongodbtest.functionapp_1     |  ---> System.Net.Sockets.SocketException (99): Cannot assign requested address
mongodbtest.functionapp_1     |    at System.Net.Sockets.Socket.BeginConnectEx(EndPoint remoteEP, Boolean flowContext, AsyncCallback callback, Object state)
mongodbtest.functionapp_1     |    at System.Net.Sockets.Socket.UnsafeBeginConnect(EndPoint remoteEP, AsyncCallback callback, Object state, Boolean flowContext)
mongodbtest.functionapp_1     |    at System.Net.Sockets.Socket.BeginConnect(EndPoint remoteEP, AsyncCallback callback, Object state)
mongodbtest.functionapp_1     |    at System.Net.Sockets.Socket.ConnectAsync(EndPoint remoteEP)
mongodbtest.functionapp_1     |    at MongoDB.Driver.Core.Connections.TcpStreamFactory.ConnectAsync(Socket socket, EndPoint endPoint, CancellationToken cancellationToken)
mongodbtest.functionapp_1     |    at MongoDB.Driver.Core.Connections.TcpStreamFactory.CreateStreamAsync(EndPoint endPoint, CancellationToken cancellationToken)
mongodbtest.functionapp_1     |    at MongoDB.Driver.Core.Connections.BinaryConnection.OpenHelperAsync(CancellationToken cancellationToken)
mongodbtest.functionapp_1     |    --- End of inner exception stack trace ---
mongodbtest.functionapp_1     |    at MongoDB.Driver.Core.Connections.BinaryConnection.OpenHelperAsync(CancellationToken cancellationToken)
mongodbtest.functionapp_1     |    at MongoDB.Driver.Core.Servers.ServerMonitor.InitializeConnectionAsync(CancellationToken cancellationToken)
mongodbtest.functionapp_1     |    at MongoDB.Driver.Core.Servers.ServerMonitor.HeartbeatAsync(CancellationToken cancellationToken)", LastHeartbeatTimestamp: "2021-07-06T18:25:12.0892043Z", LastUpdateTimestamp: "2021-07-06T18:25:12.0892045Z" }] }.
mongodbtest.functionapp_1     |    at MongoDB.Driver.Core.Clusters.Cluster.ThrowTimeoutException(IServerSelector selector, ClusterDescription description)
mongodbtest.functionapp_1     |    at MongoDB.Driver.Core.Clusters.Cluster.WaitForDescriptionChangedHelper.HandleCompletedTask(Task completedTask)
mongodbtest.functionapp_1     |    at MongoDB.Driver.Core.Clusters.Cluster.WaitForDescriptionChangedAsync(IServerSelector selector, ClusterDescription description, Task descriptionChangedTask, TimeSpan timeout, CancellationToken cancellationToken)
mongodbtest.functionapp_1     |    at MongoDB.Driver.Core.Clusters.Cluster.SelectServerAsync(IServerSelector selector, CancellationToken cancellationToken)
mongodbtest.functionapp_1     |    at MongoDB.Driver.MongoClient.AreSessionsSupportedAfterSeverSelctionAsync(CancellationToken cancellationToken)
mongodbtest.functionapp_1     |    at MongoDB.Driver.MongoClient.AreSessionsSupportedAsync(CancellationToken cancellationToken)
mongodbtest.functionapp_1     |    at MongoDB.Driver.MongoClient.StartImplicitSessionAsync(CancellationToken cancellationToken)
mongodbtest.functionapp_1     |    at MongoDB.Driver.MongoClient.UsingImplicitSessionAsync(Func`2 funcAsync, CancellationToken cancellationToken)
mongodbtest.functionapp_1     |    at FunctionAppToTestDocker.Function1.Run(HttpRequest req, ILogger log) in /src/FunctionAppToTestDocker/Function1.cs:line 38
mongodbtest.functionapp_1     |    at Microsoft.Azure.WebJobs.Host.Executors.FunctionInvoker`2.InvokeAsync(Object instance, Object[] arguments) in C:\projects\azure-webjobs-sdk-rqm4t\src\Microsoft.Azure.WebJobs.Host\Executors\FunctionInvoker.cs:line 52
mongodbtest.functionapp_1     |    at Microsoft.Azure.WebJobs.Host.Executors.FunctionExecutor.InvokeWithTimeoutAsync(IFunctionInvoker invoker, ParameterHelper parameterHelper, CancellationTokenSource timeoutTokenSource, CancellationTokenSource functionCancellationTokenSource, Boolean throwOnTimeout, TimeSpan timerInterval, IFunctionInstance instance) in C:\projects\azure-webjobs-sdk-rqm4t\src\Microsoft.Azure.WebJobs.Host\Executors\FunctionExecutor.cs:line 555
mongodbtest.functionapp_1     |    at Microsoft.Azure.WebJobs.Host.Executors.FunctionExecutor.ExecuteWithWatchersAsync(IFunctionInstanceEx instance, ParameterHelper parameterHelper, ILogger logger, CancellationTokenSource functionCancellationTokenSource) in C:\projects\azure-webjobs-sdk-rqm4t\src\Microsoft.Azure.WebJobs.Host\Executors\FunctionExecutor.cs:line 503
mongodbtest.functionapp_1     |    at Microsoft.Azure.WebJobs.Host.Executors.FunctionExecutor.ExecuteWithLoggingAsync(IFunctionInstanceEx instance, FunctionStartedMessage message, FunctionInstanceLogEntry instanceLogEntry, 
ParameterHelper parameterHelper, ILogger logger, CancellationToken cancellationToken) in C:\projects\azure-webjobs-sdk-rqm4t\src\Microsoft.Azure.WebJobs.Host\Executors\FunctionExecutor.cs:line 281
mongodbtest.functionapp_1     |    --- End of inner exception stack trace ---
mongodbtest.functionapp_1     |    at Microsoft.Azure.WebJobs.Host.Executors.FunctionExecutor.ExecuteWithLoggingAsync(IFunctionInstanceEx instance, FunctionStartedMessage message, FunctionInstanceLogEntry instanceLogEntry, ParameterHelper parameterHelper, ILogg
ParameterHelper parameterHelper, ILogger logger, CancellationToken cancellationToken) in C:\projects\azure-webjobs-sdk-rqm4t\src\Microsoft.Azure.WebJobs.Host\Executors\FunctionExecutor.cs:line 328
mongodbtest.functionapp_1     |    at Microsoft.Azure.WebJobs.Host.Executors.FunctionExecutor.TryExecuteAsync(IFunctionInstance functionInstance, CancellationToken cancellationToken) in C:\projects\azure-webjobs-sdk-rqm4t\src\Microsoft.Azure.WebJobs.Host\Executrc\Microsoft.Azure.WebJobs.Host\Executors\FunctionExecutor.cs:line 94
mongodbtest                   | {"t":{"$date":"2021-07-06T18:25:23.305+00:00"},"s":"I",  "c":"STORAGE",  "id":22430,   "ctx":"WTCheckpointThread","msg":"WiredTiger message","attr":{"message":"[1625595923:305742][1:0x7fafc3cc7700], WT_SESSION.checkpoint: [WT_VERc7700], WT_SESSION.checkpoint: [WT_VERB_CHECKPOINT_PROGRESS] saving checkpoint snapshot min: 5, snapshot max: 5 snapshot count: 0, oldest timestamp: (0, 0) , meta checkpoint timestamp: (0, 0)"}}


## A minor non-blocker known issue
The http-triggered function's internal port was mapped to the external port # of 9081 but it may not be picked up. In that case, please consult the docker's UI to observe the
function's extenal operational port number.
