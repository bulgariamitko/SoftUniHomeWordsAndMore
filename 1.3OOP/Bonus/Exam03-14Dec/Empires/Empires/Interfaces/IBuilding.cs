namespace Empires.Interfaces
{
    public interface IBuilding : IUnitProducer, IResourceProducer, IUpdateable
    {
        event UnitProducedEventHandler OnUnitProduced;
        event ResourceProducedEventHandler OnResourceProduced;
    }
}