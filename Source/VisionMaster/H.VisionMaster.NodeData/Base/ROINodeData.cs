// Copyright (c) HeBianGu Authors. All Rights Reserved. 
// Author: HeBianGu 
// Github: https://github.com/HeBianGu/WPF-Control 
// Document: https://hebiangu.github.io/WPF-Control-Docs  
// QQ:908293466 Group:971261058 
// bilibili: https://space.bilibili.com/370266611 
// Licensed under the MIT License (the "License")

using H.Controls.Diagram.Presenter.DiagramDatas.Base;
using H.Controls.Diagram.Presenter.Flowables;
using H.Controls.Diagram.Presenter.NodeDatas.Base;
using H.Controls.Form.PropertyItem.Attribute;
using H.Controls.Form.PropertyItem.Attribute.SourcePropertyItem;
using H.Controls.Form.PropertyItem.ComboBoxPropertyItems;
using H.VisionMaster.NodeData.ROIPresenters;

namespace H.VisionMaster.NodeData.Base;

public interface IROINodeData : IDiagramableNodeData
{
    IROI ROI { get; set; }
}

public abstract class ROINodeData<T> : VisionNodeData<T>, IROINodeData where T : IDisposable
{
    protected ROINodeData()
    {
        this.FromROI = new FromROI() { ROINodeData = this };
        this.DrawROI = new DrawROI();
        this.InputROI = new InputROI();
        this.ROI = this.FromROI;
    }

    private IROI _ROI;
    [DisplayMemberPath("Name")]
    [MethodNameSourcePropertyItem(typeof(PresenterComboBoxPropertyItem), nameof(GetROIs))]
    [Display(Name = "ROI范围", GroupName = VisionPropertyGroupNames.BaseParameters, Order = 1000)]
    public IROI ROI
    {
        get { return _ROI; }
        set
        {
            _ROI = value;
            RaisePropertyChanged();
        }
    }
    public FromROI FromROI { get; set; }
    public DrawROI DrawROI { get; set; }
    public InputROI InputROI { get; set; }

    public IEnumerable<IROI> GetROIs()
    {
        this.DrawROI.ImageSource = this.ResultImageSource;
        yield return this.FromROI;
        yield return this.DrawROI;
        yield return this.InputROI;
    }

    public override IFlowableResult Invoke(IFlowableLinkData previors, IFlowableDiagramData diagram)
    {
        IFlowableResult r = base.Invoke(previors, diagram);
        this.DrawROI.ImageSource = this.ResultImageSource;
        return r;
    }
}

