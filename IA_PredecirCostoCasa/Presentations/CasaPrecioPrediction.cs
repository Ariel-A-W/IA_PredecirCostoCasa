using Microsoft.ML.Data;

namespace IA_PredecirCostoCasa.Presentations;

public class CasaPrecioPrediction
{
    [ColumnName("Score")]
    public float Price { get; set; }
}
