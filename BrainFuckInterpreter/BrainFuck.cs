﻿namespace BrainFuckInterpreter;

public class BrainFuck
{
    public int[] memory { get; private set; }
    public int pointer;
    public int index;
    public string code;

    public BrainFuck(string code)
    {
        this.code = code;
    }
    public BrainFuck(){}

    public void Run()
    {
        RunCode(code);
    }
    public void RunCode(string code)
    {
        this.memory = Enumerable.Repeat(0, 2048).ToArray();
        this.pointer = 0;
        this.code = code;
        this.index = 0;

        while (index < this.code.Length)
        {
            Command();
            index++;
        }
    }

    private void Command()
    {
        var command = code[index];

        switch (command)
        {
            case '>':
                pointer++;
                break;
            case '<':
                pointer--;
                break;
            case '+':
                memory[pointer]++;
                break;
            case '-':
                memory[pointer]--;
                break;
            case '.':
                Console.Write((char)memory[pointer]);
                break;
            case ',':
                memory[pointer] = Console.Read();
                break;
            case '[':
                if (memory[pointer] == 0)
                {
                    var c = 1;
                    while (c > 0)
                    {
                        index++;
                        if (code[index] == '[') c++;
                        if (code[index] == ']') c--;
                    }
                }
                break;
            case ']':
                if (memory[pointer] != 0)
                {
                    var c = 1;
                    while (c > 0)
                    {
                        index--;
                        if (code[index] == ']') c++;
                        if (code[index] == '[') c--;
                    }
                }
                break;
            default:
                break;
        }
    }
}