using LIN.Inventory.Shared.Interfaces;

namespace LIN.Inventory.Shared;


public class Service
{


    /// <summary>
    /// Servicio de archivos.
    /// </summary>
    internal static IOpenFiles? FileService;



    /// <summary>
    /// Establecer el servicio de abrir archivos.
    /// </summary>
    /// <param name="service">Servicio.</param>
    public static void SetOpenFile(IOpenFiles service)
    {
        FileService = service;
    }


}