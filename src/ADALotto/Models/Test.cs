using System.Collections.Generic;

public class Test
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public Test? Sibling { get; set; }
    public List<Test>? Siblings { get; set; }
    public int[] Numbers { get; set; } = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    public byte[] Hash { get; set; } = new byte[] { 145, 99, 36, 213, 184, 222, 198, 38, 140, 35, 168, 140, 175, 45, 3, 232, 162, 217, 14, 185, 54, 238, 165, 124, 93, 151, 29, 179, 3, 112, 104, 241 };
}