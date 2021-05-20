DEPLOYMENT
==========
Install the service
-------------------
1)open visual studio x64 command prompt in Administrator Mode
2)go to the deployed path of the service to be deployed.
3)installutil MessageService.exe

Uninstall the service
---------------------
1)open visual studio x64 command prompt in Administrator Mode
2)go to the deployed path of the service to be deployed.
3)installutil /u MessageService.exe



Performance Monitor 
-------------------
Performance monitor will have the performance of each worker under performance category "Message Routing Service"

EventLog
--------
It is used to back track the error on the error on the queue and formatting issue.

Application Monitor
-------------------
Applicaion can be monitor by the ClientMonitorService, where all the worker status can be observed.
And Self host service is running on 8081 port to monitor over the remote.

DEBUG
-----
Application(MessageService) can be modified with debug option based on the DEBUG mode in visual studio.


MessagingProcessType
====================
RoundRobin(queue to queue)
----------
forword one queue to n number of queue based on the round robin fashion. 
uses - To Split the load of inqueue to multiple outqueue based  on the order.
			test_load1		- test_out11		test_out12		test_out13
message	-->	1 2 3 4 5 6		-  1 4				  2 5			   3 6

example:
	<ProcessDefinition ProcessName="Worker1" ProcessType="RoundRobin" NumberThreads="8" Transactions="false">
		<Description>RoundRobin Message Worker with 8 Threads No Transactions</Description>
		<InputQueue>.\private$\test_load1</InputQueue>
		<ErrorQueue>.\private$\test_error</ErrorQueue>
		<OutputList>
			<OutputName>.\private$\test_out11</OutputName>
			<OutputName>.\private$\test_out12</OutputName>
			<OutputName>.\private$\test_out13</OutputName>
		</OutputList>
	</ProcessDefinition>

AppSpecific(queue to queue)
-----------
forword one queue to n number of queue based on the AppSpecific parameter in the MessagingQueue(Message.AppSpecific Property in queue). 
uses - To Split the load of inqueue to multiple outqueue based  on the Appspecific parameter.
			test_load2_t		- test_out21_t		test_out22_t	test_out23_t
message		-->	1 2 3 4 5 6		-  1 2	 			 3 5			4 6
AppSpecific	-->	1 1	2 3	2 3		-  1 1	 			 2 2			3 3
example:
	</ProcessDefinition>
		<ProcessDefinition ProcessName="Worker2t" ProcessType="AppSpecific" NumberThreads="4" Transactions="true">
		<Description>AppSpecific Message Worker with 4 Threads and Transactions</Description>
		<InputQueue>.\private$\test_load2_t</InputQueue>
		<ErrorQueue>.\private$\test_error_t</ErrorQueue>
		<OutputList>
			<OutputName>.\private$\test_out21_t</OutputName>
			<OutputName>.\private$\test_out22_t</OutputName>
			<OutputName>.\private$\test_out23_t</OutputName>
		</OutputList>
	</ProcessDefinition>

Disperse(queue to queue)
--------
copy one queue to all output queue. 
uses - To Split the load of inqueue to all outqueue.
			test_load3_t		- test_out31_t		test_out32_t
message	-->	1 2 3 4 5 6			- 1 2 3 4 5 6		1 2 3 4 5 6
example:
	<ProcessDefinition ProcessName="Worker3t" ProcessType="Disperse" NumberThreads="2" Transactions="true">
		<Description>Disperse Message Worker with 2 Threads and Transactions</Description>
		<InputQueue>.\private$\test_load3_t</InputQueue>
		<ErrorQueue>.\private$\test_error_t</ErrorQueue>
		<OutputList>
			<OutputName>.\private$\test_out31_t</OutputName>
			<OutputName>.\private$\test_out32_t</OutputName>
		</OutputList>
	</ProcessDefinition>

MessageType(queue to queue)
-----------
forword one queue to 2 number of queue based on the Label on the message with id to the queue index . 
test_load2	is compused of label message1 and message2
label		-->	message1			message2
message		-->	1 3 5				2 4 6
				test_out21			test_out22
output		-->	 1 3 5				2 4 6		
example:
	<ProcessDefinition ProcessName="Worker2" ProcessType="MessageType" NumberThreads="4" Transactions="false">
		<Description>MessageType Message Worker with 4 Threads and No Transactions</Description>
		<InputQueue>.\private$\test_load2</InputQueue>
		<ErrorQueue>.\private$\test_error</ErrorQueue>
		<OutputDefinitions>
			<OutputName MessageType="Message1">.\private$\test_out21</OutputName>
			<OutputName MessageType="Message2">.\private$\test_out22</OutputName>
		</OutputDefinitions>
	</ProcessDefinition>

