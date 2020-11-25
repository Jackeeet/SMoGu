using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMoGu.App
{
    public class Investments
    {
        private List<Investment> invs; //это просто контейнер для всех инвестиций
        public List<Investment> bestInvs { get; private set; } // это список, который мы получаем после анализа наилучших вариантов

        public Investments()
        {
            invs = new List<Investment>();
        }

        public void AddInvestment(string name, decimal amount, CurrencyType currency, int period)
        // это для добавления новых вариантов инвестиции через форму создания
        {
            invs.Add(new Investment(name, amount, currency, period));
        }

        public void GetBestOptions()
        // это для отображения вариантов в порядке их привлекательности (анализ вариантов)
        {
            bestInvs = invs.OrderByDescending(inv => inv.ProceedsEstimate).ToList();
        }
    }
}
