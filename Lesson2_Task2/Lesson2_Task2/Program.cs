using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson2_Task2
{
    class Program
    {
        private static List<Account> _accounts = new List<Account>();
        private static List<Action> _actions = new List<Action>();

        private static void Main(string[] args)
        {
            Console.WriteLine("Введите 1 чтобы создать счет в системе \n" +
                "Введите 2 чтобы перевести деньги с одного счёта на другой \n" +
                "Введите 3 чтобы закрыть счёт \n " +
                "Введите undo чтобы отменить последнее действие");

            string comand = Console.ReadLine();

            switch (comand)
            {
                case "1":
                    DoAction(new CreateAccount());
                    break;

                case "2":
                    DoAction(new MoneyTransfer());
                    break;

                case "3":
                    DoAction(new CloseAccount());
                    break;

                case "undo":
                    UndoLastAction();
                    break;

                default:
                    Console.WriteLine("Ввод некоректной команды, попробуйте заного");
                    return;
            }
            Main(args);
        }

        private static void DoAction(Action action)
        {
            action.Do();
        }    

        private static void UndoLastAction()
        {
            Action action = _actions.LastOrDefault();

            if (action == null)
            {
                Console.WriteLine("Ошибка отмены действия, последней команды не существует");
                return;
            }

            action.Undo();
            _actions.Remove(action);
        }

        private static Account SearchAccount(string message)
        {
            Account account = null;

            while (account == null)
            {
                Console.WriteLine(message);
                string nameAccount = Console.ReadLine();
                account = _accounts.Find(x => x.Name == nameAccount);
            }

            return account;
        }

        private static int ConsoleReadLineParseInt(string messageNoCorrectValue)
        {
            int parseInt = 0;
            bool isInt = false;

            while (!isInt)
            {
                Console.WriteLine(messageNoCorrectValue);

                string readLine = Console.ReadLine();
                isInt = Int32.TryParse(readLine, out parseInt);
            }

            return parseInt;
        }

        public abstract class Action
        {
            public virtual void Do()
            {
                _actions.Add(this);
            }

            public abstract void Undo();
        }

        public class CreateAccount : Action
        {
            public override void Do()
            {
                Console.WriteLine("Введите название создаваемого счета");
                string nameAccount = Console.ReadLine();

                int money = ConsoleReadLineParseInt("Введите сумму которую хотите положить на счет");

                Account account = new Account(nameAccount, money);
                _accounts.Add(account);

                base.Do();
            }

            public override void Undo()
            {
                Console.WriteLine("Отмена действия! Аккаунт удален");
            }
        }

        public class MoneyTransfer : Action
        {
            private Account _account1;
            private Account _account2;

            private int _transferMoney;

            public override void Do()
            {
                if (!VerificationForTransferAndOutputAllAccounts()) return;
              
                _account1 = SearchAccount("Введите название счета, с которого требуется перевести средства");
                _account2 = SearchAccount("Введите название счета, на который требуется перевести средства");

                _transferMoney = ConsoleReadLineParseInt("Введите количество средств для перевода:");
                _account1.TransferMoney(_account2, _transferMoney);

                base.Do();
            }

            public override void Undo()
            {
                _account2.TransferMoney(_account1, _transferMoney);
                Console.WriteLine("Отмена действия! Перевод денег между счетами отменен");
            }

            protected bool VerificationForTransferAndOutputAllAccounts()
            {
                if (_accounts.Count == 0)
                {
                    Console.WriteLine("Чтобы производить операцию, создайте счет");

                    return false;
                }

                if (_accounts.Count < 2)
                {
                    Console.WriteLine("Создайте дополнительный счет чтобы выполнять перевод между счетами");
                    return false;
                }

                Console.WriteLine("Ваши счета:");

                foreach (Account account in _accounts)
                {
                    Console.WriteLine($"Название: {account.Name} Средства: {account.Cash}");
                }

                return true;
            }
        }

        public class CloseAccount : MoneyTransfer
        {
            private Account _deleteAccount;
            private Account _backupAccount;

            public override void Do()
            {
                if (!VerificationForTransferAndOutputAllAccounts()) return;
                
                _deleteAccount = SearchAccount("Введите название счета, который требуется удалить");
                _backupAccount = SearchAccount("Введите название счета, на который переведутся средства после удаления");
                _deleteAccount.TransferMoney(_backupAccount, _deleteAccount.Cash);
                _accounts.Remove(_deleteAccount);

                base.Do();
            }

            public override void Undo()
            {
                _accounts.Add(_deleteAccount);
                _backupAccount.TransferMoney(_deleteAccount, _backupAccount.Cash);
                Console.WriteLine("Отмена действия! Аккаунт востановлен");
            }
        }

    }

    public class Account
    {
        public string Name { get; private set; }
        public int Cash { get; private set; }

        public Account(string name, int money)
        {
            Name = name;
            Cash = money;
            Console.WriteLine("Счет успешно создан");
        }

        public void TransferMoney(Account transferAccount, int transferMoney)
        {
            if (transferMoney > Cash)
            {
                Console.WriteLine("Нехватает средств на счету");
                return;
            }
            else
            {
                Cash -= transferMoney;
                transferAccount.Cash += transferMoney;

                Console.WriteLine($"Успешный перевод средств - {transferMoney}, со счета: {Name}, на счет: {transferAccount.Name}");
            }
        }
    }

}
