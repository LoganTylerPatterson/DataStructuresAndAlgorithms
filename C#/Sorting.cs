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

public class CountingSort<T> {
	public CountingSort<T>(List<T> _list, int k) {
		List<int> C = new List<int>(k);
		for(int i = 0; i < C.Count; i++) {
			C[i] = 0;
		}
		
		// count all the occurences of a character
		for(int j = 0; j < _list.Count; j++) {
			C[_list[i]] += 1;
		}
		
		// at this point C[i] represents the count of the integer i
		for(int i = 0; i < k; i++) {
			C[i] = C[i] + C[i - 1];
		}
		
		List<T> B = new List<T>(_list.Count);
		// a this point C[i] contains the count of integer i + how many previous integers that come before
		for(int i = 0; i < _list.Count; i++) {
			B[C[_list[i]]] =  _list[i];
			C[_list[i]] -= 1;
		}

		return B;
	}
}


public class Heap<T> {
	List<T> list;
	int size;
	public Heap<T>(List<T> _list) {
		list = _list;
		size = list.Count;
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

	private void SiftUp(int i) {
		int parent = GetParent(i);
		while (list[parent] < list[i]) {
			list.Swap(parent, i);
			i = parent;
			parent = GetParent(i);
		}
	}

	private void SiftDown(int i) {
		int left = GetLeftChild(i);
		int right = GetRightChild(i);
		int largest = i;
		if (list[left] > list[i]) {
			largest = i;
		}
		if (list[right] > list[largest]) {
			largest = right;
		}
		
		if (i != largest) {
			list.Swap(i, largest);
			SiftDown(largest);
		}
	}

	private void BuildMaxHeap() {
		for(int i = size / 2; i > 0; i--) {
			SiftDown(i);
		}
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

   public void CountingSort<T>(this List<T> _list, int k) {
		List<int> C = new List<int>(k);

		for(int i = 0; i < C.Count; i++) {
			C[i] = 0;
		}
		
		// count all the occurences of a character
		for(int j = 0; j < _list.Count; j++) {
			C[_list[i]] += 1;
		}
		
		// at this point C[i] represents the count of the integer i
		for(int i = 0; i < k; i++) {
			C[i] = C[i] + C[i - 1];
		}
		
		List<T> B = new List<T>(_list.Count);
		// a this point C[i] contains the count of integer i + how many previous integers that come before
		for(int i = 0; i < _list.Count; i++) {
			B[C[_list[i]]] =  _list[i];
			C[_list[i]] -= 1;
		}

		_list = B;
	}

}
