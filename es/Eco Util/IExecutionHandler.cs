﻿// Decompiled with JetBrains decompiler
// Type: Eco.Util.IExecutionHandler
// Assembly: Eco Util, Version=1.1.6757.0, Culture=neutral, PublicKeyToken=null
// MVID: 8C6433F7-3274-4315-B6F4-90179805B344
// Assembly location: C:\Program Files (x86)\i-Tree\EcoV6\Eco Util.dll

using System;

namespace Eco.Util
{
  public interface IExecutionHandler
  {
    T Execute<T>(Func<T> func);

    void Execute(System.Action action);
  }
}
