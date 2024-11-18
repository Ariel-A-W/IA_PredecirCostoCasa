using Microsoft.ML.Data;

namespace IA_PredecirCostoCasa.Presentations;

public class CasaData
{
    [LoadColumn(0)]
    public float Size { get; set; }

    [LoadColumn(1)] 
    public float Rooms { get; set; }

    [LoadColumn(2)] 
    public float Bathrooms { get; set; }

    [LoadColumn(3)] 
    public float Age { get; set; }

    [LoadColumn(4)] 
    public string? Location { get; set; }

    [LoadColumn(5)]
    //[ColumnName("Price")]
    public float Price { get; set; }
}
