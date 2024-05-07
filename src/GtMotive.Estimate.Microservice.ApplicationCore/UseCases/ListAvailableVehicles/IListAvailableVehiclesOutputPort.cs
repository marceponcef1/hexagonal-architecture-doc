namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehicles
{
    /// <summary>
    /// List available vehicles output port interface.
    /// </summary>
    public interface IListAvailableVehiclesOutputPort : IOutputPortStandard<ListAvailableVehiclesOutput>, IOutputPortNotFound
    {
    }
}
