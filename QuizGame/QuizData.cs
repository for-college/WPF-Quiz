using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame
{
    public class QuizData
    {
        public string[] Questions { get; } = {
        "Белая [birch] [under] [me] [window]",
        "[guys] [swimming] в [river]",
        "Завтра утром [me] пойду в лес за [mushrooms] и [berries]",
        "Гена перечислил известные виды спорта: [football] , [basketball] , [volleyball] , [hockey] , [running]",
        "После [rain] дети [wait] [rainbow] , но [rain] не собирался [stop]",
        "[us] [look] овраг лишь тогда, когда рассеялся [fog]",
        "После [rain] дети [wait] [rainbow] , но [rain] не собирался [stop]"
        };

        public string[] Answers { get; } = {
        "Белая береза под моим окном",
        "Мальчики купаются в речке",
        "Завтра утром я пойду в лес за грибами и ягодами",
        "Гена перечислил известные виды спорта: футбол, баскетбол, волейбол, хоккей, бег",
        "После дождя дети ждали радугу, но дождь не собирался останавливаться",
        "Мы увидели овраг лишь тогда, когда рассеялся туман",
        "После дождя дети ждали радугу, но дождь не собирался останавливаться"
        };

        public string[] SentencesImages { get; } = {
        // 1
        "me.png",
        "birch.png",
        "under.png",
        "window.png",
        // 2
        "guys.png",
        "river.png",
        "swimming.png",
        // 3
        "berries.png",
        "mushrooms.png",
        // 4
        "basketball.png",
        "football.png",
        "hockey.png",
        "running.png",
        "volleyball.png",
        // 5
        "rain.png",
        "rainbow.png",
        "stop.png",
        "wait.png",
        // 6
        "fog.png",
        "look.png",
        "us.png",
        // 7
        "apple.png",
        "pears.png",
        };
    }
}
