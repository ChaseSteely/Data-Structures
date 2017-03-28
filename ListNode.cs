using System;

namespace SimpleLinkedList
{
    public class ListNode<T>
    {
        /// <summary>
        /// The field that hold the data for the node.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Pointer to the next node in the list, if applicable.
        /// </summary>
        public ListNode<T> Next { get; set; }

        /// <summary>
        /// noarg constructor
        /// </summary>
        public ListNode(){}

        /// <summary>
        /// Constructor sets the Data property from its argument.
        /// </summary>
        /// <param name="data"></param> Data for this node.
        public ListNode(T data)
        {
            Data = data;
        }
    }
}