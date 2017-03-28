﻿#region File and License Information
/*
<File>
	<License>
		Copyright © 2009 - 2017, Daniel Vaughan. All rights reserved.
		This file is part of Codon (http://codonfx.com), 
		which is released under the MIT License.
		See file /Documentation/License.txt for details.
	</License>
	<CreationDate>2009-03-22 14:02:43Z</CreationDate>
</File>
*/
#endregion

using System;
using System.Runtime.CompilerServices;

namespace Codon
{
	/// <summary>
	/// Utility class for validating method arguments.
	/// </summary>
	public static class AssertArg
	{
		/// <summary>
		/// Throws an exception if the specified value is null.
		/// </summary>
		/// <typeparam name="T">The type of the value.</typeparam>
		/// <param name="value">The value to test.</param>
		/// <param name="parameterName">Name of the parameter.</param>
		/// <param name="memberName">Compiler populated parameter
		/// that provides the caller member name.</param>
		/// <param name="filePath">Compiler populated parameter
		/// that provides the file path to the caller.</param>
		/// <param name="lineNumber">
		/// Compiler populated parameter that provides 
		/// the line number of where the method was called.</param>
		/// <returns>The specified value.</returns>
		/// <exception cref="ArgumentNullException">Occurs if the specified value 
		/// is <code>null</code>.</exception>
		/// <example>
		/// public UIElementAdapter(UIElement uiElement)
		/// {
		/// 	this.uiElement = AssertArg.IsNotNull(uiElement, nameof(uiElement));	
		/// }
		/// </example>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T IsNotNull<T>(T value, string parameterName,
			[CallerMemberName] string memberName = null,
			[CallerFilePath] string filePath = null,
			[CallerLineNumber] int lineNumber = 0) 
			where T : class
		{
			if (value == null)
			{
				throw new ArgumentNullException(parameterName,
					$"Argument must not be null. Method '{memberName}', File '{filePath}', Line '{lineNumber}'");
			}

			return value;
		}

