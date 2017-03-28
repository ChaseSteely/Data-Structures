using System;
using System.Text;

namespace SimpleLinkedList
{
    public class SimpleLinkedList<T> where  T : IComparable<T>
    {
        private ListNode<T> head;
        public int Count { get; private set; }

        /// <summary>
        /// Constructor simply creates the sentinel node.
        /// </summary>
        public SimpleLinkedList()
        {
            head = new ListNode<T>();
        }

        /// <summary>
        /// Adds an entry to the head of the list.  A node is created with the object passed in as its data.
        /// </summary>
        /// <param name="element">The data to be added.</param>
        public void AddAtHead(T element)
        {
            ListNode<T> node = new ListNode<T>();
            node.Data = element;
            node.Next = head.Next;
            head.Next = node;
            Count++;
        }

        /// <summary>
        /// Remove the first entry in the list and return its data.
        /// </summary>
        /// <returns></returns>
        public T RemoveFromHead()
        {
            ListNode<T> node = head.Next;
            T data;
            if (head.Next != null) {
                head.Next = head.Next.Next;
            }
            Count--;

            data = node.Data;
            node.Data = default(T); // probably not needed since result is no longer accessible

            return data;
        }

        /// <summary>
        /// Walks through the list looking for the node that preceeds the node containing the target.
        /// The object's CompareTo method is used to determine equality.
        /// </summary>
        /// <param name="target">The object to be found.</param>
        /// <returns>The node prior to the node containing the target, or null if it is not found.</returns>
        private ListNode<T> FindNodeBefore(T target)
        {
            ListNode<T> prev = null;
            prev = head;
            while (prev.Next != null) {
                if (prev.Next.Data.CompareTo(target) == 0) {
                    return prev;
                }
                prev = prev.Next;
            }

            // never found
            return null;
        }

        /// <summary>
        /// Find the specified target.  The object is considered 'found' if the object's CompareTo method returns zero.
        /// </summary>
        /// <param name="target">The object to be found.</param>
        /// <returns></returns>
        public T Find(T target)
        {
            ListNode<T> result = FindNodeBefore(target);
            if (result == null)
                return default(T);

            // advance result to the one we are looking for.
            result = result.Next;
            return result.Data;
        }

        /// <summary>
        /// Removes the specified target if the target's CompareTo method returns zero.
        /// </summary>
        /// <param name="target">The object to be removed.</param>
        /// <returns></returns>
        public T Remove(T target)
        {
            T data = default(T);
        
            ListNode<T> result = FindNodeBefore(target);
      
            if (result == null)
            {
                head = head.Next;
            }
            else
            {
                result.Next = result.Next.Next;
               
            }
                return data;
        }
    }
}