Assembly(queue to application)
--------
Refer DatabasePersistExample on MessageProcessor.dll where we copy the data from the queue to DB based on the application
process defined in the Process Method. You can define the message type in the InitQueue
example:
	<ProcessDefinition ProcessName="Worker4" ProcessType="Assembly" NumberThreads="4" Transactions="false">
		<Description>Assembly Worker with 4 Threads No Transactions</Description>
		<InputQueue>.\private$\test_load4</InputQueue>
		<ErrorQueue>.\private$\test_error</ErrorQueue>
		<OutputQueue>.\private$\test_output</OutputQueue>
		<AssemblyDefinitions>
			<AssemblyLocation ClassName="SMS.MessageRoutingService.MessageProcessor.DatabasePersistExample">E:\Application\Message Routing Service Application\Code\ExampleMessageProcessor\bin\Debug\MessageProcessorExample.dll</AssemblyLocation>
		</AssemblyDefinitions>
	</ProcessDefinition>



------------------------------------------------------------------------------------------------------------------------------------------
Code originated @http://code.msdn.microsoft.com/C-Message-Routing-Service-41039906

Sample format of MessageService.xml
-----------------------------------
<?xml version="1.0" encoding="utf-8" ?>
<ProcessList
	xmlns="urn:messageservice-schema"
	xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
	xsi:schemaLocation="urn:messageservice-schema MessageService.xsd"
	MonitorConfiguration="true" >
	<ProcessDefinition ProcessName="Worker1" ProcessType="RoundRobin" NumberThreads="8" Transactions="false">
		<Description>RoundRobin Message Worker with 8 Threads No Transactions</Description>
		<InputQueue>.\private$\test_load1</InputQueue>
		<ErrorQueue>.\private$\test_error</ErrorQueue>
		<OutputList>
			<OutputName>.\private$\test_out11</OutputName>
			<OutputName>.\private$\test_out12</OutputName>
			<OutputName>.\private$\test_out13</OutputName>
		</OutputList>
	</ProcessDefinition>
	<ProcessDefinition ProcessName="Worker2" ProcessType="MessageType" NumberThreads="4" Transactions="false">
		<Description>MessageType Message Worker with 4 Threads and No Transactions</Description>
		<InputQueue>.\private$\test_load2</InputQueue>
		<ErrorQueue>.\private$\test_error</ErrorQueue>
		<OutputDefinitions>
			<OutputName MessageType="Message1">.\private$\test_out21</OutputName>
			<OutputName MessageType="Message2">.\private$\test_out22</OutputName>
		</OutputDefinitions>
	</ProcessDefinition>
		<ProcessDefinition ProcessName="Worker2t" ProcessType="AppSpecific" NumberThreads="4" Transactions="true">
		<Description>AppSpecific Message Worker with 4 Threads and Transactions</Description>
		<InputQueue>.\private$\test_load2_t</InputQueue>
		<ErrorQueue>.\private$\test_error_t</ErrorQueue>
		<OutputList>
			<OutputName>.\private$\test_out21_t</OutputName>
			<OutputName>.\private$\test_out22_t</OutputName>
			<OutputName>.\private$\test_out23_t</OutputName>
		</OutputList>
	</ProcessDefinition>
	<ProcessDefinition ProcessName="Worker3t" ProcessType="Disperse" NumberThreads="2" Transactions="true">
		<Description>Disperse Message Worker with 2 Threads and Transactions</Description>
		<InputQueue>.\private$\test_load3_t</InputQueue>
		<ErrorQueue>.\private$\test_error_t</ErrorQueue>
		<OutputList>
			<OutputName>.\private$\test_out31_t</OutputName>
			<OutputName>.\private$\test_out32_t</OutputName>
		</OutputList>
	</ProcessDefinition>
	<ProcessDefinition ProcessName="Worker4" ProcessType="Assembly" NumberThreads="4" Transactions="false">
		<Description>Assembly Worker with 4 Threads No Transactions</Description>
		<InputQueue>.\private$\test_load4</InputQueue>
		<ErrorQueue>.\private$\test_error</ErrorQueue>
		<OutputQueue>.\private$\test_output</OutputQueue>
		<AssemblyDefinitions>
			<AssemblyLocation ClassName="SMS.MessageRoutingService.MessageProcessor.DatabasePersistExample">E:\Application\Message Routing Service Application\Code\ExampleMessageProcessor\bin\Debug\MessageProcessorExample.dll</AssemblyLocation>
		</AssemblyDefinitions>
	</ProcessDefinition>
</ProcessList>