using UnityEngine;

public class RandomStringGenerator : MonoBehaviour
{
    private const string randomChar = "qwertyuiopasdfghjklzxcvbnm1234567890";

    public static string Generate(int length)
    {
        string randomString = "";
        for (int i = 0; i < length; i++)
        {
            randomString += randomChar[Random.Range(0, randomChar.Length)];
        }
        return randomString;
    }
}