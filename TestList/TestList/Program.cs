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
            Dictionary<ListNode, int> nodes = new Dictionary<ListNode, int>();
            int index = 0;
            for(var node = Head; node != null; node = node.Next)
            {
                nodes.Add(node, index);
                index += 1;
            }
           
            using (StreamWriter w = new StreamWriter(s))
            {
                for (var node = Head; node != null; node = node.Next)
                {
                    var rand = node.Rand == null ? "null" : nodes[node.Rand].ToString();
                    w.WriteLine(node.Data + '\n' + rand);
                }
            }
            

        }

        public void Deserialize(FileStream s)
        {
            Dictionary<int, ListNode> result = new Dictionary<int, ListNode>();

            using(StreamReader r = new StreamReader(s))
            {
                string line;

                var file = r.ReadToEnd();
                var str = file.Replace("\r", string.Empty).Trim().Split('\n');
                int counter = 2;
                var data = str.GroupBy(_ => counter++ / 2).Select(v => v.ToArray());
                int index = 0;

                ListNode head = new ListNode();
                ListNode tail = new ListNode();

                head = tail;

                foreach(var d in data)
                {
                    ListNode temp = new ListNode();
                    result.Add(index, tail);
                    tail.Data = d[0];
                    tail.Next = temp;
                    temp.Prev = tail;
                    tail = temp;
                    index += 1;
                }

                Head = head;
                Tail = tail;
                Count = data.Count();

                var iterator = data.GetEnumerator();
                iterator.MoveNext();

                for(var i =0; i < result.Count; i++)
                {
                    var currentData = iterator.Current;

                    if(currentData[1] != "" && currentData[1] != "null")
                    {
                        result[i].Rand = result[Convert.ToInt32(iterator.Current[1])];
                    }
                    iterator.MoveNext();
                }
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
            int count = 15;
            tail = head;

            head.Data = rnd.Next(0, 25).ToString();

            nodes.Add(head);

            for (var i = 1; i < count; i++)
            {
                ListNode node = new ListNode();
                tail.Next = node;
                node.Prev = tail;
                tail = node;

                node.Data = Convert.ToString(Convert.ToChar(rnd.Next(16, 128)));
                nodes.Add(node);
            }

            listRand.Head = head;
            listRand.Tail = tail;
            listRand.Count = count;

            var index = 0;

            for(var node = head; node != null; node = node.Next)
            {

                if(index % 2 == 0)
                {
                    node.Rand = null;
                }
                else
                {
                    node.Rand = nodes[rnd.Next(0, nodes.Count)];
                }

                index += 1;
               
            }

            var exePath = AppDomain.CurrentDomain.BaseDirectory;
            var path = Path.Combine(exePath, "ListRand.txt");

            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            fs.SetLength(0);

            listRand.Serialize(fs);

            fs.Close();

            fs = new FileStream(path, FileMode.Open);

            var testList = new ListRand();
            testList.Deserialize(fs);

            fs.Dispose();
            fs.Close();

            var n = testList.Tail;


            fs.Close();
            n = listRand.Head;

            while (n != null)
            {

               if(n.Rand != null)
               {
                    Console.WriteLine(n.Data + " " + n.Rand.Data);
               }
               else
               {
                    Console.WriteLine(n.Data);
               }

                n = n.Next;
            }

            Console.Read();
        }
    }
}
