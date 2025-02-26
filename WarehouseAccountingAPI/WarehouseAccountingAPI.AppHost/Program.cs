var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.WarehouseAccountingAPI>("warehouseaccountingapi");

builder.Build().Run();
