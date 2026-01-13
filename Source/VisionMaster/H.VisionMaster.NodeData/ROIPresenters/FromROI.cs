// Copyright (c) HeBianGu Authors. All Rights Reserved. 
// Author: HeBianGu 
// Github: https://github.com/HeBianGu/WPF-Control 
// Document: https://hebiangu.github.io/WPF-Control-Docs  
// QQ:908293466 Group:971261058 
// bilibili: https://space.bilibili.com/370266611 
// Licensed under the MIT License (the "License")

using H.Controls.Diagram.Presenter.Extensions;
using H.Extensions.TypeConverter;
using H.VisionMaster.NodeData.Base;
using System.Text.Json.Serialization;

namespace H.VisionMaster.NodeData.ROIPresenters;

[Display(Name = "继承")]
public class FromROI : ROIBase, IROI
{
    [JsonIgnore]
    public IROINodeData ROINodeData { get; set; }

    [JsonIgnore]
    [TypeConverter(typeof(IntRectConverter))]
    public Rect Rect
    {
        get
        {
            IROINodeData from = this.ROINodeData.GetFromNodeDatas().OfType<IROINodeData>().FirstOrDefault();
            return from == null ? Rect.Empty : from.ROI.Rect;
        }
    }

}

