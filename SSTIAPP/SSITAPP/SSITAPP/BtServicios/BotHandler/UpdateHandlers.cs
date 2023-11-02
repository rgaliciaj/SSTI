using Serilog;
using System.Text.RegularExpressions;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using ModelsStore.DbConn.DbConect;
using ModelsStore.DTO.TABLES;
using SqlKata;
using ClassDB.SqlKataTools;

namespace SSITAPP.BtServicios.BotHandler
{
    public static class UpdateHandlers
    {
        public static string? BotUserName = null!;
        public static IConfiguration configuration = null!;
        public static IServiceScopeFactory serviceScopeFactory = null!;

        public static long AdminUserId => configuration.GetValue<long>("BotConfig:AdminUserId");
        public static string AdminUserUrl => configuration.GetValue<string>("BotConfig:AdminUserUrl");
        public static decimal MinUSDT => configuration.GetValue("MinToken:USDT", 5m);
        public static decimal FeeRate => configuration.GetValue("FeeRate", 0.1m);
        public static decimal USDTFeeRate => configuration.GetValue("USDTFeeRate", 0.01m);


        //Manejo de errores.
        public static Task PollingErrorHandler(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException => $"Telegram API Error: \n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.Error.WriteLine(ErrorMessage);
            Log.Error(exception, ErrorMessage);

            return Task.CompletedTask;
        }

        //Procesa actualizaciones
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Message is not { } message) return;

            if (message.Text is not { } messageText) return;

            var chatId = message.Chat.Id;

            //Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");
            //await botClient.SendTextMessageAsync
            //    (chatId, "Holaaaaaaaaaaaa");

            var handler = update.Type switch
            {
                UpdateType.Message => BotOnMessageReceived(botClient, update.Message!),
                _ => UnknownUpdateHandlerAsync(botClient, update)
            };

            try
            {
                //    Message sentMessage = await botClient.SendTextMessageAsync(
                //chatId: chatId,
                //text: "You said:\n" + messageText,
                //cancellationToken: cancellationToken);

                await handler;
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Oh no，el robot cometió un error");
                await PollingErrorHandler(botClient, exception, cancellationToken);
            }
        }

        //Recepción de mensajes
        private async static Task<Task> BotOnMessageReceived(ITelegramBotClient botClient, Message message)
        {

            try
            {
                if (message.Text is not { } messageText) return Task.CompletedTask;

                List<string> comandosValidos = new List<string> { "/ticket", "/nuevo" };

                switch (messageText)
                {
                    case "/ticket":
                        // Realiza una solicitud HTTP al controlador
                        //var httpClient = new HttpClient();
                        //var response = await httpClient.GetAsync("https://localhost:7240/Ticket/obtenerTicketTecnico/0195175169D2400CA25FDB29E22D4A26");

                        
                                ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

                                var connection = new ConectionDecider();

                                var query = new Query("V_TICKET")
                                    .Select("*").Where("CODIGO_TECNICO", "Jorge Rodriguez").Where("ESTADO_TICKET", "PENDIENTE");

                                var sql = execute.ExecuterCompiler(query);

                                var list = new List<TicketModel>();

                                execute.DataReader(sql, reader =>
                                {
                                    list = DataReaderMapper<TicketModel>.MapToList(reader);
                                });

                            

                        if (list.Count > 0)
                        {
                            //var content = await response.Content.ReadAsStringAsync();

                            //Console.WriteLine(content);

                            //var weatherForecasts = JsonSerializer.Deserialize<List<TicketModel>>(list);

                            //foreach (var forecast in list)
                            //{
                            //    Console.WriteLine($"Fecha: {forecast.date}, Temperatura (°C): {forecast.temperatureC}, Resumen: {forecast.temperatureF}");
                            //}


                            string markdownResponse = "📅 *Listado de tickets pendientes:*\n\n";

                            foreach (var forecast in list)
                            {
                                //int temperatureC = Math.Abs(forecast.temperatureC);
                                //var summary = Regex.Replace(forecast.summary, @"[^\w\s]", "");

                                markdownResponse += $" *Código:* {forecast.CODIGO_TICKET}\n";
                                markdownResponse += $" *Prioridad:* {forecast.CODIGO_PRIORIDAD}\n";
                                markdownResponse += $" *Usuario ingreso:* {forecast.CODIGO_USUARIO}\n";
                                markdownResponse += $" *Recurso:* {forecast.CODIGO_RECURSO}\n";
                                markdownResponse += $" *Estado:* {forecast.ESTADO_TICKET}\n";
                                markdownResponse += $" *Fecha:* {forecast.FECHA_CREACION:dd/MM/yyyy}\n";
                                markdownResponse += $" *Descripción:* {forecast.DESCRIPCION}\n";
                                markdownResponse += "\n";
                            }

                            markdownResponse = markdownResponse.Trim();


                            await botClient.SendTextMessageAsync(
                                chatId: message.Chat.Id,
                                text: markdownResponse,
                                parseMode: ParseMode.MarkdownV2,
                                cancellationToken: default
                            );
                            // $"📩 Aquí tienes el resultado solicitado:\n\n{markdownResponse}",
                        }
                        else
                        {
                            await botClient.SendTextMessageAsync(
                                chatId: message.Chat.Id,
                                text: "Sin tickets pendientes.",
                                cancellationToken: default
                            );
                        }

                        break;

                    case "/nuevo":

                        await botClient.SendTextMessageAsync(
                            chatId: message.Chat.Id,
                            text: $"➡️ Ingresar a plataforma para crear ticket",
                            parseMode: ParseMode.Html,
                            replyMarkup: new InlineKeyboardMarkup(
                                InlineKeyboardButton.WithUrl(
                                    text: "Ir a la web",
                                    url: "https://servicios.guatex.gt/Guatex/Login?ReturnUrl=%2FGuatex")),
                            cancellationToken: default
                        );

                        break;

                    default:

                        string respuestaPorDefecto = "Por favor envíame una opción válida. Las opciones disponibles son:\n";
                        respuestaPorDefecto += string.Join("\n", comandosValidos);

                        await botClient.SendTextMessageAsync(message.Chat.Id, respuestaPorDefecto, cancellationToken: default);

                        break;
                }

                //if (messageText.StartsWith("/ticket"))
                //{
                    
                //}


                //if (messageText.StartsWith("/nuevo"))
                //{
                //}



            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción que pueda ocurrir
                await botClient.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: "Ocurrió un error: " + ex.Message,
                    cancellationToken: default
                );
            }
            Log.Information($"Receive message type: {message.Type}");
            Console.WriteLine("He ingresado al BotOnMessageReceived [" + message.Text + "]");

            return Task.CompletedTask;

        }

        private static Task UnknownUpdateHandlerAsync(ITelegramBotClient botClient, Update update)
        {
            Console.WriteLine("He ingresado al UnknownUpdateHandlerAsync ");
            return Task.CompletedTask;
        }
    }
}
