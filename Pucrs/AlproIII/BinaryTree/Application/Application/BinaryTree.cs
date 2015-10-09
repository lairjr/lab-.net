using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    // BinaryTree.java
    public class BinaryTree
    {

        // ReferÃªncia para a raiz da Ã¡rvore. Ã‰ null para o caso de uma
        // Ã¡rvore vazia.

        private Node root;

        /*
         Node
         A Ã¡rvore binÃ¡ria usa esta classe interna. Cada nodo contÃ©m
         uma informaÃ§Ã£o e referÃªncias para as sub-Ã¡rvores esquerda e
         direita.
        */
        private class Node
        {
            public Node left { get; set; }
            public Node right { get; set; }
            public int data { get; set; }

            //Node(int newData)
            //{
            //    left = right = null;
            //    data = newData;
            //}
        }

        /* Cria uma Ã¡rvore vazia, ou seja, uma referÃªncia nula. */
        public BinaryTree()
        {
            root = null;
        }

        /* InserÃ§Ã£o na Ã¡rvore. Usa o mÃ©todo auxiliar */
        public void insert(int data)
        {
            root = insert1(root, data);
        }

        /* InserÃ§Ã£o nÃ£o-recursiva.  */
        private Node insert1(Node root, int data)
        {
            Node novo = new Node { data = data };

            if (root == null) return novo;

            Node node = root;

            while (true)
            {
                if (data < node.data)
                    if (node.left == null) { node.left = novo; break; }
                    else node = node.left;
                else
                    if (node.right == null) { node.right = novo; break; }
                    else node = node.right;
            }
            return root;
        }

        /*
         InserÃ§Ã£o recursiva.
         Dado um nodo, percorre a sub-Ã¡rvore atÃ© achar o local de inserÃ§Ã£o
         do valor pedido. Retorna uma referÃªncia para o novo nodo. Elementos
         repetidos sÃ£o permitidos.
        */
        private Node insert2(Node node, int data)
        {
            if (node == null)
                return new Node { data = data };
            if (data == node.data) return node;
            if (data < node.data) node.left = insert2(node.left, data);
            else node.right = insert2(node.right, data);
            return node;
        }

        /* Destroi uma Ã¡rvore chamando um mÃ©todo interno */
        public void destroy()
        {
            root = destroy(root);
        }

        /* MÃ©todo interno para destruiÃ§Ã£o */
        private Node destroy(Node node)
        {
            if (node == null) return null;
            node.left = destroy(node.left);
            node.right = destroy(node.right);
            return null;
        }

        public void Print()
        {
            this.PrintNode(root);
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }

        private void PrintNode(Node node)
        {
            if (node != null)
            {
                Console.Write(node.data + " -> ");
                if (node.left != null)
                    Console.Write(node.left.data + " ");
                else
                    Console.Write("null ");
                if (node.right != null)
                    Console.Write(node.right.data + " ");
                else
                    Console.Write("null ");
                Console.WriteLine();
                this.PrintNode(node.left);
                this.PrintNode(node.right);
            }
        }

        public bool Exist(int value)
        {
            return (this.Exist(root, value) != null);
        }

        private Node Exist(Node node, int value)
        {
            if (node != null)
            {
                if (node.data == value)
                    return node;
                if (node.left != null)
                    return this.Exist(node.left, value);
                if (node.right != null)
                    return this.Exist(node.right, value);
            }
            return null;
        }

        public int GetHeight()
        {
            return this.GetHeight(root);
        }

        private int GetHeight(Node node)
        {
            var letfHeight = 0;
            var rightHeight = 0;

            if (node.left != null)
            {
                letfHeight = this.GetHeight(node.left) + 1;
            }
            if (node.right != null)
            {
                rightHeight = this.GetHeight(node.right) + 1;
            }

            var sumValue = (letfHeight > rightHeight) ? letfHeight : rightHeight;
            return sumValue;
        }

        public int GetCount()
        {
            return this.GetCount(root);
        }

        private int GetCount(Node node)
        {
            var letfCount = 0;
            var rightCount = 0;

            if (node.left != null)
            {
                letfCount = this.GetCount(node.left);
            }
            if (node.right != null)
            {
                rightCount = this.GetCount(node.right);
            }

            return letfCount + rightCount + 1;
        }

        public int GetFather(int value)
        {
            var father = this.GetFather(root, value);
            return (father != null) ? father.data : -1;
        }

        private Node GetFather(Node node, int childValue)
        {
            var returnNode = node;
            if (node.left != null)
            {
                if (node.left.data == childValue)
                    return node;
                returnNode = this.GetFather(node.left, childValue);
            }
            if (node.right != null)
            {
                if (node.right.data == childValue)
                    return node;
                returnNode = this.GetFather(node.right, childValue);
            }
            return returnNode;
        }
    }
}
