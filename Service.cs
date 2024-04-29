using LIN.Inventory.Shared.Interfaces;

namespace LIN.Inventory.Shared;


public class Service
{

    internal static IOpenFiles? FileService;

    public static void SetOpenFile(IOpenFiles service)
    {
        FileService = service;
    }

}