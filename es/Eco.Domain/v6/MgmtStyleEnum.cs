﻿// Decompiled with JetBrains decompiler
// Type: Eco.Domain.v6.MgmtStyleEnum
// Assembly: Eco.Domain, Version=10.0.17.6714, Culture=neutral, PublicKeyToken=null
// MVID: 01C26179-0456-4F8E-BC0F-741F177F6574
// Assembly location: C:\Program Files (x86)\i-Tree\EcoV6\Eco.Domain.dll

using System;

namespace Eco.Domain.v6
{
  [Flags]
  public enum MgmtStyleEnum : short
  {
    DefaultPublic = 0,
    DefaultPrivate = 1,
    RecordPublicPrivate = 2,
  }
}
