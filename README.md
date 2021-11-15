# Daily_Task
For C# daily tasks


2021.11.09
1.  Create a git repo for daily task(Note, this is only used for daily task, you can upload any code related our work), and please upload the code for yesterday’s task(Fixed version).
2.  Implement an algorithm "Minimum Edit Distance (MED, 最小编辑距离)"
You can choose whether to implement it as a class or method. The class/method should get two strings and calculate MED.
Learn how to do unit test, and write a unit test method to verify your MED class/method.
You need to first understand what is the MED, and then implement it.
For the unit test part, please take a look at the Microsoft Doc for this part.

2021.11.10
1. Create a data structure (a class named “NGram”) to hold N-Gram information of an English sentence. You can design the class and implement it in any way you like. Your data structure should contain at least below information:
a. Value of N
b. The original sentence
c. Its N-Gram forms from 1-Gram (also called unigram) to N-Gram

2. Write a method which can parse an English sentence into NGram instance. e.g.  NGram CreateNGram(string sentence, int n)
To simplify the process, we only need to consider below cases:
a. The sentence is in English (split by space)
b. There is no punctuation at the start/end of the sentence, and there is no punctuation between every two words
c. A word with pure numbers can be consider as a normal word
d. A word which has any punctuation inside (e.g. “It’s”) can be consider as a normal word.


2021.11.11

I'd like you to learn an algorithm of evaluating a target sentence (the translation output) against a reference sentence (the perfect human-translated sentence), which is called "BLEU (Bilingual Evaluation Understudy)". This algorithm is widely used in assessing the quality of a machine translation model.
Try to search and understand how this algorithm works. Here is a paper which may help you: https://www.aclweb.org/anthology/P02-1040.pdf
Requirements
a. It'll be good if you could write some code to implement BLEU (up to 4-gram) by your understanding. Your code will be able to get two English sentences (target and reference), and output from P_1 to P_4, and P_overall. (You don't need to finish it by today)
b. In your today’s daily report, write something with what you learn and understand about BLEU.
c. The detailed problem for the Vibranium training document. (You can find some paper to read according to your problem in this training)

Further improvement: for now, we don’t only rely on the BLEU score. We have a score concept named COMET, here are two papers about this topic.
COMET: A Neural Framework for MT Evaluation (aclanthology.org)
2107.10821.pdf (arxiv.org)

2021.11.12 
Python nltk source code: https://github.com/nltk/nltk/blob/7d3d6a4f77b76a1f5eb0d0cbc9731716fcc17e68/nltk/util.py#L825
a link related to article: https://www.cnblogs.com/by-dream/p/7679284.html
For today’s task: 
1.	Please go ahead about the BLEU score implementation.
2.	we may have the need of reading/modifying XML settings for tools and pipelines in our work, I would need you to write some code to parse XML.
<?xml version='1.0' encoding='utf-8'?>
<Job>
    <Configuration>
        <UseShell>true</UseShell>
        <Size>4</Size>
        <EncodingString>UTF-8</EncodingString>
    </Configuration>
    <DataPath>
        <Input>d:/test/data</Input>
        <Output>d:/test/result</Output>
    </DataPath>
</Job>

Your code should read above XML settings from file "JobConfig.xml", and load its settings into a C# object "Job". "Job" will have two members: "Configuration" and "DataPath". For example:

class Job{
    Configuration Config;
    DataPath Data;
}

class Configuration{
    bool UseShell;
    ...
}

class DataPath{
   ...
}

Please use at least two approaches to achieve the requirement (e.g. deserialization, read each setting manually).

You can create a simple xml file to test your code.

