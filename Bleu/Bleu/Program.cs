using System;
using System.Collections.Generic;
using System.Text;;

namespace NGram
{
    public class NGram
    {

        public static List<string> CreateNGram(string str, int n)
        {
            var result = new List<string>();
            string[] words = str.Split(' ');
            //words.length - n + 1 is the number of word pair 
            for (int i = 0; i < words.Length - n + 1; i++)
            {
                result.Add(Concat(words, i, i + n));
            }
            return result;
        }

        public static string Concat(string[] words, int start, int end)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = start; i < end; i++)
            {
                sb.Append((i > start ? " " : "") + words[i]);
            }
            return sb.ToString();
        }
    }

    public class BLEU
    {
        public static Dictionary<string, int> CountFrequency(List<string> list1)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (string val in list1)
            {
                if (!dict.ContainsKey(val))
                {
                    dict.Add(val, 1);
                }
                else
                {
                    dict[val]++;
                }
            }

            return dict;
        }
        //for Count_clip = min(Count, Max_Ref_Count) 
        //count: ngram in the candidate
        //mrc: (candidate)ngram in the reference 
        public static int CountClip(List<string> candidate, List<string> reference)
        {
            Dictionary<string, int> candidate_d = CountFrequency(candidate);
            Dictionary<string, int> reference_d = CountFrequency(reference);
            int clip_count = 0;

            foreach (string str in candidate_d.Keys)
            {
                if (reference_d.ContainsKey(str))
                {
                    clip_count += Math.Min(candidate_d[str], reference_d[str]);
                }
            }
            return clip_count;
        }

        //best match: candidate_len = reference_len  -- no penalty
        // if candidate_len != reference_len : 
        public static double brevity_penalty(int candidate, int reference)
        {
            if (candidate > reference)
            {
                return 1.0;
            }
            else if (reference == 0)
            {
                return 0;
            }

            return Math.Exp(1 - reference / candidate);
        }
        public static double modified_precision(string candidate, string reference, int n)
        {
            //int n = Convert.ToInt32(Console.ReadLine() ;
            List<string> candidate_l = NGram.CreateNGram(candidate, n);
            List<string> reference_l = NGram.CreateNGram(reference, n);

            int numerator = CountClip(candidate_l, reference_l);
            int denominator = Math.Max(1, candidate_l.Count);
            return numerator / denominator;
        }

        public static double BleuScore(string candidate, string reference, int n)
        {
            int len_c = candidate.Length;
            int len_r = reference.Length;
            double bp = brevity_penalty(len_c, len_r);
            double pn = modified_precision(candidate, reference, n);
            double sum = 0;
            for (int i = 0; i < 4; i++)
            {
                double wn = i / 4;
                sum = sum + Math.Log(modified_precision(candidate, reference, i)) * wn;
            }
            double score = Math.Exp(sum) * bp;
            return score;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //string candidate = "This is a car";
            //string reference = "This is a car" ;
            string candidate = "going to play basketball this afternoon";
            string reference = "going to play basketball in the afternoon";
            //string candidate = "the the the the the the" ;
            //string reference = "the cat sits on the ground" ;
            Console.WriteLine("Please enter the size n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            double score = BLEU.BleuScore(candidate, reference, n);
            Console.WriteLine(score);
            //Console.ReadKey();
        }
    }
}