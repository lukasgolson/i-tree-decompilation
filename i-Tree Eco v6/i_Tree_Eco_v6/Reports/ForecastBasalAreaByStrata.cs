﻿// Decompiled with JetBrains decompiler
// Type: i_Tree_Eco_v6.Reports.ForecastBasalAreaByStrata
// Assembly: i-Tree Eco v6.x64, Version=6.0.29.0, Culture=neutral, PublicKeyToken=null
// MVID: E695D7ED-407B-4C7B-B817-3F1C5BB20211
// Assembly location: C:\Program Files (x86)\i-Tree\EcoV6\i-Tree Eco v6.x64.exe

using C1.C1Preview;
using Eco.Domain.v6;
using System.Drawing;

namespace i_Tree_Eco_v6.Reports
{
  public class ForecastBasalAreaByStrata : ForecastStrataReport
  {
    public ForecastBasalAreaByStrata()
    {
      this.ReportTitle = i_Tree_Eco_v6.Resources.Strings.ReportTitleBasalAreaOverTimeByStrata;
      this.stackedBarChartTitle = i_Tree_Eco_v6.Resources.Strings.BasalAreaOfTreesOverTime;
      this.Strata_ForecastedYear_DataValue_FromCohortResults(CohortResultDataType.BasalArea);
    }

    public override void InitDocument(C1PrintDocument C1doc)
    {
      base.InitDocument(C1doc);
      this.dataValueHeading = ReportUtil.FormatInlineHeaderUnitsStr(i_Tree_Eco_v6.Resources.Strings.TotalBasalArea, this.SquareMeterUnits());
      this.SetConvertRatio(Conversions.SqInSqCmToSqFtSqM);
      this.GetStrataResultsMax();
    }

    public override void RenderBody(C1PrintDocument C1doc, Graphics g)
    {
      if (this.StackedBarChartNeeded())
      {
        RenderObject chartRenderObject = (RenderObject) ReportUtil.CreateChartRenderObject(this.CreateStackedBarChart(), g, C1doc, 1.0, 0.79);
        C1doc.Body.Children.Add(chartRenderObject);
      }
      foreach (Strata lstStratum in this.lstStrata)
      {
        RenderObject chartRenderObject = (RenderObject) ReportUtil.CreateChartRenderObject(this.CreatePerStrataChart(string.Format(i_Tree_Eco_v6.Resources.Strings.LeafBiomassPerUnitAreaForStrataDescTreesOverTime, !this.curYear.RecordStrata ? (object) i_Tree_Eco_v6.Resources.Strings.StudyArea : (object) lstStratum.Description), lstStratum.Id), g, C1doc, 1.0, 0.79);
        C1doc.Body.Children.Add(chartRenderObject);
      }
      C1doc.Body.Children.Add((RenderObject) this.CreateForecastStrataTable());
    }
  }
}
