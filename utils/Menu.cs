using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open_Store {
    internal class Menu {
        private List<String> MenuItems = new List<string>();
        
        public Menu(List<String> MenuItems) {
            this.MenuItems = MenuItems;
        }
        public string? PromtNow() {
            int selectedItemIndex = 0;

            while (true) {
                Console.Clear();

                // Display all menu items and highlight the selected one
                for (int i = 0; i < MenuItems.Count; i++) {
                    Console.ForegroundColor = (i == selectedItemIndex) ? ConsoleColor.Yellow : ConsoleColor.White;
                    Console.WriteLine(MenuItems[i]);
                }

                // Wait for user input and move the selected item up or down accordingly
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.UpArrow) {
                    selectedItemIndex = (selectedItemIndex == 0) ? MenuItems.Count - 1 : selectedItemIndex - 1;
                } else if (keyInfo.Key == ConsoleKey.DownArrow) {
                    selectedItemIndex = (selectedItemIndex + 1) % MenuItems.Count;
                } else if (keyInfo.Key == ConsoleKey.Enter) {
                    return MenuItems[selectedItemIndex];
                }
            }
        }
    }
}
