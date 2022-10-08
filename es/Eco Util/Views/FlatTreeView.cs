﻿// Decompiled with JetBrains decompiler
// Type: Eco.Util.Views.FlatTreeView
// Assembly: Eco Util, Version=1.1.6757.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C6433F7-3274-4315-B6F4-90179805B344
// Assembly location: C:\Program Files (x86)\i-Tree\EcoV6\Eco Util.dll

using Eco.Domain.v6;
using Eco\u0020Util;
using NHibernate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Eco.Util.Views
{
  public class FlatTreeView : ICloneable, INotifyPropertyChanged, INotifyPropertyChanging
  {
    private Tree m_tree;
    private Crown m_crown;
    private IPED m_iped;
    private Stem[] m_stems;
    private Building[] m_buildings;

    public event PropertyChangedEventHandler PropertyChanged;

    public FlatTreeView() => this.Tree = new Tree();

    public FlatTreeView(ISession session, Tree tree)
    {
      this.Session = session;
      this.Tree = tree;
    }

    public virtual ISession Session
    {
      get => this.\u003CSession\u003Ek__BackingField;
      set
      {
        if (this.\u003CSession\u003Ek__BackingField == value)
          return;
        this.OnPropertyChanging(nameof (Session));
        this.\u003CSession\u003Ek__BackingField = value;
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.Session);
      }
    }

    private void InitBuildings()
    {
      int num = 1;
      this.m_buildings = new Building[4];
      List<Building> list = this.m_tree.Buildings.ToList<Building>();
      list.Sort((Comparison<Building>) ((b1, b2) => b1.Id.CompareTo(b2.Id)));
      if (list.Count > 0)
        num = list[list.Count - 1].Id + 1;
      for (int index = 0; index < this.m_buildings.Length; ++index)
      {
        if (index < list.Count)
          this.m_buildings[index] = list[index];
        else
          this.m_buildings[index] = new Building()
          {
            Id = num++
          };
      }
    }

    private void InitStems()
    {
      int num = 1;
      this.m_stems = new Stem[6];
      List<Stem> list = this.m_tree.Stems.ToList<Stem>();
      list.Sort((Comparison<Stem>) ((s1, s2) => s1.Id.CompareTo(s2.Id)));
      if (list.Count > 0)
        num = list[list.Count - 1].Id + 1;
      for (int index = 0; index < 6; ++index)
      {
        if (index < list.Count)
          this.m_stems[index] = list[index];
        else
          this.m_stems[index] = new Stem() { Id = num++ };
      }
    }

    public virtual Tree Tree
    {
      get => this.m_tree;
      set
      {
        if (this.m_tree == value)
          return;
        if (this.m_tree != null && this.m_tree != value)
          this.m_tree.PropertyChanged -= new PropertyChangedEventHandler(this.Tree_PropertyChanged);
        this.OnPropertyChanging("Id");
        this.OnPropertyChanging("UserId");
        this.OnPropertyChanging("Plot");
        this.OnPropertyChanging("Strata");
        this.OnPropertyChanging("PlotLandUse");
        this.OnPropertyChanging("MaintRec");
        this.OnPropertyChanging("MaintTask");
        this.OnPropertyChanging("SidewalkDamage");
        this.OnPropertyChanging("WireConflict");
        this.OnPropertyChanging("OtherOne");
        this.OnPropertyChanging("OtherTwo");
        this.OnPropertyChanging("OtherThree");
        this.OnPropertyChanging("IsDead");
        this.OnPropertyChanging("CityManaged");
        this.OnPropertyChanging("Direction");
        this.OnPropertyChanging("Distance");
        this.OnPropertyChanging("Status");
        this.OnPropertyChanging("Species");
        this.OnPropertyChanging("Height");
        this.OnPropertyChanging("PercentImpervious");
        this.OnPropertyChanging("PercentShrub");
        this.OnPropertyChanging("StreetTree");
        this.OnPropertyChanging("SiteType");
        this.OnPropertyChanging("Street");
        this.OnPropertyChanging("Address");
        this.OnPropertyChanging("LocSite");
        this.OnPropertyChanging("LocNo");
        this.OnPropertyChanging("Latitude");
        this.OnPropertyChanging("Longitude");
        this.OnPropertyChanging("SurveyDate");
        this.OnPropertyChanging("NoteThisTree");
        this.OnPropertyChanging("Comments");
        this.OnPropertyChanging(nameof (Tree));
        this.m_tree = value;
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.Strata);
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.PlotLandUse);
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.IsDead);
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.Tree);
        this.m_crown = this.m_tree?.Crown;
        this.m_iped = this.m_tree?.IPED;
        this.InitBuildings();
        this.InitStems();
        if (this.m_tree != null)
          this.m_tree.PropertyChanged += new PropertyChangedEventHandler(this.Tree_PropertyChanged);
        if (this.m_crown == null)
        {
          this.m_crown = new Crown();
          this.m_tree.Crown = this.m_crown;
        }
        if (this.m_iped != null)
          return;
        this.m_iped = new IPED();
        this.m_tree.IPED = this.m_iped;
      }
    }

    private void Tree_PropertyChanged(object sender, PropertyChangedEventArgs e) => this.OnPropertyChanged(e);

    protected void OnPropertyChanged(PropertyChangedEventArgs eventArgs)
    {
      PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
      if (propertyChanged == null)
        return;
      propertyChanged((object) this, eventArgs);
    }

    public virtual Crown Crown => this.m_crown;

    public virtual IPED IPED => this.m_iped;

    public virtual int Id
    {
      get => this.m_tree.Id;
      set
      {
        if (this.Id == value)
          return;
        this.OnPropertyChanging(nameof (Id));
        this.m_tree.Id = value;
      }
    }

    public virtual string UserId
    {
      get => this.m_tree.UserId;
      set
      {
        if (string.Equals(this.UserId, value, StringComparison.Ordinal))
          return;
        this.OnPropertyChanging(nameof (UserId));
        this.m_tree.UserId = value;
      }
    }

    public virtual Plot Plot
    {
      get => this.m_tree.Plot;
      set
      {
        if (this.Plot == value)
          return;
        this.OnPropertyChanging(nameof (Plot));
        if (this.Session != null)
        {
          if (this.m_tree.Plot != null && this.m_tree.Plot.Trees.Contains(this.m_tree))
            this.m_tree.Plot.Trees.Remove(this.m_tree);
          value?.Trees.Add(this.m_tree);
        }
        this.m_tree.Plot = value;
      }
    }

    public virtual Strata Strata
    {
      get => this.m_tree.Plot != null ? this.m_tree.Plot.Strata : (Strata) null;
      set
      {
        if (this.Strata == value)
          return;
        this.OnPropertyChanging(nameof (Strata));
        if (this.m_tree.Plot != null)
          this.m_tree.Plot.Strata = value;
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.Strata);
      }
    }

    public virtual PlotLandUse PlotLandUse
    {
      get => this.m_tree.PlotLandUse;
      set
      {
        if (this.PlotLandUse == value)
          return;
        this.OnPropertyChanging(nameof (PlotLandUse));
        this.m_tree.PlotLandUse = value;
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.PlotLandUse);
      }
    }

    public virtual MaintRec MaintRec
    {
      get => this.m_tree.MaintRec;
      set
      {
        if (this.MaintRec == value)
          return;
        this.OnPropertyChanging(nameof (MaintRec));
        this.m_tree.MaintRec = value;
      }
    }

    public virtual MaintTask MaintTask
    {
      get => this.m_tree.MaintTask;
      set
      {
        if (this.MaintTask == value)
          return;
        this.OnPropertyChanging(nameof (MaintTask));
        this.m_tree.MaintTask = value;
      }
    }

    public virtual Sidewalk SidewalkDamage
    {
      get => this.m_tree.SidewalkDamage;
      set
      {
        if (this.SidewalkDamage == value)
          return;
        this.OnPropertyChanging(nameof (SidewalkDamage));
        this.m_tree.SidewalkDamage = value;
      }
    }

    public virtual WireConflict WireConflict
    {
      get => this.m_tree.WireConflict;
      set
      {
        if (this.WireConflict == value)
          return;
        this.OnPropertyChanging(nameof (WireConflict));
        this.m_tree.WireConflict = value;
      }
    }

    public virtual OtherOne OtherOne
    {
      get => this.m_tree.OtherOne;
      set
      {
        if (this.OtherOne == value)
          return;
        this.OnPropertyChanging(nameof (OtherOne));
        this.m_tree.OtherOne = value;
      }
    }

    public virtual OtherTwo OtherTwo
    {
      get => this.m_tree.OtherTwo;
      set
      {
        if (this.OtherTwo == value)
          return;
        this.OnPropertyChanging(nameof (OtherTwo));
        this.m_tree.OtherTwo = value;
      }
    }

    public virtual OtherThree OtherThree
    {
      get => this.m_tree.OtherThree;
      set
      {
        if (this.OtherThree == value)
          return;
        this.OnPropertyChanging(nameof (OtherThree));
        this.m_tree.OtherThree = value;
      }
    }

    public virtual bool IsDead => this.m_tree.Crown.Condition != null && this.m_tree.Crown.Condition.PctDieback == 100.0;

    public virtual float CrownBaseHeight
    {
      get => this.m_crown.BaseHeight;
      set
      {
        if (this.CrownBaseHeight == value)
          return;
        this.OnPropertyChanging(nameof (CrownBaseHeight));
        this.m_crown.BaseHeight = value;
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.CrownBaseHeight);
      }
    }

    public virtual float CrownTopHeight
    {
      get => this.m_crown.TopHeight;
      set
      {
        if (this.CrownTopHeight == value)
          return;
        this.OnPropertyChanging(nameof (CrownTopHeight));
        this.m_crown.TopHeight = value;
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.CrownTopHeight);
      }
    }

    public virtual float CrownWidthNS
    {
      get => this.m_crown.WidthNS;
      set
      {
        if (this.CrownWidthNS == value)
          return;
        this.OnPropertyChanging(nameof (CrownWidthNS));
        this.m_crown.WidthNS = value;
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.CrownWidthNS);
      }
    }

    public virtual float CrownWidthEW
    {
      get => this.m_crown.WidthEW;
      set
      {
        if (this.CrownWidthEW == value)
          return;
        this.OnPropertyChanging(nameof (CrownWidthEW));
        this.m_crown.WidthEW = value;
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.CrownWidthEW);
      }
    }

    public virtual CrownLightExposure CrownLightExposure
    {
      get => this.m_crown.LightExposure;
      set
      {
        if (this.CrownLightExposure == value)
          return;
        this.OnPropertyChanging(nameof (CrownLightExposure));
        this.m_crown.LightExposure = value;
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.CrownLightExposure);
      }
    }

    public virtual PctMidRange CrownPercentMissing
    {
      get => this.m_crown.PercentMissing;
      set
      {
        if (this.CrownPercentMissing == value)
          return;
        this.OnPropertyChanging(nameof (CrownPercentMissing));
        this.m_crown.PercentMissing = value;
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.CrownPercentMissing);
      }
    }

    public virtual Condition CrownCondition
    {
      get => this.m_crown.Condition;
      set
      {
        if (this.CrownCondition == value)
          return;
        this.OnPropertyChanging(nameof (CrownCondition));
        this.m_crown.Condition = value;
        if (value != null && value.PctDieback == 100.0)
        {
          this.CrownBaseHeight = -1f;
          this.CrownTopHeight = -1f;
          this.CrownWidthEW = -1f;
          this.CrownWidthNS = -1f;
          this.CrownLightExposure = CrownLightExposure.NotEntered;
          this.CrownPercentMissing = PctMidRange.PR100;
          this.PercentImpervious = PctMidRange.PRINV;
          this.PercentShrub = PctMidRange.PRINV;
        }
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.CrownCondition);
      }
    }

    public virtual int IPEDTSDieback
    {
      get => this.m_iped.TSDieback;
      set
      {
        if (this.IPEDTSDieback == value)
          return;
        this.OnPropertyChanging(nameof (IPEDTSDieback));
        this.m_iped.TSDieback = value;
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.IPEDTSDieback);
      }
    }

    public virtual int IPEDTSEpiSprout
    {
      get => this.m_iped.TSEpiSprout;
      set
      {
        if (this.IPEDTSEpiSprout == value)
          return;
        this.OnPropertyChanging(nameof (IPEDTSEpiSprout));
        this.m_iped.TSEpiSprout = value;
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.IPEDTSEpiSprout);
      }
    }

    public virtual int IPEDTSWiltFoli
    {
      get => this.m_iped.TSWiltFoli;
      set
      {
        if (this.IPEDTSWiltFoli == value)
          return;
        this.OnPropertyChanging(nameof (IPEDTSWiltFoli));
        this.m_iped.TSWiltFoli = value;
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.IPEDTSWiltFoli);
      }
    }

    public virtual int IPEDTSEnvStress
    {
      get => this.m_iped.TSEnvStress;
      set
      {
        if (this.IPEDTSEnvStress == value)
          return;
        this.OnPropertyChanging(nameof (IPEDTSEnvStress));
        this.m_iped.TSEnvStress = value;
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.IPEDTSEnvStress);
      }
    }

    public virtual int IPEDTSHumStress
    {
      get => this.m_iped.TSHumStress;
      set
      {
        if (this.IPEDTSHumStress == value)
          return;
        this.OnPropertyChanging(nameof (IPEDTSHumStress));
        this.m_iped.TSHumStress = value;
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.IPEDTSHumStress);
      }
    }

    public virtual string IPEDTSNotes
    {
      get => this.m_iped.TSNotes;
      set
      {
        if (string.Equals(this.IPEDTSNotes, value, StringComparison.Ordinal))
          return;
        this.OnPropertyChanging(nameof (IPEDTSNotes));
        this.m_iped.TSNotes = value;
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.IPEDTSNotes);
      }
    }

    public virtual int IPEDFTChewFoli
    {
      get => this.m_iped.FTChewFoli;
      set
      {
        if (this.IPEDFTChewFoli == value)
          return;
        this.OnPropertyChanging(nameof (IPEDFTChewFoli));
        this.m_iped.FTChewFoli = value;
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.IPEDFTChewFoli);
      }
    }

    public virtual int IPEDFTDiscFoli
    {
      get => this.m_iped.FTDiscFoli;
      set
      {
        if (this.IPEDFTDiscFoli == value)
          return;
        this.OnPropertyChanging(nameof (IPEDFTDiscFoli));
        this.m_iped.FTDiscFoli = value;
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.IPEDFTDiscFoli);
      }
    }

    public virtual int IPEDFTAbnFoli
    {
      get => this.m_iped.FTAbnFoli;
      set
      {
        if (this.IPEDFTAbnFoli == value)
          return;
        this.OnPropertyChanging(nameof (IPEDFTAbnFoli));
        this.m_iped.FTAbnFoli = value;
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.IPEDFTAbnFoli);
      }
    }

    public virtual int IPEDFTInsectSigns
    {
      get => this.m_iped.FTInsectSigns;
      set
      {
        if (this.IPEDFTInsectSigns == value)
          return;
        this.OnPropertyChanging(nameof (IPEDFTInsectSigns));
        this.m_iped.FTInsectSigns = value;
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.IPEDFTInsectSigns);
      }
    }

    public virtual int IPEDFTFoliAffect
    {
      get => this.m_iped.FTFoliAffect;
      set
      {
        if (this.IPEDFTFoliAffect == value)
          return;
        this.OnPropertyChanging(nameof (IPEDFTFoliAffect));
        this.m_iped.FTFoliAffect = value;
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.IPEDFTFoliAffect);
      }
    }

    public virtual string IPEDFTNotes
    {
      get => this.m_iped.FTNotes;
      set
      {
        if (string.Equals(this.IPEDFTNotes, value, StringComparison.Ordinal))
          return;
        this.OnPropertyChanging(nameof (IPEDFTNotes));
        this.m_iped.FTNotes = value;
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.IPEDFTNotes);
      }
    }

    public virtual int IPEDBBInsectSigns
    {
      get => this.m_iped.BBInsectSigns;
      set
      {
        if (this.IPEDBBInsectSigns == value)
          return;
        this.OnPropertyChanging(nameof (IPEDBBInsectSigns));
        this.m_iped.BBInsectSigns = value;
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.IPEDBBInsectSigns);
      }
    }

    public virtual int IPEDBBInsectPres
    {
      get => this.m_iped.BBInsectPres;
      set
      {
        if (this.IPEDBBInsectPres == value)
          return;
        this.OnPropertyChanging(nameof (IPEDBBInsectPres));
        this.m_iped.BBInsectPres = value;
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.IPEDBBInsectPres);
      }
    }

    public virtual int IPEDBBDiseaseSigns
    {
      get => this.m_iped.BBDiseaseSigns;
      set
      {
        if (this.IPEDBBDiseaseSigns == value)
          return;
        this.OnPropertyChanging(nameof (IPEDBBDiseaseSigns));
        this.m_iped.BBDiseaseSigns = value;
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.IPEDBBDiseaseSigns);
      }
    }

    public virtual int IPEDBBProbLoc
    {
      get => this.m_iped.BBProbLoc;
      set
      {
        if (this.IPEDBBProbLoc == value)
          return;
        this.OnPropertyChanging(nameof (IPEDBBProbLoc));
        this.m_iped.BBProbLoc = value;
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.IPEDBBProbLoc);
      }
    }

    public virtual int IPEDBBAbnGrowth
    {
      get => this.m_iped.BBAbnGrowth;
      set
      {
        if (this.IPEDBBAbnGrowth == value)
          return;
        this.OnPropertyChanging(nameof (IPEDBBAbnGrowth));
        this.m_iped.BBAbnGrowth = value;
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.IPEDBBAbnGrowth);
      }
    }

    public virtual string IPEDBBNotes
    {
      get => this.m_iped.BBNotes;
      set
      {
        if (string.Equals(this.IPEDBBNotes, value, StringComparison.Ordinal))
          return;
        this.OnPropertyChanging(nameof (IPEDBBNotes));
        this.m_iped.BBNotes = value;
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.IPEDBBNotes);
      }
    }

    public virtual int IPEDPest
    {
      get => this.m_iped.Pest;
      set
      {
        if (this.IPEDPest == value)
          return;
        this.OnPropertyChanging(nameof (IPEDPest));
        this.m_iped.Pest = value;
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.IPEDPest);
      }
    }

    private void ReplaceStem(int index)
    {
      Stem stem = this.m_stems[index];
      if (this.m_tree.Stems.Contains(stem))
      {
        this.m_tree.Stems.Remove(stem);
        if (!stem.IsTransient)
        {
          lock (this.Session)
          {
            using (ITransaction transaction = this.Session.BeginTransaction())
            {
              this.Session.Delete((object) stem);
              transaction.Commit();
            }
          }
        }
      }
      this.m_stems[index] = new Stem() { Id = stem.Id };
    }

    private void SetStemDBH(int index, double dbh)
    {
      Stem stem = this.m_stems[index];
      stem.Diameter = dbh;
      stem.Tree = this.m_tree;
      if (this.m_tree.Stems.Contains(stem))
        return;
      this.m_tree.Stems.Add(stem);
    }

    private void SetStemDBHHeight(int index, double height)
    {
      Stem stem = this.m_stems[index];
      stem.DiameterHeight = height;
      stem.Tree = this.m_tree;
      if (this.m_tree.Stems.Contains(stem))
        return;
      this.m_tree.Stems.Add(stem);
    }

    public virtual double DBH1
    {
      get => this.m_stems[0].Diameter;
      set
      {
        if (this.DBH1 == value)
          return;
        this.OnPropertyChanging(nameof (DBH1));
        this.SetStemDBH(0, value);
        if (value == -1.0)
        {
          if (this.DBH1Height != -1.0)
            this.DBH1Height = -1.0;
          this.DBH1Measured = true;
          this.ReplaceStem(0);
        }
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.DBH1);
      }
    }

    public virtual double DBH1Height
    {
      get => this.m_stems[0].DiameterHeight;
      set
      {
        if (this.DBH1Height == value)
          return;
        this.OnPropertyChanging(nameof (DBH1Height));
        this.SetStemDBHHeight(0, value);
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.DBH1Height);
      }
    }

    public virtual bool DBH1Measured
    {
      get => this.m_stems[0].Measured;
      set
      {
        if (this.DBH1Measured == value)
          return;
        this.OnPropertyChanging(nameof (DBH1Measured));
        this.m_stems[0].Measured = value;
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.DBH1Measured);
      }
    }

    public virtual double DBH2
    {
      get => this.m_stems[1].Diameter;
      set
      {
        if (this.DBH2 == value)
          return;
        this.OnPropertyChanging(nameof (DBH2));
        this.SetStemDBH(1, value);
        if (value == -1.0)
        {
          if (this.DBH2Height != -1.0)
            this.DBH2Height = -1.0;
          this.DBH2Measured = true;
          this.ReplaceStem(1);
        }
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.DBH2);
      }
    }

    public virtual double DBH2Height
    {
      get => this.m_stems[1].DiameterHeight;
      set
      {
        if (this.DBH2Height == value)
          return;
        this.OnPropertyChanging(nameof (DBH2Height));
        this.SetStemDBHHeight(1, value);
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.DBH2Height);
      }
    }

    public virtual bool DBH2Measured
    {
      get => this.m_stems[1].Measured;
      set
      {
        if (this.DBH2Measured == value)
          return;
        this.OnPropertyChanging(nameof (DBH2Measured));
        this.m_stems[1].Measured = value;
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.DBH2Measured);
      }
    }

    public virtual double DBH3
    {
      get => this.m_stems[2].Diameter;
      set
      {
        if (this.DBH3 == value)
          return;
        this.OnPropertyChanging(nameof (DBH3));
        this.SetStemDBH(2, value);
        if (value == -1.0)
        {
          if (this.DBH3Height != -1.0)
            this.DBH3Height = -1.0;
          this.DBH3Measured = true;
          this.ReplaceStem(2);
        }
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.DBH3);
      }
    }

    public virtual double DBH3Height
    {
      get => this.m_stems[2].DiameterHeight;
      set
      {
        if (this.DBH3Height == value)
          return;
        this.OnPropertyChanging(nameof (DBH3Height));
        this.SetStemDBHHeight(2, value);
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.DBH3Height);
      }
    }

    public virtual bool DBH3Measured
    {
      get => this.m_stems[2].Measured;
      set
      {
        if (this.DBH3Measured == value)
          return;
        this.OnPropertyChanging(nameof (DBH3Measured));
        this.m_stems[2].Measured = value;
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.DBH3Measured);
      }
    }

    public virtual double DBH4
    {
      get => this.m_stems[3].Diameter;
      set
      {
        if (this.DBH4 == value)
          return;
        this.OnPropertyChanging(nameof (DBH4));
        this.SetStemDBH(3, value);
        if (value == -1.0)
        {
          if (this.DBH4Height != -1.0)
            this.DBH4Height = -1.0;
          this.DBH4Measured = true;
          this.ReplaceStem(3);
        }
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.DBH4);
      }
    }

    public virtual double DBH4Height
    {
      get => this.m_stems[3].DiameterHeight;
      set
      {
        if (this.DBH4Height == value)
          return;
        this.OnPropertyChanging(nameof (DBH4Height));
        this.SetStemDBHHeight(3, value);
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.DBH4Height);
      }
    }

    public virtual bool DBH4Measured
    {
      get => this.m_stems[3].Measured;
      set
      {
        if (this.DBH4Measured == value)
          return;
        this.OnPropertyChanging(nameof (DBH4Measured));
        this.m_stems[3].Measured = value;
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.DBH4Measured);
      }
    }

    public virtual double DBH5
    {
      get => this.m_stems[4].Diameter;
      set
      {
        if (this.DBH5 == value)
          return;
        this.OnPropertyChanging(nameof (DBH5));
        this.SetStemDBH(4, value);
        if (value == -1.0)
        {
          if (this.DBH5Height != -1.0)
            this.DBH5Height = -1.0;
          this.DBH5Measured = true;
          this.ReplaceStem(4);
        }
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.DBH5);
      }
    }

    public virtual double DBH5Height
    {
      get => this.m_stems[4].DiameterHeight;
      set
      {
        if (this.DBH5Height == value)
          return;
        this.OnPropertyChanging(nameof (DBH5Height));
        this.SetStemDBHHeight(4, value);
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.DBH5Height);
      }
    }

    public virtual bool DBH5Measured
    {
      get => this.m_stems[4].Measured;
      set
      {
        if (this.DBH5Measured == value)
          return;
        this.OnPropertyChanging(nameof (DBH5Measured));
        this.m_stems[4].Measured = value;
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.DBH5Measured);
      }
    }

    public virtual double DBH6
    {
      get => this.m_stems[5].Diameter;
      set
      {
        if (this.DBH6 == value)
          return;
        this.OnPropertyChanging(nameof (DBH6));
        this.SetStemDBH(5, value);
        if (value == -1.0)
        {
          if (this.DBH6Height != -1.0)
            this.DBH6Height = -1.0;
          this.DBH6Measured = true;
          this.ReplaceStem(5);
        }
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.DBH6);
      }
    }

    public virtual double DBH6Height
    {
      get => this.m_stems[5].DiameterHeight;
      set
      {
        if (this.DBH6Height == value)
          return;
        this.OnPropertyChanging(nameof (DBH6Height));
        this.SetStemDBHHeight(5, value);
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.DBH6Height);
      }
    }

    public virtual bool DBH6Measured
    {
      get => this.m_stems[5].Measured;
      set
      {
        if (this.DBH6Measured == value)
          return;
        this.OnPropertyChanging(nameof (DBH6Measured));
        this.m_stems[5].Measured = value;
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.DBH6Measured);
      }
    }

    private void ReplaceBuilding(int index)
    {
      Building building = this.m_buildings[index];
      if (this.m_tree.Buildings.Contains(building))
      {
        this.m_tree.Buildings.Remove(building);
        if (!building.IsTransient)
        {
          lock (this.Session)
          {
            using (ITransaction transaction = this.Session.BeginTransaction())
            {
              this.Session.Delete((object) building);
              transaction.Commit();
            }
          }
        }
      }
      this.m_buildings[index] = new Building()
      {
        Id = building.Id
      };
    }

    private void SetBuildingDistance(int index, float distance)
    {
      Building building = this.m_buildings[index];
      building.Distance = distance;
      building.Tree = this.m_tree;
      if (this.m_tree.Buildings.Contains(building))
        return;
      this.m_tree.Buildings.Add(building);
    }

    private void SetBuildingDirection(int index, short direction)
    {
      Building building = this.m_buildings[index];
      building.Direction = direction;
      building.Tree = this.m_tree;
      if (this.m_tree.Buildings.Contains(building))
        return;
      this.m_tree.Buildings.Add(building);
    }

    public virtual float B1Distance
    {
      get => this.m_buildings[0].Distance;
      set
      {
        if (this.B1Distance == value)
          return;
        this.OnPropertyChanging(nameof (B1Distance));
        this.SetBuildingDistance(0, value);
        if ((double) value == -1.0)
        {
          if (this.B1Direction != (short) -1)
            this.B1Direction = (short) -1;
          else
            this.ReplaceBuilding(0);
        }
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.B1Distance);
      }
    }

    public virtual short B1Direction
    {
      get => this.m_buildings[0].Direction;
      set
      {
        if ((int) this.B1Direction == (int) value)
          return;
        this.OnPropertyChanging(nameof (B1Direction));
        this.SetBuildingDirection(0, value);
        if (value == (short) -1)
        {
          if ((double) this.B1Distance != -1.0)
            this.B1Distance = -1f;
          else
            this.ReplaceBuilding(0);
        }
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.B1Direction);
      }
    }

    public virtual float B2Distance
    {
      get => this.m_buildings[1].Distance;
      set
      {
        if (this.B2Distance == value)
          return;
        this.OnPropertyChanging(nameof (B2Distance));
        this.SetBuildingDistance(1, value);
        if ((double) value == -1.0)
        {
          if (this.B2Direction != (short) -1)
            this.B2Direction = (short) -1;
          else
            this.ReplaceBuilding(1);
        }
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.B2Distance);
      }
    }

    public virtual short B2Direction
    {
      get => this.m_buildings[1].Direction;
      set
      {
        if ((int) this.B2Direction == (int) value)
          return;
        this.OnPropertyChanging(nameof (B2Direction));
        this.SetBuildingDirection(1, value);
        if (value == (short) -1)
        {
          if ((double) this.B2Distance != -1.0)
            this.B2Distance = -1f;
          else
            this.ReplaceBuilding(1);
        }
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.B2Direction);
      }
    }

    public virtual float B3Distance
    {
      get => this.m_buildings[2].Distance;
      set
      {
        if (this.B3Distance == value)
          return;
        this.OnPropertyChanging(nameof (B3Distance));
        this.SetBuildingDistance(2, value);
        if ((double) value == -1.0)
        {
          if (this.B3Direction != (short) -1)
            this.B3Direction = (short) -1;
          else
            this.ReplaceBuilding(2);
        }
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.B3Distance);
      }
    }

    public virtual short B3Direction
    {
      get => this.m_buildings[2].Direction;
      set
      {
        if ((int) this.B3Direction == (int) value)
          return;
        this.OnPropertyChanging(nameof (B3Direction));
        this.SetBuildingDirection(2, value);
        if (value == (short) -1)
        {
          if ((double) this.B3Distance != -1.0)
            this.B3Distance = -1f;
          else
            this.ReplaceBuilding(2);
        }
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.B3Direction);
      }
    }

    public virtual float B4Distance
    {
      get => this.m_buildings[3].Distance;
      set
      {
        if (this.B4Distance == value)
          return;
        this.OnPropertyChanging(nameof (B4Distance));
        this.SetBuildingDistance(3, value);
        if ((double) value == -1.0)
        {
          if (this.B4Direction != (short) -1)
            this.B4Direction = (short) -1;
          else
            this.ReplaceBuilding(3);
        }
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.B4Distance);
      }
    }

    public virtual short B4Direction
    {
      get => this.m_buildings[3].Direction;
      set
      {
        if ((int) this.B4Direction == (int) value)
          return;
        this.OnPropertyChanging(nameof (B4Direction));
        this.SetBuildingDirection(3, value);
        if (value == (short) -1)
        {
          if ((double) this.B4Distance != -1.0)
            this.B4Distance = -1f;
          else
            this.ReplaceBuilding(3);
        }
        this.OnPropertyChanged(\u003C\u003EPropertyChangedEventArgs.B4Direction);
      }
    }

    public virtual bool? CityManaged
    {
      get
      {
        if (!this.m_tree.CityManaged.HasValue)
          return new bool?();
        short? cityManaged = this.m_tree.CityManaged;
        int? nullable = cityManaged.HasValue ? new int?((int) cityManaged.GetValueOrDefault()) : new int?();
        int num = 0;
        return new bool?(nullable.GetValueOrDefault() == num & nullable.HasValue);
      }
      set
      {
        if (Nullable.Equals<bool>(this.CityManaged, value))
          return;
        this.OnPropertyChanging(nameof (CityManaged));
        if (value.HasValue)
          this.m_tree.CityManaged = new short?(value.Value ? (short) 0 : (short) 1);
        else
          this.m_tree.CityManaged = new short?();
      }
    }

    public virtual int Direction
    {
      get => this.m_tree.DirectionFromCenter;
      set
      {
        if (this.Direction == value)
          return;
        this.OnPropertyChanging(nameof (Direction));
        this.m_tree.DirectionFromCenter = value;
      }
    }

    public virtual float Distance
    {
      get => this.m_tree.DistanceFromCenter;
      set
      {
        if (this.Distance == value)
          return;
        this.OnPropertyChanging(nameof (Distance));
        this.m_tree.DistanceFromCenter = value;
      }
    }

    public virtual TreeStatus Status
    {
      get => (TreeStatus) this.m_tree.Status;
      set
      {
        if (this.Status == value)
          return;
        this.OnPropertyChanging(nameof (Status));
        this.m_tree.Status = (char) value;
      }
    }

    public virtual string Species
    {
      get => this.m_tree.Species;
      set
      {
        if (string.Equals(this.Species, value, StringComparison.Ordinal))
          return;
        this.OnPropertyChanging(nameof (Species));
        this.m_tree.Species = value;
      }
    }

    public virtual float Height
    {
      get => this.m_tree.TreeHeight;
      set
      {
        if (this.Height == value)
          return;
        this.OnPropertyChanging(nameof (Height));
        this.m_tree.TreeHeight = value;
      }
    }

    public virtual PctMidRange PercentImpervious
    {
      get => this.m_tree.PercentImpervious;
      set
      {
        if (this.PercentImpervious == value)
          return;
        this.OnPropertyChanging(nameof (PercentImpervious));
        this.m_tree.PercentImpervious = value;
      }
    }

    public virtual PctMidRange PercentShrub
    {
      get => this.m_tree.PercentShrub;
      set
      {
        if (this.PercentShrub == value)
          return;
        this.OnPropertyChanging(nameof (PercentShrub));
        this.m_tree.PercentShrub = value;
      }
    }

    public virtual bool StreetTree
    {
      get => this.m_tree.StreetTree;
      set
      {
        if (this.StreetTree == value)
          return;
        this.OnPropertyChanging(nameof (StreetTree));
        this.m_tree.StreetTree = value;
      }
    }

    public virtual SiteType SiteType
    {
      get => this.m_tree.SiteType;
      set
      {
        if (this.SiteType == value)
          return;
        this.OnPropertyChanging(nameof (SiteType));
        this.m_tree.SiteType = value;
      }
    }

    public virtual Street Street
    {
      get => this.m_tree.Street;
      set
      {
        if (this.Street == value)
          return;
        this.OnPropertyChanging(nameof (Street));
        this.m_tree.Street = value;
      }
    }

    public virtual string Address
    {
      get => this.m_tree.Address;
      set
      {
        if (string.Equals(this.Address, value, StringComparison.Ordinal))
          return;
        this.OnPropertyChanging(nameof (Address));
        this.m_tree.Address = value;
      }
    }

    public virtual LocSite LocSite
    {
      get => this.m_tree.LocSite;
      set
      {
        if (this.LocSite == value)
          return;
        this.OnPropertyChanging(nameof (LocSite));
        this.m_tree.LocSite = value;
      }
    }

    public virtual int? LocNo
    {
      get => this.m_tree.LocNo;
      set
      {
        if (Nullable.Equals<int>(this.LocNo, value))
          return;
        this.OnPropertyChanging(nameof (LocNo));
        this.m_tree.LocNo = value;
      }
    }

    public virtual double? Latitude
    {
      get => this.m_tree.Latitude;
      set
      {
        if (Nullable.Equals<double>(this.Latitude, value))
          return;
        this.OnPropertyChanging(nameof (Latitude));
        this.m_tree.Latitude = value;
      }
    }

    public virtual double? Longitude
    {
      get => this.m_tree.Longitude;
      set
      {
        if (Nullable.Equals<double>(this.Longitude, value))
          return;
        this.OnPropertyChanging(nameof (Longitude));
        this.m_tree.Longitude = value;
      }
    }

    public virtual DateTime? SurveyDate
    {
      get => this.m_tree.SurveyDate;
      set
      {
        if (Nullable.Equals<DateTime>(this.SurveyDate, value))
          return;
        this.OnPropertyChanging(nameof (SurveyDate));
        this.m_tree.SurveyDate = value;
      }
    }

    public virtual bool NoteThisTree
    {
      get => this.m_tree.NoteThisTree;
      set
      {
        if (this.NoteThisTree == value)
          return;
        this.OnPropertyChanging(nameof (NoteThisTree));
        this.m_tree.NoteThisTree = value;
      }
    }

    public virtual string Comments
    {
      get => this.m_tree.Comments;
      set
      {
        if (string.Equals(this.Comments, value, StringComparison.Ordinal))
          return;
        this.OnPropertyChanging(nameof (Comments));
        this.m_tree.Comments = value;
      }
    }

    public virtual object Clone()
    {
      FlatTreeView instance = Activator.CreateInstance(this.GetType()) as FlatTreeView;
      instance.Session = this.Session;
      instance.Tree = this.m_tree.Clone() as Tree;
      return (object) instance;
    }

    public event PropertyChangingEventHandler PropertyChanging;

    public virtual void OnPropertyChanging(string propertyName)
    {
      PropertyChangingEventHandler propertyChanging = this.PropertyChanging;
      if (propertyChanging == null)
        return;
      propertyChanging((object) this, new PropertyChangingEventArgs(propertyName));
    }
  }
}
