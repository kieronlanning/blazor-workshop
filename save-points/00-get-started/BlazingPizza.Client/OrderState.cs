using System.Collections.Generic;

namespace BlazingPizza.Client
{
	public class OrderState
	{
		public Pizza ConfiguringPizza { get; private set; }
		
		public bool ShowingConfigureDialog { get; private set; }
		
		public Order Order { get; private set; } = new Order();

        public void ShowConfigurePizzaDialog(PizzaSpecial special)
        {
            ConfiguringPizza = new Pizza
            {
                Special = special,
                SpecialId = special.Id,
                Size = Pizza.DefaultSize,
                Toppings = new List<PizzaTopping>()
            };

            ShowingConfigureDialog = true;        
        }


        public void CancelConfiguringPizza()
        {
            CloseConfiguringPizzaDialog();
        }

        public void ConfirmConfiguringPizza()
        {
            Order.Pizzas.Add(ConfiguringPizza);

            CloseConfiguringPizzaDialog();
        }

        public void ResetOrder()
		{
            Order = new Order();
		}

        public void RemoveConfiguredPizza(Pizza pizza)
        {
            Order.Pizzas.Remove(pizza);
        }

        void CloseConfiguringPizzaDialog()
        {
            ConfiguringPizza = null;
            ShowingConfigureDialog = false;
        }
    }
}