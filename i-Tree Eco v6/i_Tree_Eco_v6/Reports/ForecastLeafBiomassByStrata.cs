﻿// Decompiled with JetBrains decompiler
// Type: i_Tree_Eco_v6.Reports.ForecastLeafBiomassByStrata
// Assembly: i-Tree Eco v6.x64, Version=6.0.29.0, Culture=neutral, PublicKeyToken=null
// MVID: E695D7ED-407B-4C7B-B817-3F1C5BB20211
// Assembly location: C:\Program Files (x86)\i-Tree\EcoV6\i-Tree Eco v6.x64.exe

using C1.C1Preview;
using Eco.Domain.v6;
using System;
using System.Drawing;
using System.Linq;

namespace i_Tree_Eco_v6.Reports
{
  public class ForecastLeafBiomassByStrata : ForecastStrataReport
  {
    public ForecastLeafBiomassByStrata()
    {
      this.ReportTitle = i_Tree_Eco_v6.Resources.Strings.ReportTitleLeafBiomassOverTimeByStratum;
      this.stackedBarChartTitle = i_Tree_Eco_v6.Resources.Strings.LeafBiomassOfTreesOverTime;
      this.Strata_ForecastedYear_DataValue_FromCohortResults(CohortResultDataType.LeafBiomass);
    }

    public override void InitDocument(C1PrintDocument C1doc)
    {
      base.InitDocument(C1doc);
      double num = 0.0;
      if (this.results.Count > 0)
        num = this.results.Average<CohortResult>((Func<CohortResult, double>) (x => x.DataValue));
      if (this.curYear.Unit == YearUnit.English)
        num *= 0.45359236;
      if (num > this.thousand)
      {
        this.dataValueHeading = ReportUtil.FormatInlineHeaderUnitsStr(i_Tree_Eco_v6.Resources.Strings.LeafBiomass, ReportBase.TonnesUnits());
        this.SetConvertRatio(Conversions.KgLbToMetricTonShortTon);
        this.dataValueTableFormatString = "N2";
      }
      else
      {
        this.dataValueHeading = ReportUtil.FormatInlineHeaderUnitsStr(i_Tree_Eco_v6.Resources.Strings.LeafBiomass, ReportBase.KilogramsUnits());
        this.SetConvertRatio(Conversions.KgLbToKgLb);
        this.dataValueTableFormatString = "N1";
      }
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
        RenderObject chartRenderObject = (RenderObject) ReportUtil.CreateChartRenderObject(this.CreatePerStrataChart(string.Format(i_Tree_Eco_v6.Resources.Strings.LeafBiomassOfStratumDescTreesOverTime, !this.curYear.RecordStrata ? (object) i_Tree_Eco_v6.Resources.Strings.StudyArea : (object) lstStratum.Description), lstStratum.Id), g, C1doc, 1.0, 0.79);
        C1doc.Body.Children.Add(chartRenderObject);
      }
      C1doc.Body.Children.Add((RenderObject) this.CreateForecastStrataTable());
    }
  }
}
