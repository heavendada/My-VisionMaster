// Copyright (c) HeBianGu Authors. All Rights Reserved. 
// Author: HeBianGu 
// Github: https://github.com/HeBianGu/WPF-Control 
// Document: https://hebiangu.github.io/WPF-Control-Docs  
// QQ:908293466 Group:971261058 
// bilibili: https://space.bilibili.com/370266611 
// Licensed under the MIT License (the "License")

using H.Common.Attributes;
using H.Controls.Diagram.Datas;
using H.Controls.Diagram.Presenter.DiagramDatas.Base;
using H.Extensions.Common;
using H.Extensions.FontIcon;
using H.Extensions.Mvvm.ViewModels;

namespace H.VisionMaster.NodeGroup.Groups.SrcImages;

[Icon(FontIcons.Camera)]
[Display(Name = "图像数据源", Description = "设置输入图像", Order = 10000)]
public class SrcImageDataGroup : NodeDataGroupBase, IImageDataGroup
{
    protected override IEnumerable<INodeData> CreateNodeDatas()
    {
        return this.GetType().Assembly.GetInstances<ISrcImageGroupableNodeData>().OrderBy(x => x.Order); ;
    }
}

public interface ISrcImageGroupableNodeData : INodeData, IDisplayBindable
{

}
