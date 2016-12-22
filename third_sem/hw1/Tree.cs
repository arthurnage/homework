using System;
using System.Collections.Generic;
using System.Collections;

namespace MyWorks
{
    public class Tree<T> : IEnumerable<T> where T : IComparable
    {
        /// <summary>
        /// Tree node class
        /// </summary>
        private class TreeNode
        {
            public T Value { get; set; }
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }
            public TreeNode Parent { get; set; }

            /// <summary>
            /// Initializes a new instance of the treenode class.
            /// </summary>
            /// <param name="value">Value.</param>
            public TreeNode(T value, TreeNode parent)
            {
                Value = value;
                Parent = parent;
            }
        }

        /// <summary>
        /// The root of the tree
        /// </summary>
        private TreeNode root;

        /// <summary>
        /// Anount of tree nodes
        /// </summary>
        private int length;

        /// <summary>
        /// Adds an element to the tree
        /// </summary>
        /// <param name="value">Value.</param>
        public void Add(T value)
        {
            if (root == null)
            {
                root = new TreeNode(value, null);
                length++;
            }
            else
            {
                Add(root, value);
            }
        }

        /// <summary>
        /// Recursively adds passed value to the passed tree
        /// </summary>
        /// <param name="root">Root.</param>
        /// <param name="value">Value.</param>
        private void Add(TreeNode root, T value)
        {
            if (root.Left == null && root.Value.CompareTo(value) == 1)
            {
                root.Left = new TreeNode(value, root);
                length++;
                return;
            }
            if (root.Right == null && root.Value.CompareTo(value) == -1)
            {
                root.Right = new TreeNode(value, root);
                length++;
                return;
            }
            if (root.Value.CompareTo(value) == 1)
            {
                Add(root.Left, value);
            }
            else if (root.Value.CompareTo(value) == -1)
            {
                Add(root.Right, value);
            }
        }

        /// <summary>
        /// Determines whether this value is belong to the tree by using IsBelongFunction
        /// </summary>
        /// <returns><c>true</c> if this instance is belong the specified value; otherwise, <c>false</c>.</returns>
        /// <param name="value">Value.</param>
        public bool IsBelong(T value) => root != null && IsBelong(root, value) != null;

        /// <summary>
        /// Recursive subsidiary function for checking is element belongs to the tree
        /// </summary>
        /// <returns><c>true</c>, if belong function was ised, <c>false</c> otherwise.</returns>
        /// <param name="root">Root.</param>
        /// <param name="value">Value.</param>
        private TreeNode IsBelong(TreeNode root, T value)
        {
            if (root.Value.Equals(value))
            {
                return root;
            }
            if (root.Left == null && root.Value.CompareTo(value) == 1)
            {
                return null;
            }
            if (root.Right == null && root.Value.CompareTo(value) == -1)
            {
                return null;
            }
            return (root.Value.CompareTo(value) == -1) ? IsBelong(root.Right, value) : IsBelong(root.Left, value);
		}

        /// <summary>
        /// Removes an element from the tree
        /// </summary>
        /// <param name="value">Value.</param>
		public void Remove(T value)
        {
            var current = IsBelong(root, value);
            if (current != null)
            {
                if (current.Left == null)
                {
                    current = current.Right;
                    length--;
                    return;
                }
                if (current.Right == null)
                {
                    current = current.Left;
                    length--;
                    return;
                }
                var changeNode = GetMostLeftNode(current.Right);
                changeNode.Parent.Left = changeNode.Right;
                current.Value = changeNode.Value;
                length--;
            }
		}

        /// <summary>
        /// Returns the most left son of the tree node
        /// </summary>
        /// <returns>The most left node.</returns>
        /// <param name="root">Root.</param>
        private static TreeNode GetMostLeftNode(TreeNode root) => (root.Left != null) ? GetMostLeftNode(root.Left) : root;

        /// <summary>
        /// Shows is the tree empty
        /// </summary>
        /// <returns><c>true</c>, if emply was ised, <c>false</c> otherwise.</returns>
        public bool IsEmply() => (root == null);

        /// <summary>
        /// Returns anount of tree elements
        /// </summary>
        public int Length() => length;

        /// <summary>
        /// Implementation for the GetEnumerator method
        /// </summary>
        /// <returns>The collections. IE numerable. get enumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator() => (IEnumerator)GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => (IEnumerator<T>)GetEnumerator();

        public IEnumerator<T> GetEnumerator() => new TreeEnumerator(this);

        private class TreeEnumerator : IEnumerator<T>
        {
            private Tree<T> tree;
            private int position = -1;
            private TreeNode current;

            public TreeEnumerator(Tree<T> newTree)
            {
                tree = newTree;
                Reset();
            }

            public void Dispose()
            {
            }

            /// <summary>
            /// Moves the enumerator to the next element of the collection/
            /// </summary>
            /// <returns><c>true</c>, if next was moved, <c>false</c> otherwise.</returns>
            public bool MoveNext()
            {
                if (current == null)
                {
                    current = GetMostLeftNode(tree.root);
                }
                else
                {
                    if (current.Right != null)
                    {
                        current = current.Right;
                        while (current.Left != null)
                        {
                            current = current.Left;
                        }
                    }
                    else if (current.Parent != null)
                    {
                        while (current.Parent != null && current.Parent.Value.CompareTo(current.Value) == -1)
                        {
                            current = current.Parent;
                        }
                        current = current.Parent;
                    }
                }
                position++;
                return position < tree.Length();
            }

            /// <summary>
            /// Sets the enumerator to its initial position, which is before the first element in the collection.
            /// </summary>
            public void Reset()
            {
                position = -1;
                current = null;
            }

            /// <summary>
            /// Gets the current element of collection.
            /// </summary>
            /// <value>The system. collections. IE numerator. current.</value>
            object IEnumerator.Current
            {
                get { return Current; }
            }

            /// <summary>
            /// Returns value of the current element of the list
            /// </summary>
            /// <value>The current.</value>
            public T Current
            {
                get
                {
                    try
                    {
                        return current.Value;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }
    }
}