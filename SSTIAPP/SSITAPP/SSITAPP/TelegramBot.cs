//using Telegram.Bot;
//using Telegram.Bot.Exceptions;
//using Telegram.Bot.Polling;
//using Telegram.Bot.Types;
//using Telegram.Bot.Types.Enums;


//namespace SSITAPP
//{
//    public class TelegramBot
//    {
//        static ITelegramBotClient? _botClient;

//        public static IUpdateHandler HandlerUpdateAsync { get; private set; }

//        public static void SayHello()
//        {
//            _botClient = new TelegramBotClient("6887134526:AAEUxRp3f7Vs9Fbd-mREOQou0IQVnJSGels");

//            var me = _botClient.GetMeAsync().Result;

//            Console.WriteLine($"Hi, I am {me.Id}, my username is {me.Username} and my name is {me.FirstName} {me.LastName}");


            

//            //_botClient.StartReceiving(
//            //    updateHandler: HandlerUpdateAsync
//            //    );

            
//        }

//        private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
//        {
//            // Only process Message updates: https://core.telegram.org/bots/api#message
//            if (update.Message is not { } message)
//                return;
//            // Only process text messages
//            if (message.Text is not { } messageText)
//                return;

//            var chatId = message.Chat.Id;

//            Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

//            // Echo received message text
//            Message sentMessage = await botClient.SendTextMessageAsync(
//                chatId: chatId,
//                text: "You said:\n" + messageText,
//                cancellationToken: cancellationToken);
//        }

        
//    }
//}
