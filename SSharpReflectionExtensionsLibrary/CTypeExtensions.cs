﻿using System.Linq;
using System;
// For Basic SIMPL# Classes

namespace Crestron.SimplSharp.Reflection
	{
	public static class CTypeExtensions
		{
		public static CType GetCType (this object obj)
			{
			return obj.GetType ();
			}

		public static CType ctypeof<T> ()
			{
			return (typeof (T));
			}

		public static CType[] GetTypeArray (object[] args)
			{
			if (args == null)
				return CTypeEmptyArray;

			return args.Select (a => a == null ? (CType)typeof(object) : (a is Type ? (CType)typeof(CType) : a.GetCType ())).ToArray ();
			}

		public static CType[] MakeTypeArray (Type[] types)
			{
			return types.Select (t => t.GetCType ()).ToArray ();
			}

		public static readonly CType[] CTypeEmptyArray = new CType[0];

		public static bool IsRestricted (this CType ctype)
			{
			return false;
			}

		public static MethodInfo MakeGenericMethod (this MethodInfo mi, params Type[] typeArguments)
			{
			return mi.MakeGenericMethod (typeArguments.GetCTypes ());
			}

		public static string AssemblyFullName (this CType ctype)
			{
			return ((Type)ctype).AssemblyFullName ();
			}

		public static Version AssemblyVersion (this CType ctype)
			{
			return ((Type)ctype).AssemblyVersion ();
			}

		public static ConstructorInfo GetConstructor (this CType ctype, Type[] types)
			{
			return ctype.GetConstructor (MakeTypeArray (types));
			}
		}
	}
