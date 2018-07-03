using ApiAiSDK;
using System;

namespace ChatBotTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var config = new AIConfiguration("eb3389c5a99b41bdb080a9ec2c9ebe98", SupportedLanguage.English);
            var apiAi = new ApiAi(config);

            Console.WriteLine("Welcome to chat bot test, please say something to the bot.");

            while (true)
            {
                var command = Console.ReadLine();
                var response = apiAi.TextRequest(command);
                Console.WriteLine(response.Result.Fulfillment.Speech);
            }
        }
    }
}