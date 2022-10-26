using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_E_mailing_service
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Client client = new User("abc", "123");
            UserFacade facade = new UserFacade();
            client.Start(facade);
        }

        abstract class Client
        {
            public string login;
            public string password;
            public Client (string login, string password)
            {
                this.login = login;
                this.password = password;
            }

            public void Start (UserFacade facade)
            {
                facade.Start();
            }
        }

        class User : Client
        {
            public User(string login, string password) : base(login, password)
            {
            }
        }

        class Admin : Client
        {
            public Admin(string login, string password) : base(login, password)
            {
            }

            void CreateUser() { }
            void UpdateUser() { }
            void DeleteUser() { }
            // финансы, статистика, аналитика...  
        }

        class UserFacade
        {
            //MailingList mailingList;

            public UserFacade(/*MailingList mailingList*/)
            {
                //this.mailingList = mailingList;
            }

            public void Start()
            {
                // меню
                CreateMail();
            }

            void CreateMail() 
            {
                Mail mail = new Mail();
            }
            void SaveMail() { }
            void DeleteMail() { }
            void UpDateMail() { }
            void SendMail() { }

            void AddSubscribers() { }
            void DeleteSubscribers() { }
            void ShowSubscribers() { }

            void ShowMailingList() { }

            //+финансы, аналитика, статистика...
        }

        //наблюдаемый объект
        interface IObservable
        {            
            void AddObserver(IObserver o);
            void RemoveObserver (IObserver o);
            void NotifyObservers();
        }

        class MailObservable : IObservable
        {
            private List<IObserver> observers;
            public MailObservable()
            {
                observers = new List<IObserver>();
            }

            //добавить наблюдателя
            public void AddObserver(IObserver o)
            {
                observers.Add(o);
            }

            //удалить наблюдателя
            public void RemoveObserver(IObserver o)
            {
                observers.Remove(o);
            }

            //уведомить наблюдателя
            public void NotifyObservers()
            {
                foreach (IObserver observer in observers)
                    observer.Update();
            }
        }

        abstract class MailPrototype
        {
            public string text;
            public MailPrototype()
            {
                text = "Новое уведомление";
            }

            public abstract MailPrototype Clone();
        }

        class MailReminder : MailPrototype
        {
            public MailReminder () : base()
            {
                text = "Новое напоминание";
            }

            public override MailPrototype Clone()
            {
                return new MailReminder();
            }
        }

        class MailCongratulation : MailPrototype
        {
            public MailCongratulation() : base()
            {
                text = "Поздравительная открытка";
            }

            public override MailPrototype Clone()
            {
                return new MailCongratulation();
            }
        }


        //наблюдатели
        interface IObserver
        {
            void Update();
        }

        class ConcreteObserver : IObserver
        {
            public void Update()
            {
            }
        }


       

        class MailingList
        {
            int numberOfMailing;
            Mail[] allMails;

            int costOfMailing;

        }

    }
}
