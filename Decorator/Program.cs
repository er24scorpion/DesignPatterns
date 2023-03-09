using Decorator;

Console.Title = "Decorator";

var cloudMS = new CloudMailsService();
cloudMS.SendMessage("Hi there");

var onPremiseService = new OnPremiseService();
onPremiseService.SendMessage("Hi there");

var statistics = new StatisticsDecorator(onPremiseService);
statistics.SendMessage($"Hi there via {nameof(StatisticsDecorator)} wrapper");


var dbDec = new MessageDatabaseDecorator(cloudMS);
dbDec.SendMessage($"Hi there via {nameof(MessageDatabaseDecorator)} wrapper, message 1");
dbDec.SendMessage($"Hi there via {nameof(MessageDatabaseDecorator)} wrapper, message 2");

foreach(var m in dbDec.SentMessages)
{
    Console.WriteLine($"Stored message: {m}");
}

