﻿// Decompiled with JetBrains decompiler
// Type: i_Tree_Eco_v6.Tasks.UpdateDatabaseException
// Assembly: i-Tree Eco v6.x64, Version=6.0.29.0, Culture=neutral, PublicKeyToken=null
// MVID: E695D7ED-407B-4C7B-B817-3F1C5BB20211
// Assembly location: C:\Program Files (x86)\i-Tree\EcoV6\i-Tree Eco v6.x64.exe

using System;

namespace i_Tree_Eco_v6.Tasks
{
  public class UpdateDatabaseException : Exception
  {
    public UpdateDatabaseException()
    {
    }

    public UpdateDatabaseException(string message)
      : base(message)
    {
    }

    public UpdateDatabaseException(string message, Exception innerException)
      : base(message, innerException)
    {
    }
  }
}