		/// <summary>
		/// Throws an exception if the specified value 
		/// is <code>null</code> or empty (a zero length string).
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="parameterName">Name of the parameter.</param>
		/// <param name="memberName">Compiler populated parameter
		/// that provides the caller member name.</param>
		/// <param name="filePath">Compiler populated parameter
		/// that provides the file path to the caller.</param>
		/// <param name="lineNumber">
		/// Compiler populated parameter that provides 
		/// the line number of where the method was called.</param>
		/// <returns>The specified value.</returns>
		/// <exception cref="ArgumentNullException">Occurs if the specified value 
		/// is <code>null</code> or empty (a zero length string).</exception>
		/// <example>
		/// public DoSomething(string message)
		/// {
		/// 	this.message = AssertArg.IsNotNullOrEmpty(message, nameof(message));	
		/// }
		/// </example>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static string IsNotNullOrEmpty(
			string value, string parameterName,
			[CallerMemberName] string memberName = null,
			[CallerFilePath] string filePath = null,
			[CallerLineNumber] int lineNumber = 0)
		{
			if (value == null)
			{
				throw new ArgumentNullException(parameterName,
					$"Argument must not be null or empty. Method '{memberName}', File '{filePath}', Line '{lineNumber}'");
			}

			if (string.IsNullOrEmpty(value))
			{
				throw new ArgumentException(
					$"Argument must not be an empty string. Method '{memberName}', File '{filePath}', Line '{lineNumber}'", parameterName);
			}

			return value;
		}

		/// <summary>
		/// Throws an exception if the specified value 
		/// is <code>null</code> or white space.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="parameterName">Name of the parameter.</param>
		/// <param name="memberName">Compiler populated parameter
		/// that provides the caller member name.</param>
		/// <param name="filePath">Compiler populated parameter
		/// that provides the file path to the caller.</param>
		/// <param name="lineNumber">
		/// Compiler populated parameter that provides 
		/// the line number of where the method was called.</param>
		/// <returns>The specified value.</returns>
		/// <exception cref="ArgumentNullException">
		/// Occurs if the specified value 
		/// is <code>null</code> or consists of only white space.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static string IsNotNullOrWhiteSpace(
			string value, string parameterName,
			[CallerMemberName] string memberName = null,
			[CallerFilePath] string filePath = null,
			[CallerLineNumber] int lineNumber = 0)
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				throw new ArgumentException(
					$"Argument must not be null or white space. Method '{memberName}', File '{filePath}', Line '{lineNumber}'", 
					parameterName);
			}

			return value;
		}

		/// <summary>
		/// Throws an exception if the specified value is an empty guid.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="parameterName">The name of the member.</param>
		/// <param name="memberName">Compiler populated parameter
		/// that provides the caller member name.</param>
		/// <param name="filePath">Compiler populated parameter
		/// that provides the file path to the caller.</param>
		/// <param name="lineNumber">
		/// Compiler populated parameter that provides 
		/// the line number of where the method was called.</param>
		/// <returns>The specified value.</returns>
		/// <exception cref="ArgumentNullException">
		/// Occurs if the specified value is an empty guid. 
		/// That is, if <c>value</c> equals <c>Guid.Empty</c>.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Guid IsNotEmpty(Guid value, string parameterName,
			[CallerMemberName] string memberName = null,
			[CallerFilePath] string filePath = null,
			[CallerLineNumber] int lineNumber = 0)
		{
			if (value == Guid.Empty)
			{
				throw new ArgumentException(
					$"Guid argument must not be an empty guid. Method '{memberName}', File '{filePath}', Line '{lineNumber}'", 
					parameterName);
			}

			return value;
		}

		/// <summary>
		/// Throws an exception if the specified value is not greater 
		/// than the specified expected value.
		/// </summary>
		/// <param name="expected">
		/// The number which must be greater than the value.</param>
		/// <param name="value">The value to test.</param>
		/// <param name="parameterName">The name of the member.</param>
		/// <param name="memberName">Compiler populated parameter
		/// that provides the caller member name.</param>
		/// <param name="filePath">Compiler populated parameter
		/// that provides the file path to the caller.</param>
		/// <param name="lineNumber">
		/// Compiler populated parameter that provides 
		/// the line number of where the method was called.</param>
		/// <returns>The specified value.</returns>
		/// <exception cref="ArgumentNullException">
		/// Occurs if the specified value is not greater 
		/// than the expected value.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int IsGreaterThan(
			int expected, int value, string parameterName,
			[CallerMemberName] string memberName = null,
			[CallerFilePath] string filePath = null,
			[CallerLineNumber] int lineNumber = 0)
		{
			if (value > expected)
			{
				return value;
			}

			throw new ArgumentOutOfRangeException(
				$"Argument must be greater than {expected} but was {value}. Method '{memberName}', File '{filePath}', Line '{lineNumber}'", 
				parameterName);
		}

		/// <summary>
		/// Throws an exception if the specified value is not greater 
		/// than the specified expected value.
		/// </summary>
		/// <param name="expected">
		/// The number which must be greater than the value.</param>
		/// <param name="value">The value to test.</param>
		/// <param name="parameterName">The name of the member.</param>
		/// <param name="memberName">Compiler populated parameter
		/// that provides the caller member name.</param>
		/// <param name="filePath">Compiler populated parameter
		/// that provides the file path to the caller.</param>
		/// <param name="lineNumber">
		/// Compiler populated parameter that provides 
		/// the line number of where the method was called.</param>
		/// <returns>The specified value.</returns>
		/// <exception cref="ArgumentNullException">
		/// Occurs if the specified value is not greater 
		/// than the expected value.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double IsGreaterThan(
			double expected, double value, string parameterName,
			[CallerMemberName] string memberName = null,
			[CallerFilePath] string filePath = null,
			[CallerLineNumber] int lineNumber = 0)
		{
			if (value > expected)
			{
				return value;
			}

			throw new ArgumentOutOfRangeException(
				$"Argument must be greater than {expected} but was {value}. Method '{memberName}', File '{filePath}', Line '{lineNumber}'", 
				parameterName);
		}

		/// <summary>
		/// Throws an exception if the specified value is not greater 
		/// than or equal to the specified expected value.
		/// </summary>
		/// <param name="expected">
		/// The number which must be greater than or equal to the value.</param>
		/// <param name="value">The value to test.</param>
		/// <param name="parameterName">The name of the member.</param>
		/// <param name="memberName">Compiler populated parameter
		/// that provides the caller member name.</param>
		/// <param name="filePath">Compiler populated parameter
		/// that provides the file path to the caller.</param>
		/// <param name="lineNumber">
		/// Compiler populated parameter that provides 
		/// the line number of where the method was called.</param>
		/// <returns>The specified value.</returns>
		/// <exception cref="ArgumentNullException">
		/// Occurs if the specified value is not greater 
		/// than or equal to the expected value.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int IsGreaterThanOrEqual(
			int expected, int value, string parameterName,
			[CallerMemberName] string memberName = null,
			[CallerFilePath] string filePath = null,
			[CallerLineNumber] int lineNumber = 0)
		{
			if (value >= expected)
			{
				return value;
			}

			throw new ArgumentOutOfRangeException(
				$"Argument must be greater than or equal to {expected} but was {value}. Method '{memberName}', File '{filePath}', Line '{lineNumber}'", 
				parameterName);
		}

		/// <summary>
		/// Throws an exception if the specified value is not greater 
		/// than or equal to the specified expected value.
		/// </summary>
		/// <param name="expected">
		/// The number which must be greater than or equal to the value.</param>
		/// <param name="value">The value to test.</param>
		/// <param name="parameterName">The name of the member.</param>
		/// <param name="memberName">Compiler populated parameter
		/// that provides the caller member name.</param>
		/// <param name="filePath">Compiler populated parameter
		/// that provides the file path to the caller.</param>
		/// <param name="lineNumber">
		/// Compiler populated parameter that provides 
		/// the line number of where the method was called.</param>
		/// <returns>The specified value.</returns>
		/// <exception cref="ArgumentNullException">
		/// Occurs if the specified value is not greater 
		/// than or equal to the expected value.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double IsGreaterThanOrEqual(
			double expected, double value, string parameterName,
			[CallerMemberName] string memberName = null,
			[CallerFilePath] string filePath = null,
			[CallerLineNumber] int lineNumber = 0)
		{
			if (value >= expected)
			{
				return value;
			}

			throw new ArgumentOutOfRangeException(
				$"Argument must be greater than or equal to {expected} but was {value}. Method '{memberName}', File '{filePath}', Line '{lineNumber}'", 
				parameterName);
		}

		/// <summary>
		/// Throws an exception if the specified value is not less 
		/// than the specified expected value.
		/// </summary>
		/// <param name="expected">
		/// The number which must be less than the value.</param>
		/// <param name="value">The value to test.</param>
		/// <param name="parameterName">The name of the member.</param>
		/// <param name="memberName">Compiler populated parameter
		/// that provides the caller member name.</param>
		/// <param name="filePath">Compiler populated parameter
		/// that provides the file path to the caller.</param>
		/// <param name="lineNumber">
		/// Compiler populated parameter that provides 
		/// the line number of where the method was called.</param>
		/// <returns>The specified value.</returns>
		/// <exception cref="ArgumentNullException">
		/// Occurs if the specified value is not less 
		/// than the expected value.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int IsLessThan(
			int expected, int value, string parameterName,
			[CallerMemberName] string memberName = null,
			[CallerFilePath] string filePath = null,
			[CallerLineNumber] int lineNumber = 0)
		{
			if (value >= expected)
			{
				throw new ArgumentOutOfRangeException(
					$"Argument must be less than {expected} but was {value}. Method '{memberName}', File '{filePath}', Line '{lineNumber}'", 
					parameterName);
			}

			return value;
		}

		/// <summary>
		/// Throws an exception if the specified value is not less 
		/// than the specified expected value.
		/// </summary>
		/// <param name="expected">
		/// The number which must be less than the value.</param>
		/// <param name="value">The value to test.</param>
		/// <param name="parameterName">The name of the member.</param>
		/// <param name="memberName">Compiler populated parameter
		/// that provides the caller member name.</param>
		/// <param name="filePath">Compiler populated parameter
		/// that provides the file path to the caller.</param>
		/// <param name="lineNumber">
		/// Compiler populated parameter that provides 
		/// the line number of where the method was called.</param>
		/// <returns>The specified value.</returns>
		/// <exception cref="ArgumentNullException">
		/// Occurs if the specified value is not less 
		/// than the expected value.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double IsLessThan(
			double expected, double value, string parameterName,
			[CallerMemberName] string memberName = null,
			[CallerFilePath] string filePath = null,
			[CallerLineNumber] int lineNumber = 0)
		{
			if (value >= expected)
			{
				throw new ArgumentOutOfRangeException(
					$"Argument must be less than {expected} but was {value}. Method '{memberName}', File '{filePath}', Line '{lineNumber}'",
					parameterName);
			}

			return value;
		}

		/// <summary>
		/// Throws an exception if the specified value is not less 
		/// than or equal to the specified expected value.
		/// </summary>
		/// <param name="expected">
		/// The number which must be less than or equal to the value.</param>
		/// <param name="value">The value to test.</param>
		/// <param name="parameterName">The name of the member.</param>
		/// <param name="memberName">Compiler populated parameter
		/// that provides the caller member name.</param>
		/// <param name="filePath">Compiler populated parameter
		/// that provides the file path to the caller.</param>
		/// <param name="lineNumber">
		/// Compiler populated parameter that provides 
		/// the line number of where the method was called.</param>
		/// <returns>The specified value.</returns>
		/// <exception cref="ArgumentNullException">
		/// Occurs if the specified value is not less 
		/// than or equal to the expected value.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int IsLessThanOrEqual(
			int expected, int value, string parameterName,
			[CallerMemberName] string memberName = null,
			[CallerFilePath] string filePath = null,
			[CallerLineNumber] int lineNumber = 0)
		{
			if (value > expected)
			{
				throw new ArgumentOutOfRangeException(
					$"Argument must be less than or equal to {expected} but was {value}. Method '{memberName}', File '{filePath}', Line '{lineNumber}'", 
					parameterName);
			}

			return value;
		}

		/// <summary>
		/// Throws an exception if the specified value is not less 
		/// than or equal to the specified expected value.
		/// </summary>
		/// <param name="expected">
		/// The number which must be less than or equal to the value.</param>
		/// <param name="value">The value to test.</param>
		/// <param name="parameterName">The name of the member.</param>
		/// <param name="memberName">Compiler populated parameter
		/// that provides the caller member name.</param>
		/// <param name="filePath">Compiler populated parameter
		/// that provides the file path to the caller.</param>
		/// <param name="lineNumber">
		/// Compiler populated parameter that provides 
		/// the line number of where the method was called.</param>
		/// <returns>The specified value.</returns>
		/// <exception cref="ArgumentNullException">
		/// Occurs if the specified value is not less 
		/// than or equal to the expected value.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double IsLessThanOrEqual(
			double expected, double value, string parameterName,
			[CallerMemberName] string memberName = null,
			[CallerFilePath] string filePath = null,
			[CallerLineNumber] int lineNumber = 0)
		{
			if (value > expected)
			{
				throw new ArgumentOutOfRangeException(
					$"Argument must be less than or equal to {expected} but was {value}. Method '{memberName}', File '{filePath}', Line '{lineNumber}'",
					parameterName);
			}

			return value;
		}

		/// <summary>
		/// Throws an exception if the specified value is <code>null</code> 
		/// or if the value is not of the specified type.
		/// </summary>
		/// <param name="value">The value to test.</param> 
		/// <param name="parameterName">The name of the parameter.</param>
		/// <param name="memberName">Compiler populated parameter
		/// that provides the caller member name.</param>
		/// <param name="filePath">Compiler populated parameter
		/// that provides the file path to the caller.</param>
		/// <param name="lineNumber">
		/// Compiler populated parameter that provides 
		/// the line number of where the method was called.</param>
		/// <returns>The value to test.</returns>
		/// <exception cref="ArgumentNullException">
		/// Occurs if the specified value is <code>null</code> 
		/// or of a type not assignable from the specified type.</exception>
		/// <example>
		/// public DoSomething(object message)
		/// {
		/// 	this.message = AssertArg.IsNotNullAndOfType&lt;string&gt;(message, nameof(message));	
		/// }
		/// </example>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T IsNotNullAndOfType<T>(
			object value, string parameterName,
			[CallerMemberName] string memberName = null,
			[CallerFilePath] string filePath = null,
			[CallerLineNumber] int lineNumber = 0) where T : class
		{
			if (value == null)
			{
				throw new ArgumentNullException(parameterName,
					$"Argument must not be null. Method '{memberName}', File '{filePath}', Line '{lineNumber}'");
			}

			var result = value as T;
			if (result == null)
			{
				throw new ArgumentException(
					$"Argument must be of type {typeof(T)}, but was {value.GetType()}. Method '{memberName}', File '{filePath}', Line '{lineNumber}'",
					parameterName);
			}
			return result;
		}

		/// <summary>
		/// Throws an exception if the specified value is not of the type 
		/// denoted by the type parameter <c>T</c>.
		/// </summary>
		/// <typeparam name="T">The expected type of the value.</typeparam>
		/// <param name="value">
		/// The parameter value passed to the calling method.</param>
		/// <param name="parameterName">
		/// The name of the parameter from the calling method.</param>
		/// <param name="memberName">Compiler populated parameter
		/// that provides the caller member name.</param>
		/// <param name="filePath">Compiler populated parameter
		/// that provides the file path to the caller.</param>
		/// <param name="lineNumber">
		/// Compiler populated parameter that provides 
		/// the line number of where the method was called.</param>
		/// <returns>The value passed to the method.</returns>
		/// <exception cref="ArgumentException">
		/// If the specified value is not of the type
		/// denoted by the type parameter <c>T</c>.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T IsOfType<T>(object value, string parameterName,
			[CallerMemberName] string memberName = null,
			[CallerFilePath] string filePath = null,
			[CallerLineNumber] int lineNumber = 0)
		{
			T result;
			try
			{
				result = (T)value;
			}
			catch (InvalidCastException)
			{
				throw new ArgumentException(
					$"Argument must be of type {typeof(T)}, but was {value.GetType()}. Method '{memberName}', File '{filePath}', Line '{lineNumber}'",
					parameterName);
			}

			return result;
		}
	}
}