// Copyright (c) HeBianGu Authors. All Rights Reserved. 
// Author: HeBianGu 
// Github: https://github.com/HeBianGu/WPF-Control 
// Document: https://hebiangu.github.io/WPF-Control-Docs  
// QQ:908293466 Group:971261058 
// bilibili: https://space.bilibili.com/370266611 
// Licensed under the MIT License (the "License")

using H.Extensions.TypeConverter;

namespace H.VisionMaster.NodeData.ROIPresenters;

[Display(Name = "输入")]
public class InputROI : ROIBase, IROI
{
    private Rect _rect;
    [TypeConverter(typeof(IntRectConverter))]
    public Rect Rect
    {
        get { return _rect; }
        set
        {
            _rect = value;
            RaisePropertyChanged();
        }
    }
}

