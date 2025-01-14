using ObjectDetection;

namespace Simon.Deweerdt.ObjectDetection;

public record ObjectDetectionResult
{
    public byte[] ImageData { get; set; }
    public IList<BoundingBox> Box { get; set; }
}