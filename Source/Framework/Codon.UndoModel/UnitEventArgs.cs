#region File and License Information
/*
<File>
	<License>
		Copyright � 2009 - 2017, Daniel Vaughan. All rights reserved.
		This file is part of Codon (http://codonfx.com), 
		which is released under the MIT License.
		See file /Documentation/License.txt for details.
	</License>
	<CreationDate>2010-01-23 17:21:10Z</CreationDate>
</File>
*/
#endregion

using System;

namespace Codon.UndoModel
{
	/// <summary>
	/// Used during unit execution.
	/// </summary>
	public class UnitEventArgs<TArgument> : EventArgs
	{
		/// <summary>
		/// Gets or sets the argument used by the concrete 
		/// <seealso cref="UnitBase{T}"/> implementation.
		/// </summary>
		/// <value>The argument.</value>
		public TArgument Argument { get; set; }

		/// <summary>
		/// Gets or sets the unit result.
		/// </summary>
		/// <value>The unit result.</value>
		public UnitResult UnitResult { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="UnitEventArgs{TArgument}"/> class.
		/// </summary>
		/// <param name="argument">The argument used by the concrete 
		/// <code>UnitBase</code> implementation.</param>
		public UnitEventArgs(TArgument argument)
		{
			Argument = argument;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="UnitEventArgs{TArgument}"/> class.
		/// </summary>
		/// <param name="argument">The argument used by the concrete 
		/// <code>UnitBase</code> implementation.</param>
		/// <param name="unitMode">Indicates whether this unit is being performed 
		/// for the fist time, if it is being redone, or if it is being repeated.</param>
		internal UnitEventArgs(TArgument argument, UnitMode unitMode) : this(argument)
		{
			UnitMode = unitMode;
		}

		public UnitMode UnitMode { get; private set; }
	}

	/// <summary>
	/// Indicates why a unit is being performed.
	/// </summary>
	public enum UnitMode
	{
		Unknown,
		FirstTime,
		Redo,
		Repeat,
	}
}