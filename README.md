This is sample solution for microservices + clean architecture which including:
- 3 services (1 Service using MS SQL and two others using CosmosDB)
- 1 API Gateway with Yarp

As time constraint I cannot initialize entire solution for realistic project including communication between services (sync with HTTP, async with message broker), saga (distributed transaction), cache, observability (logs, metric, tracking, alert), network architecture, etc ...