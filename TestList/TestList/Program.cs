using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestList
{
    class ListNode
    {
        public ListNode Prev;
        public ListNode Next;
        public ListNode Rand; // произвольный элемент внутри списка
        public string Data;
    }

    class ListRand
    {
        public ListNode Head;
        public ListNode Tail;
        public int Count;

        public void Serialize(FileStream s)
        {
            List<ListNode> nodes = new List<ListNode>();
            for(var node = Head; node != null; node = node.Next)
            {
                nodes.Add(node);
            }

            using (StreamWriter w = new StreamWriter(s))
            {
                foreach (var node in nodes)
                {
                    w.WriteLine(node.Data + " " + nodes.IndexOf(node.Rand).ToString());
                }
            }
            

        }

        public void Deserialize(FileStream s)
        {

            List<ListNode> nodes = new List<ListNode>();
            List<int> randNode = new List<int>();
            Head = new ListNode();
            Tail = new ListNode();

            Head = Tail;

            using(StreamReader r = new StreamReader(s))
            {
                string line;

                while((line = r.ReadLine()) != null)
                {
                    if (!line.Equals(""))
                    {
                        ListNode node = new ListNode();
                        var data = line.Split(' ');

                        Tail.Data = data[0];
                        nodes.Add(Tail);
                        randNode.Add(Convert.ToInt32(data[1]));
                        Tail.Next = node;
                        node.Prev = Tail;
                        Tail = node;
                    }
                    
                }

                Tail = Tail.Prev;
                Tail.Next = null;

                for(var i = 0; i < nodes.Count; i++)
                {
                    nodes[i].Rand = nodes[randNode[i]];
                }

                Count = nodes.Count;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            List<ListNode> nodes = new List<ListNode>();
            ListRand listRand = new ListRand();
            ListNode head = new ListNode();
            ListNode tail = new ListNode();
            ListNode Rand = new ListNode();
            int count = 10;
            tail = head;

            head.Data = rnd.Next(0, 25).ToString();

            nodes.Add(head);

            for (var i = 1; i < count; i++)
            {
                ListNode node = new ListNode();
                tail.Next = node;
                node.Prev = tail;
                tail = node;
                node.Data = rnd.Next(0, 25).ToString();
                nodes.Add(node);
            }

            listRand.Head = head;
            listRand.Tail = tail;
            listRand.Count = count;


            for(var node = head; node != null; node = node.Next)
            {
                node.Rand = nodes[rnd.Next(0, count)];
               
            }

            var exePath = AppDomain.CurrentDomain.BaseDirectory;
            var path = Path.Combine(exePath, "ListRand.txt");

            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);

            listRand.Serialize(fs);

            fs.Close();

            fs = new FileStream(path, FileMode.Open);

            var testList = new ListRand();
            testList.Deserialize(fs);

            var n = testList.Tail;

            Console.Write(n.Data + " ");

            n = n.Prev;

            while (n != null)
            {
                Console.Write(n.Data + " ");
               
                n = n.Prev;
            }

            Console.Read();
        }
    }
}
