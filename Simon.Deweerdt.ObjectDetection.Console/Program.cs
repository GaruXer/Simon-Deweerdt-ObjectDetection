// See https://aka.ms/new-console-template for more information

using System.Text.Json;

var sceneDirectory = args[0];

if (!Directory.Exists(sceneDirectory))
{
    Console.WriteLine($"Le répertoire spécifié n'existe pas : {sceneDirectory}");
    return;
}

var imageFiles = Directory.GetFiles(sceneDirectory, "*.jpg");

if (imageFiles.Length == 0)
{
    Console.WriteLine("Aucune image trouvée dans le répertoire.");
    return;
}

var imagesData = new List<byte[]>();

foreach (var imagePath in imageFiles)
{
    imagesData.Add(await File.ReadAllBytesAsync(imagePath));
}

var objectDetection = new Simon.Deweerdt.ObjectDetection.ObjectDetection();
var detectObjectInScenesResults = await objectDetection.DetectObjectInScenesAsync(imagesData);

foreach (var objectDetectionResult in detectObjectInScenesResults)
{
    System.Console.WriteLine($"Box: {JsonSerializer.Serialize(objectDetectionResult.Box)}");
}