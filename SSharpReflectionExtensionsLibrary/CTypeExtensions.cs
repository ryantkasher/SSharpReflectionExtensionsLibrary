﻿#region License
/*
 * CTypeExtensions.cs
 *
 * The MIT License
 *
 * Copyright © 2017 Nivloc Enterprises Ltd
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
#endregion

using System.Linq;
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
			return types.Select (t => (CType)t).ToArray ();
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
