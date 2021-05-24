using System;
using System.Collections.Generic;

namespace LeetCode
{

public class HardProblems
	{
        public static int CarFleet( int[] position, int[] speed)
        {
            int target = 12;   
            int total = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < position.Length; i++)
            {
                map.Add(position[i], (target-position[i])/speed[i]);
            }
            Array.Sort(position);
            Array.Reverse(position);
            int curr = 0;
            for(int i=0; i<position.Length; i++)
            {
                if (map[position[i]] > curr)
                {
                    curr = map[position[i]];
                    total++;
                }
            }
            return total;
        }
        public static int matches(string word, string word2)
        {
            int matches = 0;
            for (int i = 0; i < 6; i++)
            {
                if (word[i] == word2[i]) matches++;
            }
            return matches;
        }

        public static string[] helper(string myGuess, int num, string[] list)
        {
            List<string> deleteWords = new List<string>();
            foreach (string word in list)
            {
                if (matches(myGuess, word) != num)
                {
                    deleteWords.Add(word);
                }
            }
            List<string> newList = new List<string>(list);
            for (int i = 0; i < deleteWords.Count; i++)
            {
                newList.Remove(deleteWords[i]);
                
            }
            return newList.ToArray();
        }
        public static void FindSecretWord()
        {

            string secret = "ccoyyo";
            string[] wordlist = new string[] { "wichbx", "oahwep", "tpulot", "eqznzs", "vvmplb", "eywinm", "dqefpt", "kmjmxr", "ihkovg", "trbzyb", "xqulhc", "bcsbfw", "rwzslk", "abpjhw", "mpubps", "viyzbc", "kodlta", "ckfzjh", "phuepp", "rokoro", "nxcwmo", "awvqlr", "uooeon", "hhfuzz", "sajxgr", "oxgaix", "fnugyu", "lkxwru", "mhtrvb", "xxonmg", "tqxlbr", "euxtzg", "tjwvad", "uslult", "rtjosi", "hsygda", "vyuica", "mbnagm", "uinqur", "pikenp", "szgupv", "qpxmsw", "vunxdn", "jahhfn", "kmbeok", "biywow", "yvgwho", "hwzodo", "loffxk", "xavzqd", "vwzpfe", "uairjw", "itufkt", "kaklud", "jjinfa", "kqbttl", "zocgux", "ucwjig", "meesxb", "uysfyc", "kdfvtw", "vizxrv", "rpbdjh", "wynohw", "lhqxvx", "kaadty", "dxxwut", "vjtskm", "yrdswc", "byzjxm", "jeomdc", "saevda", "himevi", "ydltnu", "wrrpoc", "khuopg", "ooxarg", "vcvfry", "thaawc", "bssybb", "ccoyyo", "ajcwbj", "arwfnl", "nafmtm", "xoaumd", "vbejda", "kaefne", "swcrkh", "reeyhj", "vmcwaf", "chxitv", "qkwjna", "vklpkp", "xfnayl", "ktgmfn", "xrmzzm", "fgtuki", "zcffuv", "srxuus", "pydgmq" };
         
            int guesses = 0, top=0;
            string fit = "";
            while (guesses <10)
            {
                string myGuess = wordlist[0];
                int match = matches(myGuess, secret);
                if (match > top)
                {
                    fit = myGuess;
                    top = match;
                }
                if (match == 6)
                {
                    Console.WriteLine("You have correctly guessed the word!");
                    return;
                }
                wordlist = helper(myGuess, match, wordlist);
                if (wordlist.Length < 10)
                {
                    List<string> deleteWords = new List<string>();
                    foreach(string word in wordlist)
                    {
                        if(matches(word, fit) != top)
                        {
                            deleteWords.Add(word);
                        }
                    }
                    List<string> newList = new List<string>(wordlist);
                    for (int i = 0; i < deleteWords.Count; i++)
                    {
                        newList.Remove(deleteWords[i]);

                    }
                    wordlist = newList.ToArray();
                }
                if (guesses == 9)
                {

                }
                guesses++;
            }
        }
    }

}