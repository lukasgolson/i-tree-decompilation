﻿// Decompiled with JetBrains decompiler
// Type: UFORE.BioEmission.MonthlyO3Summary
// Assembly: UFORE, Version=1.1.16.0, Culture=neutral, PublicKeyToken=null
// MVID: 58461BF3-EED8-45BF-BAF2-1F014CDA7667
// Assembly location: C:\Program Files (x86)\i-Tree\EcoV6\UFORE.dll

using System;
using System.Collections.Generic;
using System.Data.OleDb;
using UFORE.Deposition;

namespace UFORE.BioEmission
{
  internal class MonthlyO3Summary
  {
    private const int PPM2PPB = 1000;
    private int Month;
    private double totalRemoved;
    private double net;
    private double changeInForestPct;
    private double changeInForestPPB;
    private double changeInLandusePct;
    private double changeInLandusePPB;

    public static void CalcSummary(
      City ctData,
      ref List<DryDeposition> O3List,
      DryDeposition.VEG_TYPE veg,
      bool inv,
      OleDbConnection cnBioEDB,
      bool bDaytime)
    {
      MonthlyO3Summary monthlyO3Summary = new MonthlyO3Summary();
      monthlyO3Summary.AddFields(cnBioEDB, bDaytime);
      List<Formation> formationList = new List<Formation>();
      Formation.ReadMonthlyO3FormationRecords(cnBioEDB, ref formationList, bDaytime);
      for (int index = 0; index < 12; ++index)
      {
        monthlyO3Summary.CalcSummary(ctData, ref O3List, ref formationList, index + 1, veg, inv, bDaytime);
        monthlyO3Summary.InsertSummary(cnBioEDB, bDaytime);
      }
    }

    public void AddFields(OleDbConnection cn, bool daytime)
    {
      string tbl = daytime ? "06_MonthlyDaytimeSummary" : "05_MonthlySummary";
      AccessFunc.AppendField(cn, tbl, "O3 removed", "DOUBLE");
      AccessFunc.AppendField(cn, tbl, "O3 net (formed-removed)", "DOUBLE");
      AccessFunc.AppendField(cn, tbl, "O3 change in forest air conc %", "DOUBLE");
      AccessFunc.AppendField(cn, tbl, "O3 change in forest air conc ppb", "DOUBLE");
      AccessFunc.AppendField(cn, tbl, "O3 change in city air conc %", "DOUBLE");
      AccessFunc.AppendField(cn, tbl, "O3 change in city air conc ppb", "DOUBLE");
    }

    public void CalcSummary(
      City ctData,
      ref List<DryDeposition> ddList,
      ref List<Formation> frmList,
      int mon,
      DryDeposition.VEG_TYPE veg,
      bool bInv,
      bool daytime)
    {
      double num1 = 0.0;
      double num2 = 0.0;
      double num3 = 0.0;
      double num4 = 0.0;
      int num5 = 0;
      double num6 = !bInv ? Math.Pow(10.0, -9.0) : Math.Pow(10.0, -6.0);
      double num7 = !bInv ? Math.Pow(10.0, -3.0) : 1.0;
      double num8 = veg == DryDeposition.VEG_TYPE.TREE ? ctData.TreePctCov : ctData.ShrubPctCov;
      this.Month = mon;
      for (int index = 0; index < frmList.Count; ++index)
      {
        if (frmList[index].Month == this.Month)
          num1 += frmList[index].O3Formed;
      }
      for (int index = 0; index < ddList.Count; ++index)
      {
        if (ddList[index].TimeStamp.Month == this.Month)
        {
          if (ddList[index].IsprLtCor > 0.0)
          {
            num2 += ddList[index].Flux;
            num3 += ddList[index].uGm3 * ddList[index].MixHt;
            num4 += ddList[index].PPM * 1000.0;
            ++num5;
          }
          else if (!daytime)
          {
            num2 += ddList[index].Flux;
            num3 += ddList[index].uGm3 * ddList[index].MixHt;
            num4 += ddList[index].PPM * 1000.0;
            ++num5;
          }
        }
      }
      double num9 = num5 == 0 ? 0.0 : num4 / (double) num5;
      double num10 = num3 * (ctData.AreaM2 * num8 / 100.0) * num6;
      double num11 = num3 * ctData.AreaM2 * num6;
      this.totalRemoved = num2 * (ctData.AreaM2 * num8 / 100.0) * num7;
      this.net = num1 - this.totalRemoved;
      double num12 = num10 - this.net;
      this.changeInForestPct = num12 == 0.0 ? 0.0 : this.net / num12 * 100.0;
      this.changeInForestPPB = num9 * this.changeInForestPct / 100.0;
      double net = this.net;
      double num13 = num11 - net;
      this.changeInLandusePct = num13 == 0.0 ? 0.0 : this.net / num13 * 100.0;
      this.changeInLandusePPB = num9 * this.changeInLandusePct / 100.0;
    }

    public void InsertSummary(OleDbConnection cn, bool daytime)
    {
      using (OleDbCommand oleDbCommand = new OleDbCommand())
      {
        string str = daytime ? "06_MonthlyDaytimeSummary" : "05_MonthlySummary";
        oleDbCommand.Connection = cn;
        oleDbCommand.CommandText = "UPDATE " + str + " SET [O3 removed] = " + this.totalRemoved.ToString() + ",[O3 net (formed-removed)] = " + this.net.ToString() + ",[O3 change in forest air conc %] = " + this.changeInForestPct.ToString() + ",[O3 change in forest air conc ppb] = " + this.changeInForestPPB.ToString() + ",[O3 change in city air conc %] = " + this.changeInLandusePct.ToString() + ",[O3 change in city air conc ppb] = " + this.changeInLandusePPB.ToString() + " WHERE [Month]=" + this.Month.ToString() + ";";
        oleDbCommand.ExecuteNonQuery();
      }
    }
  }
}
