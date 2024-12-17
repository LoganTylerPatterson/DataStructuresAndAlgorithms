using System;
using System.Collections.Generic;

public class QuickSort
{
    // THE OG, THE QUICKSORT
    public void QuickSort<T>(List<T> array, int s, int e) 
	{
		if (s < e) 
		{
			int p = Partition(array, s, e);
			QuickSort(array, s, p - 1);
			QuickSort(array, p + 1, e);
		}
	}

	public int Partition<T>(List<T> array, int start, int end) 
	{
		int ele = array[end];
		int i = start - 1;
		for (int j = start; j < end; j++) {
			if (array[j] <= ele) {
				i++;
				array.Swap(i, j);
			}
		}
		array.Swap(i + 1, end);
		return i + 1;
	}
}

public class HeapSort<T> {
	List<T> list;
	public HeapSort(List<T> _list) {
		list = _list;
	}

	private int GetParent(int i) {
		return (i - 1 ) / 2;
	}

	private int GetLeftChild(int i) {
		return i * 2 + 1;
	}

	private int GetRightChild(int i) {
		return i * 2 + 2;
	}
}
					
public class Program
{
	public static void Main()
	{
		var test1 = new List<int>{4,2,1,3,5,6,2,8,1,9};
		test1.QuickSort();
		for (int i = 0; i < test1.Count; i++) {
			Console.WriteLine(test1[i]);
		}
	}
}

public static class ListExtensions
{
   public void Swap<T>(this List<T> array, int i1, int i2) 
   {
    T temp = array[i1];
    array[i1] = array[i2];
    array[i2] = temp;
   }

   public void QuickSort<T>(this List<T> array) {
	var qs = new QuickSort();
	qs.QuickSort(array);
   }

   public void HeapSort<T>(this List<T> array) {
	var hs = new HeapSort(array);
   }
}