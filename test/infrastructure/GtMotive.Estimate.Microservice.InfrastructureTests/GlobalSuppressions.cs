// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Maintainability", "CA1515:Consider making public types internal", Justification = "For avoid xUnit1027.", Scope = "type", Target = "~T:GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure.TestServerCollectionFixture")]
[assembly: SuppressMessage("Maintainability", "CA1515:Considere la posibilidad de hacer que los tipos públicos sean internos", Justification = "<pendiente>", Scope = "type", Target = "~T:GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure.Startup")]
[assembly: SuppressMessage("Reliability", "CA2000:Desechar (Dispose) objetos antes de perder el ámbito", Justification = "<pendiente>", Scope = "member", Target = "~M:GtMotive.Estimate.Microservice.InfrastructureTests.Tests.Vehicles.VehiclesInfrastructureTests.PostVehicleShouldFailValidationWhenYearIsInvalid~System.Threading.Tasks.Task")]
