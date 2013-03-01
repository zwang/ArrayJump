using System;
using System.Collections.Generic;
namespace ArrayJump
{
	class MainClass
	{
		static void Main(string[] args)
		{
			//int[] array = new int[] { 2, 3, -1, 1, 3 }; //4
			//int[] array = new int[] { -1 };  //1
			//int[] array = new int[] { 0 }; //-1
			//int[] array = new int[] { 1, 1, -1, 1 }; //-1
			//int[] array = new int[] { 1, 1, 1, 1 }; //4
			//int[] array = new int[] { 1, 1, 3, 1 }; //3
			int[] array = new int[] { -3 };  //1
			int result = arrayJmpHareAndTortoise(array);
			Console.WriteLine(result);
			
			
			Console.WriteLine("Done. Press any key to continue");
			Console.ReadKey();
		}
		
		/// <summary>
		/// Use Set
		/// </summary>
		/// <param name="A"></param>
		/// <returns></returns>
		static int arrayJmpWithSet(int[] A)
		{
			if (A.Length == 0) return -1;
			HashSet<int> set = new HashSet<int>();
			int nextJump = A[0];
			set.Add(0);
			while (nextJump >= 0 && nextJump < A.Length)
			{
				if (set.Contains(nextJump))
				{
					return -1;
				}
				set.Add(nextJump);
				nextJump = A[nextJump] + nextJump;
			}
			return set.Count;
		}
		
		/// <summary>
		/// Use no additional data structure.
		/// </summary>
		/// <param name="A"></param>
		/// <returns></returns>
		static int arrayJmp(int[] A)
		{
			if (A.Length == 0) return -1;
			int nextJump = A[0];
			int count = 1;
			while (nextJump >= 0 && nextJump < A.Length)
			{
				if (A[nextJump] == int.MinValue)
				{
					return -1;
				}
				count++;
				int currentIndex = nextJump;
				nextJump = A[nextJump] + nextJump;
				A[currentIndex] = int.MinValue;
			}
			return count;
		}
		
		static int arrayJmpWithString(int[] A)
		{
			if (A.Length == 0) return -1;
			int nextJump = A[0];
			int count = 1;
			string result = ",0";
			while (nextJump >= 0 && nextJump < A.Length)
			{
				string temp = nextJump + ",";
				if (result.IndexOf(temp) >= 0)
				{
					return -1;
				}
				count++;
				result += temp;
				nextJump = A[nextJump] + nextJump;
			}
			return count;
		}
		
		static int arrayJmpNoTracking(int[] A)
		{
			if (A.Length == 0) return -1;
			int nextJump = A[0];
			int count = 1;
			while (nextJump >= 0 && nextJump < A.Length)
			{
				if (count > A.Length)
				{
					return -1;
				}
				count++;
				nextJump = A[nextJump] + nextJump;
			}
			return count;
		}
		
		static int arrayJmpHareAndTortoise(int[] A)
		{
			if (A.Length == 0) return -1;
			int nextJumpTor = A[0];
			int nextJumpHare = A[0];
			int count = 1;
			if (IsInRangeofArray(A, nextJumpHare))
			{
				nextJumpHare = A[nextJumpHare] + nextJumpHare;
				count++;
			}
			while (IsInRangeofArray(A, nextJumpHare))
			{
				if (nextJumpHare == nextJumpTor)
				{
					return -1;
				}
				nextJumpTor = A[nextJumpTor] + nextJumpTor;
				nextJumpHare = A[nextJumpHare] + nextJumpHare;
				count++;
				if (IsInRangeofArray(A, nextJumpHare))
				{
					nextJumpHare = A[nextJumpHare] + nextJumpHare;
					count++;
				}
			}
			return count;
		}
		
		static bool IsInRangeofArray(int[] A, int nextJumpHare)
		{
			return nextJumpHare >= 0 && nextJumpHare < A.Length;
		}
	}
}
