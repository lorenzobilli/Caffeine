/*
 *	Project: Espresso
 *	Author(s): Lorenzo Billi
 *	
 *	
 *	The MIT License
 *	
 *	Copyright (c) 2018-2019 Lorenzo Billi
 *	
 *	Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated
 *	documentation files (the "Software"), to deal in the Software without restriction, including without limitation
 *	the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and
 *	to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 *	
 *	The above copyright notice and this permission notice shall be included in all copies or substantial portions
 *	of the Software.
 *	
 *	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO
 *	THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND	NONINFRINGEMENT. IN NO EVENT SHALL THE
 *	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
 *	CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
 *	IN THE SOFTWARE.
 *	
 *	
 *	Espresso/Espresso/Coffee.cs
 *	
 */

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Espresso.Shared
{
	/// <summary>
	/// Wraps all code used to keep the computer waken up.
	/// </summary>
	public class Coffee
    {
		/// <summary>
		/// Tells if the sleeping prevention system is active.
		/// </summary>
		public bool IsActive { get; private set; }

		/// <summary>
		/// Activates the sleeping prevention system.
		/// </summary>
		/// <returns>True if the system is now correctly configured to avoid sleeping, false if not.</returns>
		public bool Activate()
		{
			var previousExecutionState = Caffeine.SetThreadExecutionState(
				Caffeine.EXECUTION_STATE.ES_CONTINUOUS |
				Caffeine.EXECUTION_STATE.ES_DISPLAY_REQUIRED |
				Caffeine.EXECUTION_STATE.ES_SYSTEM_REQUIRED
			);

			if (previousExecutionState == 0)
			{
				Debug.WriteLine("Unable to avoid sleep");
				return false;
			}

			IsActive = true;
			return true;
		}

		/// <summary>
		/// Deactivates the sleeping prevention system.
		/// </summary>
		/// <returns>True if the system's default behaviour has been correctly restored, false if not.</returns>
		public bool Deactivate()
		{
			var previousExecutionState = Caffeine.SetThreadExecutionState(Caffeine.EXECUTION_STATE.ES_CONTINUOUS);

			if (previousExecutionState == 0)
			{
				Debug.WriteLine("Unable to recover normal sleep behaviour");
				return false;
			}

			IsActive = false;
			return true;
		}
    }

	/// <summary>
	/// Internal wrapper class exposing native Windows' methods used for preventing sleep.
	/// </summary>
	internal static class Caffeine
	{
		/// <summary>
		/// Possible <c>EXECUTION_STATE</c> flags that can be passed to and returned by
		/// <c>SetThreadExecutionState</c>.
		/// </summary>
		/// <para>
		/// The possible values for this enumeration are:
		/// <list type="table"
		/// <item>
		///	<term><c>ES_AWAYMODE_REQUIRED</c></term>
		///	<description>
		///	Enables away mode. This value must be specified with <c>ES_CONTINUOUS</c>.
		///	Away mode should be used only by media-recording and media-distribution applications that must perform
		///	critical background processing on desktop computers while the computer appears sleeping.
		///	</description>
		///	</item>
		///	<item>
		///	<term><c>ES_CONTINUOUS</c></term>
		///	<description>
		///	Informs the system that the state being set should remain in effect until the next call that uses
		///	<c>ES_CONTINUOUS</c> and one of the other state flags is cleared.
		///	</description>
		///	</item>
		///	<item>
		///	<term><c>ES_DISPLAY_REQUIRED</c></term>
		///	<description>Forces the display to be on by resetting the display idle timer.</description>
		///	</item>
		///	<item>
		///	<term><c>ES_SYSTEM_REQUIRED</c></term>
		///	<description>
		///	Forces the system to be in the working state by resetting the system idle timer.
		///	</description>
		///	</item>
		///	<item>
		///	<term><c>ES_USER_PRESENT</c></term>
		///	<description>
		///	This value is not supported. If <c>ES_USER_PRESENT</c> is combined with other <c>esFlags</c> values, the
		///	call will fail and none of the specified states will be set.
		///	</description>
		///	</item>
		/// </list>
		/// </para>
		[Flags]
		public enum EXECUTION_STATE : uint
		{
			ES_AWAYMODE_REQUIRED = 0x00000040,
			ES_CONTINUOUS = 0x80000000,
			ES_DISPLAY_REQUIRED = 0x00000002,
			ES_SYSTEM_REQUIRED = 0x00000001,
			ES_USER_PRESENT = 0x00000004
		}

		/// <summary>
		/// Enables an application to inform the system that it is in use, thereby preventing the system from entering
		/// sleep or turning off the display while the application is running.
		/// </summary>
		/// <param name="esFlags">The thread's execution requirements.</param>
		/// <returns>
		/// If the function succeeds, the return value is the previous thread execution state.
		/// If the function fails, the return value is 0.
		/// </returns>
		[DllImport("kernel32.dll")]
		public static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);
	}
}
