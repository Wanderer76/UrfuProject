using System;
using System.Collections.Generic;
using System.Linq;

namespace UrfuProject
{
    public class QuestStore
    {
        private static QuestStore instance;

        private readonly Dictionary<ScienceType, List<Quest>> data = new Dictionary<ScienceType, List<Quest>>
        {
            {ScienceType.Math, new List<Quest>{
                new Quest("Помощь ювелиру",
                    "Добро пожаловать в новую лабораторию, надеюсь ты не закончишь свою жизнь на костре. Чтобы этого не случилось тебе придется выполнять поручения местных жителей. Давай начнем с чего-то простого. Взвесь самородки для местного ювелира.",
                    230,  QuestLevel.First, ScienceType.Math ,QuestType.Weights
                    )
            }},
            {ScienceType.Physics, new List<Quest>{
                new Quest("Неудачливый торговец",
                    "Что ж, раз ты еще не умер, то тебе надо помочь местному торговцу. Ему необходимо переправить свой груз в другой город, но к сожалению, из-за последнего шторма его корабыль пришел в негодность. К счастью, у нас есть старый плот. Тебе предстоит погрузить максимально возможное число предметов. Если ты ошибешся и погрузишь слишком много и плот утонет или если погрузишь недостаточно, то награды тебе не видать!",
                    230, QuestLevel.Second, ScienceType.Physics, QuestType.Dock)
            } },
        };

        public static QuestStore Instance()
        {
            if (instance == null)
                instance = new QuestStore();
            return instance;
        }

        public int QuestCount() => data
                .SelectMany(quest => quest.Value)
                .Count();

        public IEnumerable<Quest> GetAllQuest() => data
                .SelectMany(quest => quest.Value);

        public Quest GetRandomQuest(ScienceType type)
        {
            var typeQuests = data[type];
            return typeQuests[new Random().Next(0, typeQuests.Count - 1)];
        }

        public void SetStatus(Quest quest, QuestStatus status)
        {
            data[quest.ScienceType].Where(q => q.MainText == quest.MainText).First().Status = status;
        }
    }
}