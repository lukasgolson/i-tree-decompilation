﻿// Decompiled with JetBrains decompiler
// Type: Eco.Domain.Types.v6.VersionType
// Assembly: Eco.Domain, Version=10.0.17.6714, Culture=neutral, PublicKeyToken=null
// MVID: 01C26179-0456-4F8E-BC0F-741F177F6574
// Assembly location: C:\Program Files (x86)\i-Tree\EcoV6\Eco.Domain.dll

using NHibernate;
using NHibernate.Engine;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;
using System;
using System.Data.Common;

namespace Eco.Domain.Types.v6
{
  [Serializable]
  public class VersionType : IUserType
  {
    object IUserType.Assemble(object cached, object owner) => ((IUserType) this).DeepCopy(cached);

    object IUserType.DeepCopy(object value)
    {
      Version version = value as Version;
      if (version != (Version) null)
        version = new Version(version.ToString());
      return (object) version;
    }

    object IUserType.Disassemble(object value) => ((IUserType) this).DeepCopy(value);

    bool IUserType.Equals(object x, object y) => x == null ? y == null : x.Equals(y);

    int IUserType.GetHashCode(object x) => x.GetHashCode();

    bool IUserType.IsMutable => false;

    object IUserType.NullSafeGet(
      DbDataReader rs,
      string[] names,
      ISessionImplementor session,
      object owner)
    {
      object version = NHibernateUtil.String.NullSafeGet(rs, names[0], session, owner);
      return version == null ? (object) null : (object) new Version((string) version);
    }

    void IUserType.NullSafeSet(
      DbCommand cmd,
      object value,
      int index,
      ISessionImplementor session)
    {
      Version version = value as Version;
      string str = (string) null;
      if (version != (Version) null)
        str = version.ToString();
      NHibernateUtil.String.NullSafeSet(cmd, (object) str, index, session);
    }

    object IUserType.Replace(object original, object target, object owner) => ((IUserType) this).DeepCopy(original);

    Type IUserType.ReturnedType => typeof (Version);

    SqlType[] IUserType.SqlTypes => new SqlType[1]
    {
      NHibernateUtil.String.SqlType
    };
  }
}
