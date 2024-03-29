﻿// Decompiled with JetBrains decompiler
// Type: i_Tree_Eco_v6.Reports.Chart.IsopreneResults
// Assembly: i-Tree Eco v6.x64, Version=6.0.29.0, Culture=neutral, PublicKeyToken=null
// MVID: E695D7ED-407B-4C7B-B817-3F1C5BB20211
// Assembly location: C:\Program Files (x86)\i-Tree\EcoV6\i-Tree Eco v6.x64.exe

using i_Tree_Eco_v6.Resources;

namespace i_Tree_Eco_v6.Reports.Chart
{
  internal class IsopreneResults : HourlyVOCResults
  {
    public IsopreneResults(string type, string sType)
      : base("Isoprene", type, string.Format(Strings.ValueByValue, (object) Strings.IsopreneEmitted, (object) sType))
    {
      this.YAxisTitle = Strings.IsopreneEmitted;
      this.TableYTitle = Strings.IsopreneEmitted;
    }
  }
}
