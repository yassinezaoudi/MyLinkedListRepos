using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinkedList
{
    class MyLinkedListNode<T>
    {
        public T Content;
        public MyLinkedListNode<T> Next;
        public MyLinkedListNode<T> Previous;
        public MyLinkedListNode(T content)
        {
            Content = content;
        }
    }
}
