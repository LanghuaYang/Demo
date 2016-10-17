using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = null;
            input = Console.ReadLine();
            string s = countwords(input);
            Console.WriteLine(s);
            string i = Console.ReadLine();
        }
        static string countwords(string input)
        {
            //int count1 = 0;
            //int temp_count = 1;
            //List<int> times = new List<int> { };
            //List<string> mostfreword = new List<string> { };
            //if (input != null)
            //{
            //    string[] words = input.Split();
            //    count1 = words.Length;
            //    for (int i = 0; i < words.Length; i++)
            //    {
            //        for (int j = i + 1; j < words.Length; j++)
            //        {
            //            if (words[i] == words[j])
            //            {
            //                temp_count++;
            //            }
            //        }
            //        //times[i] = temp_count;
            //        times.Add(temp_count);
            //        temp_count = 1;
            //    }  

            //    int max_times=0;  
            //    int indexOfWord=0;  
            //    for(int i=0;i< words.Length;++i)  
            //    {  
            //        if(times[i] > max_times)  
            //        {  
            //             max_times=times[i];  
            //             indexOfWord=i;
            //             mostfreword.Clear();
            //             mostfreword.Add(words[indexOfWord]);
            //        }
            //        if (times[i] == max_times)
            //        {
            //            max_times = times[i];
            //            indexOfWord = i;
            //            mostfreword.Add(words[indexOfWord]);
            //        }
            //    }
            //    mostfreword.Distinct();
            //}
            //string mfs = null;
            //foreach (var s in mostfreword)
            //{
            //    mfs += s.ToLower();
            //}
            //return mfs;
        string msf = null;
var words = input.ToLower()
    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
    .GroupBy(w => w)
    .OrderByDescending(g => g.Count());
        
  
    int fre = dic[0
      for(int j = 1,j < dic.length; j++)
          {
          if( i)
      }
}
        return msf;
        }
    }
}
