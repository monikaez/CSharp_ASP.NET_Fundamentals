
namespace Chat.Controllers;


using Chat.Models.Chat;
using Microsoft.AspNetCore.Mvc;

public class ChatController : Controller
{
    private static readonly List<KeyValuePair<string, string>> messages = new();

    public IActionResult Show()
    {
        if (messages.Count <1)
        {
            return this.View(new ChatViewModel());
        }
        var chatViewModel = new ChatViewModel()
        {
            AllMessages = messages.Select(m => new MessageViewModel()
            {
                Sender = m.Key,
                MessageText = m.Value
            }).ToArray()
        };
        return this.View(chatViewModel);
    }

    [HttpPost]
    public IActionResult Send(ChatViewModel chatViewModel)
    {
        if (!ModelState.IsValid)
        {
            return this.RedirectToAction("Show");
        }

        var currentMessage = new KeyValuePair<string, string>(chatViewModel.CurrentMessage.Sender, chatViewModel.CurrentMessage.MessageText);
        messages.Add(currentMessage);

        return this.RedirectToAction("Show");

    }
}
