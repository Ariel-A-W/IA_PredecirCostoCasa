using IA_PredecirCostoCasa.Datas;
using IA_PredecirCostoCasa.Presentations;
using Microsoft.ML;

namespace IA_PredecirCostoCasa.Process;

public class CasaPrecio
{
    public void Process()
    {
        // Obtener datos de una lista.
        var lstCasaDatas = CasaPreciosData.GetDatas();

        // Crear el contexto de ML
        var mlContext = new MLContext();

        // Cargar los datos
        // var data = mlContext.Data.LoadFromTextFile<CasaData>("", hasHeader: true, separatorChar: ';');
        var data = mlContext.Data.LoadFromEnumerable<CasaData>(lstCasaDatas);

        // Dividir los datos en entrenamiento y prueba
        var trainTestSplit = mlContext.Data.TrainTestSplit(data, testFraction: 0.2);
        var trainingData = trainTestSplit.TrainSet;
        var testData = trainTestSplit.TestSet;

        // Construir el pipeline de entrenamiento
        var pipeline = mlContext.Transforms.Categorical.OneHotEncoding("Location")
            .Append(mlContext.Transforms.NormalizeMinMax("Size"))
            .Append(mlContext.Transforms.NormalizeMinMax("Rooms"))
            .Append(mlContext.Transforms.NormalizeMinMax("Bathrooms"))
            .Append(mlContext.Transforms.NormalizeMinMax("Age"))
            .Append(mlContext.Transforms.Concatenate("Features", "Size", "Rooms", "Bathrooms", "Age", "Location"))
            .Append(mlContext.Regression.Trainers.LightGbm(labelColumnName: "Price", featureColumnName: "Features"));

        // Entrenar el modelo
        var model = pipeline.Fit(trainingData);

        // Evaluar el modelo
        var predictions = model.Transform(testData);
        var metrics = mlContext.Regression.Evaluate(predictions, labelColumnName: "Price");

        // Realizar predicciones
        var predictor = mlContext.Model.CreatePredictionEngine<CasaData, CasaPrecioPrediction>(model);
        var newHouse = new CasaData { Size = 120, Rooms = 4, Bathrooms = 2, Age = 5, Location = "Urban" };
        var prediction = predictor.Predict(newHouse);

        Console.WriteLine("Predecir Costo de un Inmueble");
        Console.WriteLine("*****************************");
        Console.WriteLine("Valores a Consultar:");
        Console.WriteLine("********************");
        Console.WriteLine(
           "Tamaño MTS cuadrados: {0}\nHabitaciones: {1}\n" +
           "Baños: {2}\nAntigüedad: {3}\nUbicación: {4}", 
           newHouse.Size, newHouse.Rooms, newHouse.Bathrooms, 
           newHouse.Age, newHouse.Location
        );
        Console.WriteLine("");
        Console.WriteLine("Predecir Costo");
        Console.WriteLine("**************");
        Console.WriteLine($"Precio: {prediction.Price:0.##}");
    }
}
