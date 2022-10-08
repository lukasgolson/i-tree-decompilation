﻿// Decompiled with JetBrains decompiler
// Type: EcoIpedReportGenerator.PestSignSymptomDetailsByStratumRG
// Assembly: i-Tree Eco v6.x64, Version=6.0.29.0, Culture=neutral, PublicKeyToken=null
// MVID: E695D7ED-407B-4C7B-B817-3F1C5BB20211
// Assembly location: C:\Program Files (x86)\i-Tree\EcoV6\i-Tree Eco v6.x64.exe

using C1.C1Preview;
using Eco.Domain.Properties;
using i_Tree_Eco_v6.Reports;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace EcoIpedReportGenerator
{
  internal class PestSignSymptomDetailsByStratumRG : ReportGenerator, IBindable
  {
    private List<DataBinding> m_bindings = new List<DataBinding>();
    private PestData m_output;

    public List<DataBinding> Bindings() => this.m_bindings;

    public PestSignSymptomDetailsByStratumRG()
    {
      this.m_output = new PestData();
      DataBinding dataBinding = new DataBinding(0);
      DataTable dataTable = staticData.DsData.Tables["EstMapLanduse"].Copy();
      DataRow row = dataTable.NewRow();
      row["LanduseId"] = (object) -1;
      row["LanduseName"] = (object) i_Tree_Eco_v6.Resources.Strings.AllStrata;
      dataTable.Rows.Add(row);
      dataTable.DefaultView.Sort = "LanduseId";
      dataBinding.DisplayMember = "LanduseName";
      dataBinding.Description = v6Strings.Strata_SingularName;
      dataBinding.ValueMember = "LanduseId";
      dataBinding.DataSource = (object) dataTable;
      this.m_bindings.Add(dataBinding);
    }

    public override object Generate()
    {
      PestSignSymptomDetailsByStratum detailsByStratum = new PestSignSymptomDetailsByStratum((int) this.m_bindings[0].Value);
      C1PrintDocument c1PrintDocument = new C1PrintDocument();
      C1PrintDocument C1doc = c1PrintDocument;
      detailsByStratum.RenderBody(C1doc, (Graphics) null);
      return (object) c1PrintDocument;
    }
  }
}
