using H.Extensions.Common;
using H.VisionMaster.NodeData.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace H.NodeDatas.Zoo.NodeDatas;

[Display(Name = "药丸袋图像源", GroupName = "数据源", Order = 0)]
public abstract class PillbagSrcImageFilesNodeData<T> : SrcFilesVisionNodeData<T>, IZooSrcImageFilesNodeData where T : IDisposable
{
    public override void LoadDefault()
    {
        base.LoadDefault();
        this.SrcFilePaths = this.SrcFilePaths.Where(x => x.Contains("pill_bag")).ToObservable();
    }
}
