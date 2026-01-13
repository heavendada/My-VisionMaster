using H.Controls.Diagram.Datas;
using H.NodeDatas.Zoo;

namespace H.App.VisionMaster.OpenCV.NodeDatas.SrcImages;

public class OpenCVZooNodeDataGroup : ZooNodeDataGroup
{
    protected override IEnumerable<INodeData> CreateNodeDatas()
    {
        return this.GetType().Assembly.GetInstances<IZooSrcImageFilesNodeData>().OrderBy(x => x.Order);
    }
}
