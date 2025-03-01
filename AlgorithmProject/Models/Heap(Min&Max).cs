using System;
using System.Collections.Generic;

public class MinHeap
{
    private List<int> _heap = new List<int>();

    // ����� ��� ��� Min-Heap
    public int Peek()
    {
        if (_heap.Count == 0) throw new InvalidOperationException("The heap is empty.");
        return _heap[0];
    }

    // ����� ���� ��� ��� Min-Heap
    public void Push(int val)
    {
        _heap.Add(val);
        HeapifyUp();
    }

    // ������� ���� ���� �� ��� Min-Heap
    public int Pop()
    {
        if (_heap.Count == 0) throw new InvalidOperationException("The heap is empty.");
        int result = _heap[0];
        _heap[0] = _heap[_heap.Count - 1];
        _heap.RemoveAt(_heap.Count - 1);
        HeapifyDown();
        return result;
    }

    // ���� ������ ������� ������
    public List<int> ToList()
    {
        return new List<int>(_heap);
    }

    // ����� ������� �� ������ ������
    private void HeapifyUp()
    {
        int index = _heap.Count - 1;
        while (index > 0)
        {
            int parentIndex = (index - 1) / 2;
            if (_heap[index] >= _heap[parentIndex]) break;
            Swap(index, parentIndex);
            index = parentIndex;
        }
    }

    // ����� ������� �� ������ ������
    private void HeapifyDown()
    {
        int index = 0;
        while (index < _heap.Count)
        {
            int leftChild = 2 * index + 1;
            int rightChild = 2 * index + 2;
            int smallest = index;

            if (leftChild < _heap.Count && _heap[leftChild] < _heap[smallest]) smallest = leftChild;
            if (rightChild < _heap.Count && _heap[rightChild] < _heap[smallest]) smallest = rightChild;
            if (smallest == index) break;

            Swap(index, smallest);
            index = smallest;
        }
    }

    // ����� ���� ������ �� �������
    private void Swap(int i, int j)
    {
        int temp = _heap[i];
        _heap[i] = _heap[j];
        _heap[j] = temp;
    }
}

public class MaxHeap
{
    private List<int> _heap = new List<int>();

    // ����� ��� ��� Max-Heap
    public int Peek()
    {
        if (_heap.Count == 0) throw new InvalidOperationException("The heap is empty.");
        return _heap[0];
    }

    // ����� ���� ��� ��� Max-Heap
    public void Push(int val)
    {
        _heap.Add(val);
        HeapifyUp();
    }

    // ������� ���� ���� �� ��� Max-Heap
    public int Pop()
    {
        if (_heap.Count == 0) throw new InvalidOperationException("The heap is empty.");
        int result = _heap[0];
        _heap[0] = _heap[_heap.Count - 1];
        _heap.RemoveAt(_heap.Count - 1);
        HeapifyDown();
        return result;
    }

    // ���� ������ ������� ������
    public List<int> ToList()
    {
        return new List<int>(_heap);
    }

    // ����� ������� �� ������ ������
    private void HeapifyUp()
    {
        int index = _heap.Count - 1;
        while (index > 0)
        {
            int parentIndex = (index - 1) / 2;
            if (_heap[index] <= _heap[parentIndex]) break;
            Swap(index, parentIndex);
            index = parentIndex;
        }
    }

    // ����� ������� �� ������ ������
    private void HeapifyDown()
    {
        int index = 0;
        while (index < _heap.Count)
        {
            int leftChild = 2 * index + 1;
            int rightChild = 2 * index + 2;
            int largest = index;

            if (leftChild < _heap.Count && _heap[leftChild] > _heap[largest]) largest = leftChild;
            if (rightChild < _heap.Count && _heap[rightChild] > _heap[largest]) largest = rightChild;
            if (largest == index) break;

            Swap(index, largest);
            index = largest;
        }
    }

    // ����� ���� ������ �� �������
    private void Swap(int i, int j)
    {
        int temp = _heap[i];
        _heap[i] = _heap[j];
        _heap[j] = temp;
    }
}
