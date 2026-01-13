using H.Controls.Diagram.Datas;
using H.Extensions.Common;
using H.NodeDatas.Onnx.OpenCV.Base;
using H.VisionMaster.NodeGroup.Groups.SrcImages;
using System.Collections.Generic;

namespace H.NodeDatas.Onnx.OpenCV.NodeDataGroups
{
    [Icon(FontIcons.CommandPrompt)]
    [Display(Name = "Onnx通用模型", Description = "CvDnn.ReadNetFromONNX", Order = 10500)]
    public class OnnxDataGroup : OnnxDataGroupBase, IImageDataGroup
    {
        protected override IEnumerable<INodeData> CreateNodeDatas()
        {
            return typeof(IOpenCVDnnNodeData).Assembly.GetInstances<IOpenCVDnnNodeData>().OrderBy(x => x.Order);
        }
    }
}
