// Copyright (c) HeBianGu Authors. All Rights Reserved. 
// Author: HeBianGu 
// Github: https://github.com/HeBianGu/WPF-Control 
// Document: https://hebiangu.github.io/WPF-Control-Docs  
// QQ:908293466 Group:971261058 
// bilibili: https://space.bilibili.com/370266611 
// Licensed under the MIT License (the "License")

using H.Controls.Diagram.Presenter.Flowables;
using H.Controls.Diagram.Presenter.NodeDatas.Base;
using H.VisionMaster.NodeData.ResultImages;

namespace H.VisionMaster.NodeData.Base;

public interface IVisionNodeData : IFlowableNodeData, IResultPresenterNodeData, IResultImageSourceNodeData, IHelpNodeData
{
    bool UseInvokedPart { get; set; }
}

public interface IVideoCaptureNodeData : IVisionNodeData
{

}

public interface IVisionNodeData<T> : IVisionNodeData
{
    public List<IVisionResultImage<T>> ResultImages { get; }

    public T Mat { get; }
}
