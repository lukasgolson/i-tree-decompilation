﻿// Decompiled with JetBrains decompiler
// Type: i_Tree_Eco_v6.Reports.OtherThreeLookupReport
// Assembly: i-Tree Eco v6.x64, Version=6.0.29.0, Culture=neutral, PublicKeyToken=null
// MVID: E695D7ED-407B-4C7B-B817-3F1C5BB20211
// Assembly location: C:\Program Files (x86)\i-Tree\EcoV6\i-Tree Eco v6.x64.exe

using Eco.Domain.Properties;
using Eco.Domain.v6;
using i_Tree_Eco_v6.Resources;

namespace i_Tree_Eco_v6.Reports
{
  public class OtherThreeLookupReport : LookupReport<OtherThree>
  {
    public OtherThreeLookupReport()
      : base("OtherThree", "", "")
    {
      this.ReportTitle = this.FormatReportTwithSubtitle(string.IsNullOrEmpty(this.curYear.OtherThree) ? v6Strings.FieldThree_SingularName : this.curYear.OtherThree, Strings.BySpeciesAndDBH);
      this.HelpTopic = "CustomFieldsReport";
    }
  }
}
