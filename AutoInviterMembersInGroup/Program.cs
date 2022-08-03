using AutoInviterMembersInGroup;
using TL;


var randomSecundForPause = new Random();
var logicClass = new AllLogic();

const string PATH = @"C:\Users\itehn\Desktop\IdAndAccesHashMembers.txt";

using var client = new WTelegram.Client();
var myClient = await client.LoginUserIfNeeded();
Console.WriteLine($"We are logged-in as {myClient.username ?? myClient.first_name + " " + myClient.last_name} (id {myClient.id})");

var thirtList = logicClass.CreatedThirtyMembersFromListAndSavingBigListInFile(logicClass.GetListWithIdAndHashMembers(PATH), PATH);

var idAndAccesHashDictionary = logicClass.TransformListInDictionary(thirtList);


var chats = await client.Messages_GetAllChats();

#region show all chats
//foreach (var (id, chat) in chats.chats)
//{
//    switch (chat)
//    {
//        case Channel group when group.IsGroup:
//            Console.WriteLine($"{id}: Group {group.username}: {group.title}");
//            break;
//    }
//}
#endregion

#region Get chat id
//Console.Write("Type a chat ID: ");
#endregion

long groupId = 1679143523;
var channel = chats.chats[groupId];


var counter = 0;

foreach (var item in idAndAccesHashDictionary)
{
    try
    {
        var user = new InputUser(item.Key, item.Value);
        await client.AddChatUser(channel, user);
        Console.WriteLine($"Added in chat user id {user.user_id}");
        Thread.Sleep(randomSecundForPause.Next(100000, 150000));
        counter++;
    }
    catch (Exception)
    {
        Console.WriteLine("Exception");
        Thread.Sleep(randomSecundForPause.Next(100000, 150000));
    }
}

Console.WriteLine($"Added {counter} members in chat");



