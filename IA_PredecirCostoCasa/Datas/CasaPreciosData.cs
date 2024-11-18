using IA_PredecirCostoCasa.Presentations;

namespace IA_PredecirCostoCasa.Datas;

public class CasaPreciosData
{
    /// <summary>
    /// Importante:
    /// Lista de valores de algunos inmuebles para las predicciones. 
    /// Resulta interesante añadir que esta consulta podría tener origen 
    /// desde una base de datos. Sin embargo, cuanto mayor sea la cantidad
    /// de datos, mayor tiempo requerirá el entrenamiento y también, un 
    /// mayor consumo de cómputo y memria en el sistema. 
    /// </summary>
    /// <returns>Listado de valroes.</returns>
    public static IEnumerable<CasaData> GetDatas()
    {
        return new List<CasaData>()
        {
            new CasaData
            {
                Size = 120,
                Rooms = 3,
                Bathrooms = 2,
                Age = 10,
                Location = "Urban",
                Price = 300000
            },
            new CasaData
            {
                Size = 80,
                Rooms = 2,
                Bathrooms = 1,
                Age = 5,
                Location = "Urban",
                Price = 200000
            },
            new CasaData
            {
                Size = 150,
                Rooms = 4,
                Bathrooms = 3,
                Age = 20,
                Location = "Suburban",
                Price = 750000
            },
            new CasaData
            {
                Size = 200,
                Rooms = 5,
                Bathrooms = 4,
                Age = 30,
                Location = "Rural",
                Price = 350000
            },
            new CasaData
            {
                Size = 100,
                Rooms = 3,
                Bathrooms = 1,
                Age = 15,
                Location = "Suburban",
                Price = 250000
            },
            new CasaData
            {
                Size = 50,
                Rooms = 1,
                Bathrooms = 1,
                Age = 2,
                Location = "Urban",
                Price = 120000
            },
        };
    }
}
