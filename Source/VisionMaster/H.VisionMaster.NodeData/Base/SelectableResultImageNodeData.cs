// Copyright (c) HeBianGu Authors. All Rights Reserved. 
// Author: HeBianGu 
// Github: https://github.com/HeBianGu/WPF-Control 
// Document: https://hebiangu.github.io/WPF-Control-Docs  
// QQ:908293466 Group:971261058 
// bilibili: https://space.bilibili.com/370266611 
// Licensed under the MIT License (the "License")

using H.Controls.Form.PropertyItem.Attribute.SourcePropertyItem;
using H.Controls.Form.PropertyItem.ComboBoxPropertyItems;
using H.VisionMaster.NodeData.ResultImages;
using System.Text.Json.Serialization;

namespace H.VisionMaster.NodeData.Base;

public interface ISelectableResultImageNode<T> where T : IDisposable
{
    IVisionResultImage<T> SelectedResultImage { get; set; }
}

public abstract class SelectableResultImageNodeData<T> : ROINodeData<T>, ISelectableResultImageNode<T> where T : IDisposable
{
    private IVisionResultImage<T> _selectedResultImage;
    [JsonIgnore]
    [MethodNameSourcePropertyItem(typeof(ComboBoxPropertyItem), nameof(GetSelectableSrcNodeDatas))]
    [Display(Name = "输入图像源", GroupName = VisionPropertyGroupNames.BaseParameters, Order = -1)]
    public IVisionResultImage<T> SelectedResultImage
    {
        get { return _selectedResultImage; }
        set
        {
            _selectedResultImage = value;
            RaisePropertyChanged();
        }
    }

    public IEnumerable<IVisionResultImage<T>> GetSelectableSrcNodeDatas()
    {
        return this.AllFromNodeDatas.OfType<IVisionNodeData<T>>().SelectMany(x => x.ResultImages);
    }

}