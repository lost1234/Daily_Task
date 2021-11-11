using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGram
{
    public class NGram{
        
        public static List<string> CreateNGram(string str, int n)
        {
            var result = new List<string>();
            string[] words = str.Split(' ');
            //words.length - n + 1 is the number of word pair 
            for(int i = 0;i < words.Length - n + 1;i++)
            {
                result.Add(Concat(words, i, i + n)) ;
            }
            return result;
        }

        public static string Concat(string[] words, int start, int end)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = start;i < end;i++)
            {
                sb.Append((i > start ? " " : "") + words[i]); 
            }
            return sb.ToString();
        }
    }
    public class BLEU
    {
        //n: the ngram order
        public double BleuScore(string reference, string candidate, double[] weight) 
        {
            //NGram nGram = new NGram();
            //List<string> r_ngram = NGram.CreateNGram(reference, n);
            //List<string> c_ngram = NGram.CreateNGram(candidate, n);
            ////ngram in candidate
            //int count = r_ngram.Count();
            //max_ref_count = 
            //int cliped_count = Math.Min(count, max_ref_count);
            return;
        }
        public int CountClip()
        {
            return 
        }
        //best match: candidate_len = reference_len  -- no penalty
        // if candidate_len != reference_len : 
        public double brevity_penalty(int reference, int candidate)
        {
            if (candidate > reference)
            {
                return 1.0;
            }
            else if(reference == 0) 
            {
                return 0;
            }

            return Math.Exp(1 - reference / candidate);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string str = "This is a car";
            Console.WriteLine("Please enter the size n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            var result = new List<string>();
            result = NGram.CreateNGram(str, n);
            foreach (var val in result)
            {
                Console.WriteLine(val);
            }


            Console.ReadKey();
        } 
    }
}
