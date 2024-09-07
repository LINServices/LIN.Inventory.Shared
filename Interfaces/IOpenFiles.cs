namespace LIN.Inventory.Shared.Interfaces;


public interface IOpenFiles
{
    Task<byte[]> OpenFile();
}