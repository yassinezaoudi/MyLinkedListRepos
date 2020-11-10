using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MyLinkedList
{
    class MyLinkedList<T>
    {
        public MyLinkedListNode<T> First;
        public MyLinkedListNode<T> Last;
        public int Count = 0;

        public MyLinkedList(T firstPositionContent)
        {
            MyLinkedListNode<T> tempHead = new MyLinkedListNode<T>(firstPositionContent);
            First = tempHead;
            Last = First;
            Count = 1;
        }

        public MyLinkedList(MyLinkedListNode<T> tempHead)
        {
            First = tempHead;
            Last = First;
            Count = 1;
        }

        public MyLinkedList(T[] temparray)
        {
            if (temparray.Length == 0)
                throw new ArgumentNullException();
            First = new MyLinkedListNode<T>(temparray[0]);
            Last = First;
            for (int i = 1; i < temparray.Length; i++)
                AddLast(temparray[i]);
            Count = temparray.Length;
        }

        public void AddLast(T contentOfNextItem)
        {
            if (First == null)
            {
                First = new MyLinkedListNode<T>(contentOfNextItem);
                Last = First;
                return;
            }
            MyLinkedListNode<T> nextItem = new MyLinkedListNode<T>(contentOfNextItem);
            if(Last == First)
            {
                Last = nextItem;
                Last.Previous = First;
                First.Next = Last;
            }
            else
            {
                Last.Next = nextItem;
                nextItem.Previous = Last;
                Last = nextItem;
            }
            Count++;
        }

        public void AddFirst(T contentOfNewFirstItem)
        {
            if(First == null)
            {
                First = new MyLinkedListNode<T>(contentOfNewFirstItem);
                Last = First;
                return;
            }
            MyLinkedListNode<T> newItem = new MyLinkedListNode<T>(contentOfNewFirstItem);
            newItem.Next = First;
            First.Previous = newItem;
            First = newItem;
            Count++;
        }

        public bool Contains(int searchingContent)
        {
            bool finder = false;

            MyLinkedListNode<T> temp = First;
            while(temp != null)
            {
                if(temp.Content.Equals(searchingContent))
                {
                    finder = true;
                    break;
                }
                temp = temp.Next;
            }

            return finder;
        }

        public void RemoveFirst()
        {
            First = First.Next;
            Count--;
        }
        public void RemoveLast()
        {
            Last = Last.Previous;
            Count--;
        }

        public void AddAfter(MyLinkedListNode<T> node, T content)
        {
            MyLinkedListNode<T> tempNode = new MyLinkedListNode<T>(content);
            if (node == Last)
            {
                node.Next = tempNode;
                tempNode.Previous = node;
                Last = tempNode;
            }
            else
            {
                tempNode.Next = node.Next;
                tempNode.Next.Previous = tempNode;
                node.Next = tempNode;
                tempNode.Previous = node;
            }
            Count++;
        }
        public void AddBefore(MyLinkedListNode<T> node, T content)
        {
            MyLinkedListNode<T> tempNode = new MyLinkedListNode<T>(content);
            if (node == First)
            {
                tempNode.Next = node;
                node.Previous = tempNode;
                First = tempNode;
            }
            else
            {
                tempNode.Next = node;
                tempNode.Previous = node.Previous;
                node.Previous.Next = tempNode;
                node.Previous = tempNode;
            }
            Count++;

        }

        public void Remove(MyLinkedListNode<T> node)
        {
            if(node == First)
            {
                First = node.Next;
                First.Previous = null;
            }
            else if(node == Last)
            {
                Last = node.Previous;
                Last.Next = null;
            }
            else
            {
                node.Previous.Next = node.Next;
                node.Next.Previous = node.Previous;
            }
            Count--;
        }

        public MyLinkedListNode<T> Find(T searchingContent)
        {
            MyLinkedListNode<T> temp = First;
            while(temp != null)
            {
                if (temp.Content.Equals(searchingContent))
                    return temp;
                temp = temp.Next;
            }
            return null;
        }
        public MyLinkedListNode<T> FindLast(T searchingContent)
        {
            MyLinkedListNode<T> temp = Last;
            while(temp != null)
            {
                if (temp.Content.Equals(searchingContent))
                    return temp;
                temp = temp.Previous;
            }
            return null;
        }

        public void Add(T content)
        {
            AddLast(content);
        }

        public void Clear()
        {
            First = null;
            Last = null;
            Count = 0;
        }
        public void CopyTo(T[] array, int index)
        {
            MyLinkedListNode<T> listItem = First;
            while (listItem != null)
            {
                array[index] = listItem.Content;
                listItem = listItem.Next;
                index++;
            }
        }
    }
}
