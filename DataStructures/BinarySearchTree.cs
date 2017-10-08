using System;

namespace Algorithms.DataStructures
{
    public class BinarySearchTreeNode<T> where T : IComparable<T>
    {
        public BinarySearchTreeNode<T> Parent { get; set; }
        public BinarySearchTreeNode<T> Left { get; set; }
        public BinarySearchTreeNode<T> Right { get; set; }

        private T _value;
        public T Value { get { return this._value; } }

        public BinarySearchTreeNode(T value, BinarySearchTreeNode<T> parent)
        {
            this.Left = null;
            this.Right = null;
            this.Parent = parent;
            this._value = value;
        }

        public void Insert(T insertValue)
        {
            var comparison = this.Compare(insertValue);

            if (comparison < 0)
            {
                if (this.Left == null)
                    this.Left = new BinarySearchTreeNode<T>(insertValue, this);
                else
                    this.Left.Insert(insertValue);
            }
            else
            {
                if (this.Right == null)
                    this.Right = new BinarySearchTreeNode<T>(insertValue, this);
                else
                    this.Right.Insert(insertValue);
            }
        }

        public void Delete(T deleteValue, Action<BinarySearchTreeNode<T>> setRootNode)
        {
            var node = this.Find(deleteValue);
            if (node == null)
                throw new InvalidOperationException(String.Format("Unable to find value {0} for deletion.", deleteValue));

            if (node.Left == null && node.Right == null)
                this.ReassignParentNodeChild(node, null, setRootNode);
            else if (node.Left != null && node.Right == null)
                this.ReassignParentNodeChild(node, node.Left, setRootNode);
            else if (node.Left == null && node.Right != null)
                this.ReassignParentNodeChild(node, node.Right, setRootNode);
            else
            {
                var minimumValue = node.Right.Minimum().Value;
                node.Right.Delete(minimumValue, setRootNode);
                node._value = minimumValue;
            }
        }

        public BinarySearchTreeNode<T> Find(T findValue)
        {
            var comparison = this.Compare(findValue);

            if (comparison == 0)
                return this;
            else if (comparison < 0)
                return (this.Left != null) ? this.Left.Find(findValue) : null;
            else
                return (this.Right != null) ? this.Right.Find(findValue) : null;
        }

        public BinarySearchTreeNode<T> Minimum()
        {
            var node = this;
            while (node.Left != null)
                node = node.Left;
            return node;
        }

        public void Traverse(Action<T> process)
        {
            process(this.Value);

            if (this.Left != null)
                this.Left.Traverse(process);

            if (this.Right != null)
                this.Right.Traverse(process);
        }

        private void ReassignParentNodeChild(
            BinarySearchTreeNode<T> deletionNode,
            BinarySearchTreeNode<T> replacementNode,
            Action<BinarySearchTreeNode<T>> setRootNode)
        {
            if (deletionNode.Parent == null)
                setRootNode(replacementNode);
            else if (deletionNode.Parent.Left == deletionNode)
                deletionNode.Parent.Left = replacementNode;
            else if (deletionNode.Parent.Right == deletionNode)
                deletionNode.Parent.Right = replacementNode;
            else
                throw new InvalidOperationException("Deletion node not found on parent");

            if (replacementNode != null)
                replacementNode.Parent = deletionNode.Parent;
        }

        private int Compare(T value)
        {
            return value.CompareTo(this.Value);
        }
    }

    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private BinarySearchTreeNode<T> rootNode;

        public BinarySearchTree()
        {
            this.rootNode = null;
        }

        public void Insert(T insertValue)
        {
            if (this.rootNode == null)
                this.rootNode = new BinarySearchTreeNode<T>(insertValue, null);
            else
                this.rootNode.Insert(insertValue);
        }

        public void Delete(T deleteValue)
        {
            if (this.rootNode == null)
                throw new InvalidOperationException("Cannot delete on empty tree");

            this.rootNode.Delete(deleteValue, node => { this.rootNode = node; });
        }

        public BinarySearchTreeNode<T> Find(T findValue)
        {
            return this.rootNode != null
                ? this.rootNode.Find(findValue)
                : null;
        }

        public BinarySearchTreeNode<T> Minimum()
        {
            return this.rootNode != null
                ? this.rootNode.Minimum()
                : null;
        }

        public void Traverse(Action<T> process)
        {
            if (this.rootNode != null)
                this.rootNode.Traverse(process);
        }
    }
}
