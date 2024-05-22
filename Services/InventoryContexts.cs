﻿namespace LIN.Inventory.Shared.Services;


public static class InventoryContext
{


    /// <summary>
    /// Diccionario.
    /// </summary>
    public readonly static Dictionary<int, InventoryContextModel> Dictionary = [];



    /// <summary>
    /// Tratar de obtener el Inventario.
    /// </summary>
    /// <param name="id">Id del inventario.</param>
    public static InventoryContextModel? Get(int id)
    {
        Dictionary.TryGetValue(id, out InventoryContextModel? model);
        return model;
    }



    /// <summary>
    /// Tratar de obtener un producto.
    /// </summary>
    /// <param name="id">Id del producto.</param>
    public static ProductModel? GetProduct(int id)
    {

        ProductModel? product = null;
        foreach (var inv in Dictionary.Values)
        {
            var model = inv.FindProduct(id);
            if (model != null)
            {
                product = model;
                break;
            }

        }

        return product;

    }



    /// <summary>
    /// Tratar de poner el Inventario.
    /// </summary>
    public static void Post(InventoryDataModel model)
    {
        Dictionary.TryGetValue(model.ID, out InventoryContextModel? res);

        if (res != null)
            return;


        Dictionary.Add(model.ID, new()
        {
            Inventory = model
        });

    }



    /// <summary>
    /// Tratar de poner el Inventario.
    /// </summary>
    public static void PostAndReplace(InventoryDataModel model)
    {
        Dictionary.TryGetValue(model.ID, out InventoryContextModel? res);

        if (res != null)
        {
            res.Inventory = model;
            return;
        }

        Dictionary.Add(model.ID, new()
        {
            Inventory = model
        });

    }



}