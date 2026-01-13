using H.App.VisionMaster.OpenCV.NodeDatas.SrcImages;
using H.VisionMaster.DiagramData;
using H.VisionMaster.Network.Groups;
using H.VisionMaster.NodeGroup.Groups.SrcImages;

namespace H.App.VisionMaster.OpenCV.DiagramDatas;

[Display(Name = "机器视觉流程", GroupName = "机器视觉", Order = 0)]
public class OpenCVVisionDiagramData : VisionDiagramDataBase
{
    protected override IEnumerable<INodeDataGroup> CreateNodeGroups()
    {
        return typeof(OpenCVSrcImageDataGroup).GetInstances<IImageDataGroup>().Concat(this.CreateLocalNodeGroups()).OrderBy(x => x.Order);
    }

    private IEnumerable<INodeDataGroup> CreateLocalNodeGroups()
    {
        OnnxDataGroup dnn = new OnnxDataGroup();
        dnn.NodeDatas.Add(new Yolov5OnnxNodeData());
        //dnn.NodeDatas.Add(new Yolov5RuntimeOnnxNodeData());
        dnn.NodeDatas.Add(new AgeInferOnnxNodeData());
        dnn.NodeDatas.Add(new GenderClsOnnxNodeData());
        dnn.NodeDatas.Add(new HumanSemSegOnnxNodeData());
        dnn.NodeDatas.Add(new Yolov5FaceOnnxNodeData());
        yield return dnn;
        yield return new OpenCVZooNodeDataGroup();
        yield return new NetworkDataGroup();
    }
}
